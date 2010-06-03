﻿#region License

// Copyright (c) 2010, ClearCanvas Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, 
//      this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, 
//      this list of conditions and the following disclaimer in the documentation 
//      and/or other materials provided with the distribution.
//    * Neither the name of ClearCanvas Inc. nor the names of its contributors 
//      may be used to endorse or promote products derived from this software without 
//      specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
// GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

#endregion

using System;
using System.Collections.Generic;
using ClearCanvas.Common.Specifications;
using ClearCanvas.Common.Utilities;

namespace ClearCanvas.Enterprise.Core.Modelling
{
	/// <summary>
	/// Provides domain object validation functionality.
	/// </summary>
	/// <remarks>
	/// Instances of this class are not thread-safe and should never be used by more than one thread.
	/// </remarks>
	public class DomainObjectValidator
	{
		private static readonly Type[] _lowLevelRuleClasses = new[]
		{
			typeof(LengthSpecification),
			typeof(RequiredSpecification),
			typeof(UniqueKeySpecification),
			typeof(UniqueSpecification),
			typeof(EmbeddedValueRuleSet)
		};

		private readonly Dictionary<Type, ValidationRuleSet> _ruleSets = new Dictionary<Type, ValidationRuleSet>();

		#region Public API

		/// <summary>
		/// Validates the specified domain object, applying all known validation rules.
		/// </summary>
		/// <param name="obj"></param>
		/// <exception cref="EntityValidationException">Validation failed.</exception>
		public void Validate(DomainObject obj)
		{
			// validate all rules
			Validate(obj, rule => true);
		}

		/// <summary>
		/// Validates only that the specified object has required fields set.
		/// </summary>
		/// <param name="obj"></param>
		public void ValidateRequiredFieldsPresent(DomainObject obj)
		{
			ValidateLowLevel(obj, rule => rule is RequiredSpecification);
		}


		/// <summary>
		/// Validates the specified domain object, applying only "low-level" rules, subject to the specified filter.
		/// </summary>
		/// <remarks>
		/// Low-level rules are:
		/// 1. Required fields.
		/// 2. String field lengths.
		/// 3. Unique constraints.
		/// </remarks>
		/// <param name="obj"></param>
		/// <param name="ruleFilter"></param>
		public void ValidateLowLevel(DomainObject obj, Predicate<ISpecification> ruleFilter)
		{
			// construct a predicate which says:
			// 1. if the rule is a low-level rule class, let the caller's ruleFilter decide
			// 2. if the rule is a rule-set (but not an embedded-value ruleset which has already been covered in 1), then evaluate it
			Validate(obj, rule => IsLowLevelRule(rule)? ruleFilter(rule) : rule is IValidationRuleSet);
		}

		/// <summary>
		/// Validates the specified domain object, applying only high-level rules.
		/// </summary>
		/// <remarks>
		/// High-level rules include any rules that are not low-level rules.
		/// </remarks>
		/// <param name="obj"></param>
		public void ValidateHighLevel(DomainObject obj)
		{
			Validate(obj, r => !IsLowLevelRule(r));
		}

		#endregion

		/// <summary>
		/// Validates the specified domain object, ignoring any rules that do not satisfy the filter.
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="ruleFilter"></param>
		/// <exception cref="EntityValidationException">Validation failed.</exception>
		private void Validate(DomainObject obj, Predicate<ISpecification> ruleFilter)
		{
			var domainClass = obj.GetClass();

			ValidationRuleSet rules;

			// first check for a cached rule-set
			if (!_ruleSets.TryGetValue(domainClass, out rules))
			{
				// otherwise build it
				rules = ValidationRuleSetCache.GetInvariantRules(domainClass)
					.Add(ValidationRuleSetCache.GetCustomRules(domainClass));
				_ruleSets.Add(domainClass, rules);
			}

			var result = rules.Test(obj, ruleFilter);
			if (result.Fail)
			{
				var message = string.Format(SR.ExceptionInvalidEntity, TerminologyTranslator.Translate(obj.GetClass()));
				throw new EntityValidationException(message, result.Reasons);
			}
		}

		/// <summary>
		/// Checks if the specified rule is considered a low-level rule.
		/// </summary>
		/// <param name="rule"></param>
		/// <returns></returns>
		private static bool IsLowLevelRule(ISpecification rule)
		{
			return CollectionUtils.Contains(_lowLevelRuleClasses, t => t.Equals(rule.GetType()));
		}
	}
}

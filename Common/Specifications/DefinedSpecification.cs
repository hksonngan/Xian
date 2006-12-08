using System;
using System.Collections.Generic;
using System.Text;

namespace ClearCanvas.Common.Specifications
{
    public class DefinedSpecification : Specification
    {
        private ISpecification _lambda;

        public DefinedSpecification(string testExpression, ISpecification lambda, string failureMessage)
            :base(testExpression, failureMessage)
        {
            _lambda = lambda;
        }

        protected override TestResult InnerTest(object exp)
        {
            TestResult r = _lambda.Test(exp);
            if (r.Success)
            {
                return new TestResult(true);
            }
            else
            {
                return new TestResult(false, new TestResultReason(this.FailureMessage, r.Reason));
            }
        }

        public override IEnumerable<ISpecification> SubSpecs
        {
            get { return new ISpecification[] { _lambda }; }
        }
    }
}

#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using ClearCanvas.Common.Utilities;

namespace ClearCanvas.ImageViewer.Tools.Standard.Configuration
{
	public sealed class ToolModalityBehaviorCollection : IEnumerable<KeyValuePair<string, ToolModalityBehavior>>, IXmlSerializable
	{
		private event EventHandler _collectionChanged;
		private readonly Dictionary<string, ToolModalityBehavior> _entries = new Dictionary<string, ToolModalityBehavior>();

		public ToolModalityBehaviorCollection() {}

		public ToolModalityBehaviorCollection(IEnumerable<KeyValuePair<string, ToolModalityBehavior>> source)
			: this()
		{
			if (source == null)
				return;

			foreach (var entry in source)
				SetEntry(entry.Key, new ToolModalityBehavior(entry.Value));
		}

		internal int Count
		{
			get { return _entries.Count; }
		}

		public ToolModalityBehavior this[string modality]
		{
			get { return GetEntry(modality, true); }
			set { SetEntry(modality, value); }
		}

		public event EventHandler CollectionChanged
		{
			add { _collectionChanged += value; }
			remove { _collectionChanged -= value; }
		}

		private void Clear()
		{
			foreach (var entry in _entries)
				entry.Value.PropertyChanged -= HandleEntryPropertyChanged;
			_entries.Clear();
		}

		public bool Contains(string modality)
		{
			return _entries.ContainsKey(GetCleanKey(modality));
		}

		private void SetEntry(string modality, ToolModalityBehavior value)
		{
			modality = GetCleanKey(modality);

			ToolModalityBehavior oldValue;
			if (_entries.TryGetValue(modality, out oldValue) && oldValue != null)
				oldValue.PropertyChanged -= HandleEntryPropertyChanged;

			_entries[modality] = value;

			if (value != null)
				value.PropertyChanged += HandleEntryPropertyChanged;
		}

		private ToolModalityBehavior GetEntry(string modality, bool createIfNotExists)
		{
			modality = GetCleanKey(modality);
			if (_entries.ContainsKey(modality))
				return _entries[modality];

			ToolModalityBehavior entry = null;
			if (createIfNotExists)
				SetEntry(modality, entry = new ToolModalityBehavior());
			return entry;
		}

		public ToolModalityBehavior GetEntryOrDefault(string modality)
		{
			var behavior = GetEntry(modality, false);
			return behavior ?? this[string.Empty];
		}

		private void HandleEntryPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			EventsHelper.Fire(_collectionChanged, this, new EventArgs());
		}

		private static string GetCleanKey(string modality)
		{
			return !string.IsNullOrEmpty(modality) ? modality.ToUpperInvariant() : string.Empty;
		}

		public IEnumerator<KeyValuePair<string, ToolModalityBehavior>> GetEnumerator()
		{
			return _entries.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#region Implementation of IXmlSerializable

		private static readonly XmlSerializer _behaviorSerializer = new XmlSerializer(typeof (ToolModalityBehavior));

		public void ReadXml(XmlReader reader)
		{
			var list = new List<KeyValuePair<string, ToolModalityBehavior>>();

			reader.MoveToContent();
			var empty = reader.IsEmptyElement;
			reader.ReadStartElement();
			if (!empty)
			{
				while (reader.MoveToContent() == XmlNodeType.Element)
				{
					if (reader.Name == @"Entry" && !reader.IsEmptyElement)
					{
						var modality = reader.GetAttribute(@"Modality");
						reader.ReadStartElement();
						reader.MoveToContent();
						var behavior = _behaviorSerializer.Deserialize(reader) as ToolModalityBehavior;
						reader.MoveToContent();
						reader.ReadEndElement();

						if (behavior != null)
							list.Add(new KeyValuePair<string, ToolModalityBehavior>(modality, behavior));
					}
					else
					{
						// consume the bad element and skip to next sibling or the parent end element tag
						reader.ReadOuterXml();
					}
				}
				reader.MoveToContent();
				reader.ReadEndElement();
			}

			Clear();
			foreach (var pair in list)
				SetEntry(pair.Key, pair.Value);
		}

		public void WriteXml(XmlWriter writer)
		{
			foreach (var entry in this)
			{
				writer.WriteStartElement(@"Entry");
				writer.WriteAttributeString(@"Modality", entry.Key);
				_behaviorSerializer.Serialize(writer, entry.Value);
				writer.WriteEndElement();
			}
		}

		XmlSchema IXmlSerializable.GetSchema()
		{
			return null;
		}

		#endregion
	}
}
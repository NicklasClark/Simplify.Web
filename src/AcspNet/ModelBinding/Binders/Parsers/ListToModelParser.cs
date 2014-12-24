﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AcspNet.ModelBinding.Attributes;

namespace AcspNet.ModelBinding.Binders.Parsers
{
	/// <summary>
	/// Provides list of key value pair to model binding
	/// </summary>
	public static class ListToModelParser
	{
		/// <summary>
		/// Parses list and creates a model.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static T Parse<T>(IList<KeyValuePair<string, string[]>> source)
		{
			var type = typeof(T);

			var obj = Activator.CreateInstance<T>();

			foreach (var propInfo in type.GetProperties())
			{
				var propertyInfo = propInfo;
				propInfo.SetValue(obj, ParseProperty(propInfo, source.FirstOrDefault(x => x.Key == propertyInfo.Name)));
			}

			return obj;
		}

		private static object ParseProperty(PropertyInfo propertyInfo, KeyValuePair<string, string[]> keyValuePair)
		{
			if (keyValuePair.Equals(default(KeyValuePair<string, string[]>)) || keyValuePair.Value.Length == 0)
				return null;

			return ArrayToSpecifiedListParser.IsTypeValidForParsing(propertyInfo.PropertyType)
				? ArrayToSpecifiedListParser.ParseUndefined(keyValuePair.Value, propertyInfo.PropertyType, TryGetFormat(propertyInfo))
				: StringToSpecifiedObjectParser.ParseUndefined(string.Join(",", keyValuePair.Value), propertyInfo.PropertyType, TryGetFormat(propertyInfo));
		}

		private static string TryGetFormat(PropertyInfo propertyInfo)
		{
			var attributes = propertyInfo.GetCustomAttributes(typeof(FormatAttribute), false);

			if (attributes.Length == 0) return null;

			var format = ((FormatAttribute)attributes[0]).Format;

			return format;
		}
	}
}
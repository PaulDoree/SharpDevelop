﻿// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.ComponentModel;
using Debugger.Wrappers.CorDebug;

namespace Debugger
{
	public class PrimitiveValue: ValueProxy
	{
		public override string AsString {
			get {
				if (Primitive != null) {
					return Primitive.ToString();
				} else {
					return String.Empty;
				}
			}
		}
		
		public object Primitive { 
			get {
				if (TheValue.CorType == CorElementType.STRING) {
					return (TheValue.CorValue.CastTo<ICorDebugStringValue>()).String;
				} else {
					return (TheValue.CorValue.CastTo<ICorDebugGenericValue>()).Value;
				}
			}
			set {
				object newValue;
				TypeConverter converter = TypeDescriptor.GetConverter(ManagedType);
				try {
					newValue = converter.ConvertFrom(value);
				} catch {
					throw new NotSupportedException("Can not convert " + value.GetType().ToString() + " to " + ManagedType.ToString());
				}
				
				if (TheValue.CorType == CorElementType.STRING) {
					throw new NotSupportedException();
				} else {
					(TheValue.CorValue.CastTo<ICorDebugGenericValue>()).Value = newValue;
				}
				TheValue.NotifyChange();
			}
		}

		internal PrimitiveValue(Value @value):base(@value)
		{
		}

		protected override bool GetMayHaveSubVariables()
		{
			return false;
		}
	}
}

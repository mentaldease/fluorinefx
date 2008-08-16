/*
	FluorineFx open source library 
	Copyright (C) 2007 Zoltan Csibi, zoltan@TheSilentGroup.com, FluorineFx.com 
	
	This library is free software; you can redistribute it and/or
	modify it under the terms of the GNU Lesser General Public
	License as published by the Free Software Foundation; either
	version 2.1 of the License, or (at your option) any later version.
	
	This library is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
	Lesser General Public License for more details.
	
	You should have received a copy of the GNU Lesser General Public
	License along with this library; if not, write to the Free Software
	Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
*/
using System;
using System.Collections;
using System.Reflection.Emit;
using System.Globalization;

using antlr.collections;

namespace FluorineFx.Expression
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	internal class DateLiteralNode : BaseNode
	{
		private object _value;

		public DateLiteralNode()
		{
		}

		protected override object Evaluate(object context, EvaluationContext evalContext)
		{
			if (_value == null)
			{
				lock (this)
				{
					if (_value == null)
					{
						AST dateString = this.getFirstChild();
						if (getNumberOfChildren() == 2)
						{
							AST dateFormat = dateString.getNextSibling();
							_value = DateTime.ParseExact(dateString.getText(), dateFormat.getText(), CultureInfo.InvariantCulture);
						}
						else
						{
							_value = DateTime.Parse(dateString.getText());
						}
					}
				}
			}
			return _value;
		}

	}
}

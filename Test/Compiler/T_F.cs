using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mohamedothman.Compiler
{
	public class T_Family
	{
		protected string _name { get; set; }
		protected T_Family(string family) 
		{
			_name = family;
		}
		public string Name { get { return _name; } }

		public static T_Family Identifier { get { return new T_Family("Identifier"); } }
		public static T_Family Operator { get { return new T_Family("Operator"); } }
		public static T_Family Keyword { get { return new T_Family("Keyword"); } }
		public static T_Family Constant { get { return new T_Family("Constant"); } }
		public static T_Family Whitespace { get { return new T_Family("Whitespace"); } }
		public static T_Family Delimiter { get { return new T_Family("Delimiter"); } }
		public static T_Family Comment { get { return new T_Family("Comment"); } }
		public static T_Family PunctuationMark { get { return new T_Family("PunctuationMark"); } }
	}
}

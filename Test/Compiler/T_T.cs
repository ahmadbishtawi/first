using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mohamedothman.Compiler
{
	public class T_Type
	{
		protected T_Family[] _families { get; set; }
		protected string _name { get; set; }
		protected string _value { get; set; }
		protected string _pattern { get; set; }
		protected T_Type(string typeName, string typeValue, string pattern, params T_Family[] typefamilies)
		{
			_name = typeName;
			_value = typeValue;
			_families = typefamilies;
			_pattern = pattern;
		}
		protected T_Type(string typeName, string typeValue, params T_Family[] typefamilies) : this(typeName, typeValue, typeValue, typefamilies) { }
		protected T_Type(string typeName, params T_Family[] typefamilies) : this(typeName, typeName.ToLower(), typefamilies) { }
		public IEnumerable<T_Family> Families { get { return _families; } }
		public string Name { get { return _name; } }
		public string Value { get { return _value; } }
		public string Pattern { get { return _pattern; } }

		#region Keywords
		public static T_Type For { get { return new T_Type("For", T_Family.Keyword); } }
		public static T_Type While { get { return new T_Type("While", T_Family.Keyword); } }
		public static T_Type Do { get { return new T_Type("Do", T_Family.Keyword); } }
		public static T_Type If { get { return new T_Type("If", T_Family.Keyword); } }
		public static T_Type Switch { get { return new T_Type("Switch", T_Family.Keyword); } }
		public static T_Type Case { get { return new T_Type("Case", T_Family.Keyword); } }
		public static T_Type Foreach { get { return new T_Type("Foreach", T_Family.Keyword); } }
		public static T_Type Return { get { return new T_Type("Return", T_Family.Keyword); } }
		public static T_Type Break { get { return new T_Type("Break", T_Family.Keyword); } }
		public static T_Type Continue { get { return new T_Type("Continue", T_Family.Keyword); } }
		public static T_Type Using { get { return new T_Type("Using", T_Family.Keyword); } }

		public static T_Type Int { get { return new T_Type("Int", T_Family.Keyword); } }
		public static T_Type Float { get { return new T_Type("Float", T_Family.Keyword); } }
		public static T_Type Double { get { return new T_Type("Double", T_Family.Keyword); } }
		public static T_Type Long { get { return new T_Type("Long", T_Family.Keyword); } }
		public static T_Type Decemal { get { return new T_Type("Decemal", T_Family.Keyword); } }
		public static T_Type Char { get { return new T_Type("Char", T_Family.Keyword); } }
		public static T_Type String { get { return new T_Type("String", T_Family.Keyword); } }
		public static T_Type Void { get { return new T_Type("Void", T_Family.Keyword); } }

		public static T_Type Struct { get { return new T_Type("Struct", T_Family.Keyword); } }
		public static T_Type Class { get { return new T_Type("Class", T_Family.Keyword); } }
		public static T_Type Virtual { get { return new T_Type("Virtual", T_Family.Keyword); } }
		public static T_Type Sealed { get { return new T_Type("Sealed", T_Family.Keyword); } }
		public static T_Type Override { get { return new T_Type("Override", T_Family.Keyword); } }
		public static T_Type New { get { return new T_Type("New", T_Family.Keyword); } }
		public static T_Type Namespace { get { return new T_Type("Namespace", T_Family.Keyword); } }

		public static T_Type Public { get { return new T_Type("Public", T_Family.Keyword); } }
		public static T_Type Private { get { return new T_Type("Private", T_Family.Keyword); } }
		public static T_Type Protected { get { return new T_Type("Protected", T_Family.Keyword); } }
		public static T_Type Internal { get { return new T_Type("Internal", T_Family.Keyword); } }

		public static T_Type Static { get { return new T_Type("Static", T_Family.Keyword); } }
		public static T_Type Const { get { return new T_Type("Const", T_Family.Keyword); } }
		public static T_Type Readonly { get { return new T_Type("Readonly", T_Family.Keyword); } }
		#endregion

		#region Operators
		public static T_Type Assign { get { return new T_Type("Assign", "^=$", T_Family.Operator); } }
		public static T_Type Increment { get { return new T_Type("Increment", @"^\+\+$", T_Family.Operator); } }
		public static T_Type Decrement { get { return new T_Type("Decrement", @"^--$", T_Family.Operator); } }
		public static T_Type AddBy { get { return new T_Type("AddBy", @"^\+=$", T_Family.Operator); } }
		public static T_Type SubtractBy { get { return new T_Type("SubtractBy", @"^-=$", T_Family.Operator); } }
		public static T_Type MultiplyBy { get { return new T_Type("MultiplyBy", @"^\*=$", T_Family.Operator); } }
		public static T_Type DivideBy { get { return new T_Type("DivideBy", @"^\/=$", T_Family.Operator); } }


		public static T_Type Addition { get { return new T_Type("Addition", @"^\+&", T_Family.Operator); } }
		public static T_Type Subtraction { get { return new T_Type("Subtraction", "^-$", T_Family.Operator); } }
		public static T_Type Multiplication { get { return new T_Type("Multiplication", @"^\*$", T_Family.Operator); } }
		public static T_Type Division { get { return new T_Type("Division", @"^\/$", T_Family.Operator); } }

		public static T_Type EqualTo { get { return new T_Type("EqualTo", "^==$", T_Family.Operator); } }
		public static T_Type NotEqualTo { get { return new T_Type("NotEqualTo", "^!=$", T_Family.Operator); } }
		public static T_Type MoreThan { get { return new T_Type("MoreThan", "^>$", T_Family.Operator); } }
		public static T_Type LessThan { get { return new T_Type("LessThan", "^<$", T_Family.Operator); } }
		public static T_Type MoreThanOrEqualTo { get { return new T_Type("MoreThanOrEqualTo", "^>=$", T_Family.Operator); } }
		public static T_Type LessThanOrEqualTo { get { return new T_Type("LessThanOrEqualTo", "^<=$", T_Family.Operator); } }
		public static T_Type Not { get { return new T_Type("Not", "^!$", T_Family.Operator); } }
		public static T_Type And { get { return new T_Type("And", "^&&$", T_Family.Operator); } }
		public static T_Type Or { get { return new T_Type("Or", @"^\|\|$", T_Family.Operator); } }

		public static T_Type Dot { get { return new T_Type("Dot", @"^\.$", T_Family.Operator); } }
		#endregion

		#region Whitespaces && Delimiters
		public static T_Type Space { get { return new T_Type("Space", " ", T_Family.Whitespace, T_Family.Delimiter); } }
		public static T_Type Tab { get { return new T_Type("Tab", "\t", T_Family.Whitespace); } }
		public static T_Type NewLine { get { return new T_Type("NewLine", "\r\n", T_Family.Whitespace); } }
		#endregion

		#region Comments
		public static T_Type CommentOneLine { get { return new T_Type("CommentOneLine", $@"\/\/.*{NewLine.Value}", T_Family.Comment); } }
		//public static T_Type CommentMultiLine { get { return new T_Type("CommentMultiLine", @"\/\*.*\*\/", T_Family.Comment); } }
		#endregion

		#region Punctuation Marks
		public static T_Type Comma { get { return new T_Type("Comma", ",", T_Family.PunctuationMark); } }
		public static T_Type SemiColon { get { return new T_Type("SemiColon", ";", T_Family.PunctuationMark); } }

		public static T_Type LeftBrace { get { return new T_Type("LeftBrace", "{", T_Family.PunctuationMark); } }
		public static T_Type RightBrace { get { return new T_Type("RightBrace", "}", T_Family.PunctuationMark); } }
		public static T_Type LeftParenthesis { get { return new T_Type("LeftParenthesis", @"\(", T_Family.PunctuationMark); } }
		public static T_Type RightParenthesis { get { return new T_Type("RightParenthesis", @"\)", T_Family.PunctuationMark); } }
		public static T_Type LeftSquareBracket { get { return new T_Type("LeftSquareBracket", @"\[", T_Family.PunctuationMark); } }
		public static T_Type RightSquareBracket { get { return new T_Type("RightSquareBracket", @"\]", T_Family.PunctuationMark); } }
		#endregion

		#region Constants
		public static T_Type ConstNumber { get { return new T_Type("ConstNumber", @"[-+]?[0-9]+\.?[0-9]*", T_Family.Constant); } }
		public static T_Type ConstString { get { return new T_Type("ConstString", "\".*\"", T_Family.Constant); } }
		#endregion

		#region Identifiers
		public static T_Type Identifier { get { return new T_Type("Identifier", @"[a-zA-Z_][a-zA-Z0-9_]*", T_Family.Identifier); } }
		
		#endregion

		public static IEnumerable<T_Type> Types
		{
			get
			{
				return new List<T_Type>
				{
					T_Type.And, T_Type.Assign, T_Type.Break,
					T_Type.Case, T_Type.Char, T_Type.Class, T_Type.Comma, T_Type.Const,
					T_Type.Continue, T_Type.Decemal, T_Type.Do, T_Type.Dot, T_Type.Double,
					T_Type.EqualTo, T_Type.Float, T_Type.For, T_Type.Foreach, T_Type.If, T_Type.Int,
					T_Type.Internal, T_Type.LeftBrace, T_Type.LeftParenthesis, T_Type.LeftSquareBracket,
					T_Type.LessThan, T_Type.LessThanOrEqualTo, T_Type.Long, T_Type.MoreThan,
					T_Type.MoreThanOrEqualTo, T_Type.Namespace, T_Type.New, T_Type.Not,
					T_Type.NotEqualTo, T_Type.Or, T_Type.Override, T_Type.Private,
					T_Type.Protected, T_Type.Public, T_Type.Readonly, T_Type.Return,
					T_Type.RightBrace,T_Type.RightParenthesis, T_Type.RightSquareBracket,
					T_Type.Sealed, T_Type.SemiColon, T_Type.Static, T_Type.String,
					T_Type.Struct, T_Type.Switch, T_Type.Virtual, T_Type.Void, T_Type.While,
					T_Type.Multiplication, T_Type.MultiplyBy, T_Type.SubtractBy, T_Type.Subtraction,
					T_Type.AddBy, T_Type.Addition, T_Type.DivideBy, T_Type.Division,
					T_Type.Increment, T_Type.Decrement,
					T_Type.Space,  T_Type.Tab, T_Type.NewLine, 
					T_Type.CommentOneLine, 
					T_Type.ConstString, T_Type.ConstNumber,
					T_Type.Identifier,
					T_Type.Using
				};
			}
		}
	}
}

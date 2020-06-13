using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace mohamedothman.Compiler
{
	public class LexicalAnalyzer
	{

		protected static IEnumerable<T_Type> Keywords { get { return T_Type.Types.Where(a => a.Families.Any(s => s.Name == T_Family.Keyword.Name)); } }
		protected static IEnumerable<T_Type> Operators { get { return T_Type.Types.Where(a => a.Families.Any(s => s.Name == T_Family.Operator.Name)); } }
		protected static IEnumerable<T_Type> Identifiers { get { return T_Type.Types.Where(a => a.Families.Any(s => s.Name == T_Family.Identifier.Name)); } }
		protected static IEnumerable<T_Type> Constants { get { return T_Type.Types.Where(a => a.Families.Any(s => s.Name == T_Family.Constant.Name)); } }
		protected static IEnumerable<T_Type> Comments { get { return T_Type.Types.Where(a => a.Families.Any(s => s.Name == T_Family.Comment.Name)); } }
		protected static IEnumerable<T_Type> PunctuationMarks { get { return T_Type.Types.Where(a => a.Families.Any(s => s.Name == T_Family.PunctuationMark.Name)); } }
		protected static IEnumerable<T_Type> Whitespaces { get { return T_Type.Types.Where(a => a.Families.Any(s => s.Name == T_Family.Whitespace.Name)); } }
		protected static T_Type Delimiter { get { return T_Type.Types.Single(a => a.Families.Any(s => s.Name == T_Family.Delimiter.Name) ); } }
		protected string _sourceCode { get; set; }
		public LexicalAnalyzer(string sourceCode)
		{
			_sourceCode = sourceCode;
		}
		public string GetRepeatedString(string s, int count)
		{
			var res = "";
			for(int i = 0; i < count; i++)
			{
				res += s;
			}
			return res;
		}
		public IEnumerable<Token> Tokenize()
		{
			var res = _sourceCode;

			
			foreach (var comment in Comments)
			{
				var stringMatchCollection = Regex.Matches(res, T_Type.ConstString.Pattern);
				var stringMatches = new Match[stringMatchCollection.Count];
				stringMatchCollection.CopyTo(stringMatches, 0);
				var matchCollection = Regex.Matches(res, comment.Pattern);
				var matches = new Match[matchCollection.Count];
				matchCollection.CopyTo(matches, 0);
				foreach (Match match in matches)
				{
					if (stringMatches.Any(m => match.Index >= m.Index &&
					((match.Index) <= (m.Index + m.Length))))
						continue;
					if (!(matches.Where(m => !(m.Index == match.Index && m.Length != match.Length))
						.Any(m => match.Index >= m.Index && (match.Index + match.Length) <= (m.Index + m.Length))))
					{
						var before = res.Substring(0, match.Index);
						var current = res.Substring(match.Index, match.Length);
						var after = res.Substring(match.Index + match.Length);
						res = before + GetRepeatedString(Delimiter.Value, match.Length) + after;
					}
				}
			}

			foreach(var identifier in Identifiers)
			{
				var stringMatchCollection = Regex.Matches(res, T_Type.ConstString.Pattern);
				var stringMatches = new Match[stringMatchCollection.Count];
				stringMatchCollection.CopyTo(stringMatches, 0);
				var matchCollection = Regex.Matches(res, identifier.Pattern);
				var matches = new Match[matchCollection.Count];
				matchCollection.CopyTo(matches, 0);
				matches = matches.Reverse().ToArray();
				for (int i = 0; i < matches.Length; i++)
				{
					var match = matches[i];
					if (stringMatches.Any(m => match.Index >= m.Index &&
					((match.Index + match.Length) <= (m.Index + m.Length))))
						continue;
					var before = res.Substring(0, match.Index);
					var current = res.Substring(match.Index, match.Length);
					var after = res.Substring(match.Index + match.Length);
					res = before + Delimiter.Value + current + Delimiter.Value + after;
				}
			}
			
			foreach (var punctuationMark in PunctuationMarks)
			{
				var stringMatchCollection = Regex.Matches(res, T_Type.ConstString.Pattern);
				var stringMatches = new Match[stringMatchCollection.Count];
				stringMatchCollection.CopyTo(stringMatches, 0);
				var matchCollection = Regex.Matches(res, punctuationMark.Pattern);
				var matches = new Match[matchCollection.Count];
				matchCollection.CopyTo(matches, 0);
				matches = matches.Reverse().ToArray();
				for (int i = 0; i < matches.Length; i++)
				{
					var match = matches[i];
					if (stringMatches.Any(m => match.Index >= m.Index &&
					((match.Index + match.Length) <= (m.Index + m.Length))))
						continue;
					var before = res.Substring(0, match.Index);
					var current = res.Substring(match.Index, match.Length);
					var after = res.Substring(match.Index + match.Length);
					res = before + Delimiter.Value + current + Delimiter.Value + after;
				}
			}

			
			foreach (var whitespace in Whitespaces)
			{
				var stringMatchCollection = Regex.Matches(res, T_Type.ConstString.Pattern);
				var stringMatches = new Match[stringMatchCollection.Count];
				stringMatchCollection.CopyTo(stringMatches, 0);
				var matchCollection = Regex.Matches(res, whitespace.Pattern);
				var matches = new Match[matchCollection.Count];
				matchCollection.CopyTo(matches, 0);
				matches = matches.Reverse().ToArray();
				for (int i = 0; i < matches.Length; i++)
				{
					var match = matches[i];
					if (stringMatches.Any(m => match.Index >= m.Index &&
					((match.Index + match.Length) <= (m.Index + m.Length))))
						continue;
					var before = res.Substring(0, match.Index);
					var current = res.Substring(match.Index, match.Length);
					var after = res.Substring(match.Index + match.Length);
					res = before + Delimiter.Value + after;
				}
			}

			
			List<string> leximes = res.Split(new string[] { Delimiter.Value }, StringSplitOptions.RemoveEmptyEntries).ToList();

			
			List<Token> tokens = leximes.Select(a => new Token { Lexeme= a, Type = GetTypeOfLexeme(a) }).ToList();

			return tokens;
		}
		private T_Type GetTypeOfLexeme(string s)
		{
			T_Type type = null;
			type = Keywords.FirstOrDefault(a => Regex.Match(s, a.Pattern).Success);
			if (type != null) return type;
			type = Operators.FirstOrDefault(a => Regex.Match(s, a.Pattern).Success);
			if (type != null) return type;
			type = PunctuationMarks.FirstOrDefault(a => Regex.Match(s, a.Pattern).Success);
			if (type != null) return type;
			type = Constants.FirstOrDefault(a => Regex.Match(s, a.Pattern).Success);
			if (type != null) return type;
			type = Identifiers.FirstOrDefault(a => Regex.Match(s , a.Pattern).Success);
			if (type != null) return type;
			return null;
		}
	}
}

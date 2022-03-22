// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Naming", "INTL0003:Methods PascalCase", Justification = "<Ok to use PascalCase for methods - preferred>")]
[assembly: SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<ok to use underscores in test names &&|| not our files>")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<Pending>")]
[assembly: SuppressMessage("Naming", "INTL0001:Fields _PascalCase", Justification = "<Pending>", Scope = "member", Target = "~F:IntelliTect.TestTools.WildcardPattern._isMatch")]
[assembly: SuppressMessage("Naming", "INTL0001:Fields _PascalCase", Justification = "<Pending>", Scope = "member", Target = "~F:IntelliTect.TestTools.WildcardPattern.s_matchAllIgnoreCasePattern")]
[assembly: SuppressMessage("Naming", "INTL0001:Fields _PascalCase", Justification = "<Pending>", Scope = "member", Target = "~F:IntelliTect.TestTools.WildcardPatternMatcher._characterNormalizer")]
[assembly: SuppressMessage("Naming", "INTL0001:Fields _PascalCase", Justification = "<Pending>", Scope = "member", Target = "~F:IntelliTect.TestTools.WildcardPatternMatcher._patternElements")]
[assembly: SuppressMessage("Naming", "INTL0001:Fields _PascalCase", Justification = "<Pending>", Scope = "member", Target = "~F:IntelliTect.TestTools.WildcardPatternMatcher.CharacterNormalizer._caseInsensitive")]
[assembly: SuppressMessage("Naming", "INTL0001:Fields _PascalCase", Justification = "<Pending>", Scope = "member", Target = "~F:IntelliTect.TestTools.WildcardPatternMatcher.CharacterNormalizer._cultureInfo")]
[assembly: SuppressMessage("Naming", "INTL0001:Fields _PascalCase", Justification = "<Pending>", Scope = "member", Target = "~F:IntelliTect.TestTools.WildcardPatternMatcher.LiteralCharacterElement._literalCharacter")]
[assembly: SuppressMessage("Naming", "INTL0001:Fields _PascalCase", Justification = "<Pending>", Scope = "member", Target = "~F:IntelliTect.TestTools.WildcardPatternMatcher.MyWildcardPatternParser._bracketExpressionBuilder")]
[assembly: SuppressMessage("Naming", "INTL0001:Fields _PascalCase", Justification = "<Pending>", Scope = "member", Target = "~F:IntelliTect.TestTools.WildcardPatternMatcher.MyWildcardPatternParser._characterNormalizer")]
[assembly: SuppressMessage("Naming", "INTL0001:Fields _PascalCase", Justification = "<Pending>", Scope = "member", Target = "~F:IntelliTect.TestTools.WildcardPatternMatcher.MyWildcardPatternParser._patternElements")]
[assembly: SuppressMessage("Naming", "INTL0001:Fields _PascalCase", Justification = "<Pending>", Scope = "member", Target = "~F:IntelliTect.TestTools.WildcardPatternMatcher.MyWildcardPatternParser._regexOptions")]
[assembly: SuppressMessage("Naming", "INTL0001:Fields _PascalCase", Justification = "<Pending>", Scope = "member", Target = "~F:IntelliTect.TestTools.WildcardPatternMatcher.PatternPositionsVisitor._isPatternPositionVisitedMarker")]
[assembly: SuppressMessage("Naming", "INTL0001:Fields _PascalCase", Justification = "<Pending>", Scope = "member", Target = "~F:IntelliTect.TestTools.WildcardPatternMatcher.PatternPositionsVisitor._lengthOfPattern")]
[assembly: SuppressMessage("Naming", "INTL0001:Fields _PascalCase", Justification = "<Pending>", Scope = "member", Target = "~F:IntelliTect.TestTools.WildcardPatternMatcher.PatternPositionsVisitor._patternPositionsForFurtherProcessing")]
[assembly: SuppressMessage("Naming", "INTL0001:Fields _PascalCase", Justification = "<Pending>", Scope = "member", Target = "~F:IntelliTect.TestTools.WildcardPatternMatcher.PatternPositionsVisitor._patternPositionsForFurtherProcessingCount")]
[assembly: SuppressMessage("Naming", "INTL0001:Fields _PascalCase", Justification = "<Pending>", Scope = "member", Target = "~F:IntelliTect.TestTools.WildcardPatternToDosWildcardParser._result")]
[assembly: SuppressMessage("Naming", "INTL0001:Fields _PascalCase", Justification = "<Pending>", Scope = "member", Target = "~F:IntelliTect.TestTools.WildcardPatternToRegexParser._regexOptions")]
[assembly: SuppressMessage("Naming", "INTL0001:Fields _PascalCase", Justification = "<Pending>", Scope = "member", Target = "~F:IntelliTect.TestTools.WildcardPatternToRegexParser._regexPattern")]
[assembly: SuppressMessage("Globalization", "CA1307:Specify StringComparison", Justification = "<Pending>", Scope = "member", Target = "~M:IntelliTect.TestTools.WildcardPattern.IsWildcardChar(System.Char)~System.Boolean")]
[assembly: SuppressMessage("Globalization", "CA1307:Specify StringComparison", Justification = "<Pending>", Scope = "member", Target = "~M:IntelliTect.TestTools.WildcardPattern.NormalizeLineEndings(System.String,System.Boolean)~System.String")]
[assembly: SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "<Pending>", Scope = "member", Target = "~M:IntelliTect.TestTools.WildcardPatternMatcher.PatternPositionsVisitor.#ctor(System.Int32)")]
[assembly: SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "<Pending>", Scope = "member", Target = "~M:IntelliTect.TestTools.WildcardPatternMatcher.PatternPositionsVisitor.Add(System.Int32)")]
[assembly: SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "<Pending>", Scope = "member", Target = "~M:IntelliTect.TestTools.WildcardPatternMatcher.PatternPositionsVisitor.MoveNext(System.Int32@)~System.Boolean")]


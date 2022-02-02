// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Globalization", "CA1307:Specify StringComparison", Justification = "Don't need to consider globalization")]
[assembly: SuppressMessage("Globalization", "CA1304:Specify CultureInfo", Justification = "Don't need to consider globalization")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "We know better than to trust the compiler on 'static'")]

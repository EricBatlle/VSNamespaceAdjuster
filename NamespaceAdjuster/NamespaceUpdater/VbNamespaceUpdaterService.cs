using System.Text.RegularExpressions;

namespace NamespaceUpdater
{
	internal class VbNamespaceUpdaterService : LogicFileNamespaceUpdaterService
	{
		protected override string SupportedFileExtension => ".vb";

		protected override string NamespaceStartLimiter => string.Empty;

		protected override string NamespaceEndLimiter => "End Namespace";

        protected override Match FindNamespaceMatch(string fileContent) =>
			Regex.Match(fileContent, @"[\r\n|\r|\n]?Namespace\s(.+)");

		protected override MatchCollection FindUsingMatches(string fileContent) =>
			Regex.Matches(fileContent, @"\n?Imports\s(.+)");

		protected override string BuildNamespaceLine(string desiredNamespace) => "Namespace " + desiredNamespace;
	}
}

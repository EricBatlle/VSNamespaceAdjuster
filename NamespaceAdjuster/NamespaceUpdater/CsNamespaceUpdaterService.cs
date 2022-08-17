using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NamespaceBuilder
{
	internal class CsNamespaceUpdaterService : LogicFileNamespaceUpdaterService
	{
		protected override string NamespaceStartLimiter => "{" + NewLine;

		protected override string NamespaceEndLimiter => "}";

		protected override Match FindNamespaceMatch(string fileContent) =>
			Regex.Match(fileContent, @"[\r\n|\r|\n]?namespace\s(.+)[\r\n|\r|\n]*{");

		protected override MatchCollection FindUsingMatches(string fileContent) =>
			Regex.Matches(fileContent, @"\n?using\s(.+);");
		protected override string BuildNamespaceLine(string desiredNamespace) => "namespace " + desiredNamespace;

	}
}

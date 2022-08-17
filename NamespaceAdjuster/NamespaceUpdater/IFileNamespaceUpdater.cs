using System.IO;

namespace NamespaceBuilder
{
	internal interface IFileNamespaceUpdater
	{
		bool UpdateFileNamespace(ref string fileContent, string desiredNamespace);
	}
}

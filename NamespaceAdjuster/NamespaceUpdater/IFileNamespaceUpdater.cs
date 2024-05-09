namespace NamespaceUpdater
{
	internal interface IFileNamespaceUpdater
	{
		bool UpdateFileNamespace(ref string fileContent, string desiredNamespace);
	}
}

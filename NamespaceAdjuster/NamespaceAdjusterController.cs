using NamespaceUpdater;
using System.IO;

class NamespaceAdjusterController
{
	FileNamespaceUpdaterProvider namespaceUpdaterProvider;

	public NamespaceAdjusterController()
	{
		namespaceUpdaterProvider = new FileNamespaceUpdaterProvider();
	}

	public void FixNamespace(string desiredNamespace, string filePath)
	{
		if (!File.Exists(filePath) /*|| IgnoreFile(filePath)*/)
		{
			return;
		}

		IFileNamespaceUpdater namespaceUpdater = namespaceUpdaterProvider.GetUpdater(filePath);

		var encoding = Extensions.PathExtensions.GetEncoding(filePath);
		var fileContent = File.ReadAllText(filePath, encoding);
		var updated = namespaceUpdater.UpdateFileNamespace(ref fileContent, desiredNamespace);

		if (updated)
		{
			File.WriteAllText(filePath, fileContent, encoding);
		}
	}
}


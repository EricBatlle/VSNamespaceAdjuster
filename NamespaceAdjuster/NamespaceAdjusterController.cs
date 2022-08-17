using NamespaceUpdater;
using System.IO;

class NamespaceAdjusterController
{
	private IFileNamespaceUpdater namespaceUpdater;
	public NamespaceAdjusterController()
	{
		namespaceUpdater = new CsNamespaceUpdaterService();
	}

	public void FixNamespace(string desiredNamespace, string filePath)
	{
		if (!File.Exists(filePath) /*|| IgnoreFile(filePath)*/)
		{
			return;
		}

		var encoding = Extensions.PathExtensions.GetEncoding(filePath);

		var fileContent = File.ReadAllText(filePath, encoding);

		var updated = namespaceUpdater.UpdateFileNamespace(ref fileContent, desiredNamespace);

		if (updated)
		{
			File.WriteAllText(filePath, fileContent, encoding);
		}
	}
}


using System;
using System.Collections.Generic;
using System.IO;

namespace NamespaceUpdater
{
	internal class FileNamespaceUpdaterProvider
	{
		private List<LogicFileNamespaceUpdaterService> updaterServices = new List<LogicFileNamespaceUpdaterService>();

		public FileNamespaceUpdaterProvider()
		{
			updaterServices.Add(new CsNamespaceUpdaterService());
			updaterServices.Add(new VbNamespaceUpdaterService());
		}

		public IFileNamespaceUpdater GetUpdater(string filePath)
		{
			string fileExtension = Path.GetExtension(filePath);

			foreach (var updaterService in updaterServices)
			{
				if (updaterService.SupportsFileExtension(fileExtension))
				{
					return updaterService;
				}
			}

			throw new Exception($"Error updating file {filePath}:\nFile extension {fileExtension} not supported.");
		}
	}
}

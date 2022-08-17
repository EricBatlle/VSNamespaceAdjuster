using Community.VisualStudio.Toolkit;
using Microsoft.VisualStudio.Shell;
using NamespaceAdjuster.Windows;
using Task = System.Threading.Tasks.Task;

namespace NamespaceAdjuster
{
	[Command(PackageIds.AdjustNamespaceCommand)]
	internal sealed class AdjustNamespaceCommand : BaseCommand<AdjustNamespaceCommand>
	{
		protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
		{
			InputFieldWindow inputFieldWindow = new InputFieldWindow();
			await inputFieldWindow.ShowAsync();
		}
	}
}

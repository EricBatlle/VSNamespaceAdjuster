using Microsoft.Internal.VisualStudio.PlatformUI;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using SolutionSelection;
using System;
using System.Windows;

namespace NamespaceAdjuster.Windows
{
	/// <summary>
	/// Lógica de interacción para Window1.xaml
	/// </summary>
	public partial class InputFieldWindow : Window
	{
		ISolutionSelectionService solutionSelectionService;

		public InputFieldWindow()
		{
			solutionSelectionService = new SolutionSelectionService();
			InitializeComponent();
		}

		private void OkButton_Click(object sender, RoutedEventArgs e)
		{
			string desiredNamespace = this.NamespaceInputField.Text;
			RenameFiles(desiredNamespace);
			this.Close();
		}

		private void RenameFiles(string desiredNamespace)
		{
			NamespaceAdjusterController namespaceAdjuster = new NamespaceAdjusterController();
			foreach (string filePath in solutionSelectionService.GetSelectedItemsPaths())
			{
				namespaceAdjuster.FixNamespace(desiredNamespace, filePath);
			}
		}

		public async System.Threading.Tasks.Task ShowAsync()
		{
			await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
			IVsUIShell uiShell = (IVsUIShell)await ServiceProvider.GetGlobalServiceAsync(typeof(SVsUIShell));
			InputFieldWindow dialogWindow = new InputFieldWindow();
			//get the owner of this dialog  
			IntPtr hwnd;
			uiShell.GetDialogOwnerHwnd(out hwnd);
			dialogWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			uiShell.EnableModeless(0);
			try
			{
				WindowHelper.ShowModal(dialogWindow, hwnd);
			}
			catch (Exception exc)
			{
				System.Windows.MessageBox.Show("Opening failed: " + exc.Message, "Error", MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
			}
			finally
			{
				// This will take place after the window is closed.
				uiShell.EnableModeless(1);
			}
		}
	}
}

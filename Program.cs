using System;
using System.Security.Principal;
using System.Windows.Forms;

static class Program {
	
	[STAThread]
	static void Main() {
		// Enable visual styles.
		Application.EnableVisualStyles();
		
		// Check for administrative privilages.
		if (!(new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator)) {
			MessageBox.Show("Administrative privilages required.", "Tweaky", MessageBoxButtons.OK, MessageBoxIcon.Information);
			return;
		}
		
		// Display application window.
		Application.Run(new FormMain());
	}
	
}

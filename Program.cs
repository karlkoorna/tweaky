using System;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;

static class Program {
	
	[STAThread]
	static void Main() {
		Application.EnableVisualStyles();
		
		if (!(new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator)) {
			MessageBox.Show("Administrative privilages required.", "Tweaky", MessageBoxButtons.OK, MessageBoxIcon.Information);
			return;
		}

		Directory.CreateDirectory("Tweaky");
		Application.Run(new FormMain());
	}
	
}

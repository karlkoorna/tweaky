using System;
using System.Windows.Forms;

static class Program {
	
	[STAThread]
	static void Main() {
		Application.EnableVisualStyles();
		Application.Run(new FormMain());
	}

}

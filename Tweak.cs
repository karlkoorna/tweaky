using Microsoft.Win32;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

class Tweak {

	[DllImport("kernel32")]
	static extern int GetPrivateProfileString(string section, string key, string defaultValue, StringBuilder value, int size, string path);

	string Path { get; set; }
	string WorkingDirectory { get; set; }

	public bool Enabled { get; set; }
	public string Category { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }

	public Tweak(string path) {

		Path = path;
		WorkingDirectory = System.IO.Path.GetFullPath(System.IO.Path.GetDirectoryName(path));
		
		Enabled = Status();
		Category = path.Substring(7, path.Substring(7).IndexOf(@"\"));
		Name = Read("Info", "Name");
		Description = Read("Info", "Description");

	}

	/// <summary>
	/// Read value from config file.
	/// </summary>
	string Read(string section, string key) {
		StringBuilder value = new StringBuilder(255);
		GetPrivateProfileString(section, key, "", value, 255, Path);
		return value.ToString();
	}

	/// <summary>
	/// Run toggle script.
	/// </summary>
	public void Toggle() {
		
		ProcessStartInfo startInfo = new ProcessStartInfo() {
			FileName = "cmd",
			Arguments = "/C " + Read("Toggle", !Enabled ? "Enable" : "Disable").Replace("{0}", WorkingDirectory),
			WorkingDirectory = WorkingDirectory,
			CreateNoWindow = true,
			UseShellExecute = false
		};
		
		// Add environmental variable indicating state to child processes.
		startInfo.EnvironmentVariables["TWEAKY"] = (Enabled ? 0 : 1).ToString();

		// Start and wait for script.
		Process.Start(startInfo).WaitForExit();

		// Update enabled state.
		Enabled = Status();

	}

	/// <summary>
	/// Run status script.
	/// </summary>
	public bool Status() {

		switch (Read("Status", "Type")) {
			
			case "registry":

				object value = Registry.GetValue(Read("Status", "Path"), Read("Status", "Key"), null);

				if (value == null) return false;

				return (new Regex(Read("Status", "Value"))).IsMatch(value.ToString());

			case "file":

				string path = Read("Status", "Path");

				if (!File.Exists(path)) return false;

				return (new Regex(Read("Status", "Value"))).IsMatch(File.ReadAllText(path));

			case "script":

				Process process = Process.Start(new ProcessStartInfo("cmd", "/C " + Read("Status", "Command")) {
					WorkingDirectory = WorkingDirectory,
					CreateNoWindow = true,
					UseShellExecute = false
				});

				process.Start();
				process.WaitForExit();

				return process.ExitCode.ToString() == Read("Status", "Value");

		}

		return false;

	}
	
}

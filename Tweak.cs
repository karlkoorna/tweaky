using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

class Tweak {

	[DllImport("kernel32")]
	static extern int GetPrivateProfileString(string section, string key, string defaultValue, StringBuilder value, int size, string path);

	string Path { get; set; }
	string WorkingDirectory { get; set; }

	public string State { get; set; }
	public string Category { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }

	public Tweak(string path) {
		Path = path;
		WorkingDirectory = System.IO.Path.GetFullPath(System.IO.Path.GetDirectoryName(path));
		
		State = Status();
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
			Arguments = "/C " + Read("Toggle", State == "Disabled" || State == "Indeterminate" ? "Enable" : "Disable").Replace("{0}", WorkingDirectory),
			WorkingDirectory = WorkingDirectory,
			CreateNoWindow = true,
			UseShellExecute = false
		};
		
		// Add environmental variable indicating new state to child process.
		startInfo.EnvironmentVariables["TWEAKY"] = (State == "Enabled" ? 0 : 1).ToString();

		// Start and wait for script.
		Process.Start(startInfo).WaitForExit();

		// Update enabled state.
		State = Status();
	}

	/// <summary>
	/// Run status script.
	/// </summary>
	public string Status() {
		// Return indeterminate if status not configured.
		if (Read("Status", "Command") == "") return "Indeterminate";

		// Start process.
		Process process = Process.Start(new ProcessStartInfo("cmd", "/C " + Read("Status", "Command")) {
			WorkingDirectory = WorkingDirectory,
			CreateNoWindow = true,
			UseShellExecute = false,
			RedirectStandardOutput = true
		});
		
		// Wait for process to finish.
		process.WaitForExit();
		
		// Compare output to Regex.
		return (new Regex(Read("Status", "Value"))).IsMatch(Read("Status", "Check") == "output" ? process.StandardOutput.ReadToEnd().Replace("\r\n", "\n") : process.ExitCode.ToString()) ? "Enabled" : "Disabled";
	}
	
}

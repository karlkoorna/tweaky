using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

enum TweakStatus {
	ENABLED = 1,
	DISABLED = 0,
	INDETERMINATE = 2
}

class Tweak {
	
	[DllImport("kernel32", CharSet = CharSet.Unicode)]
	private static extern int GetPrivateProfileString(string section, string key, string defaultValue, StringBuilder value, int size, string path);

	private readonly string File;
	private readonly string Directory;

	public string Name { get; set; }
	public string Description { get; set; }
	public string Category { get; set; }
	
	public TweakStatus Status;

	public int State {
		get => (int) Status;
	}

	public Tweak(string path) {
		File = path;
		Directory = System.IO.Path.GetFullPath(System.IO.Path.GetDirectoryName(path));

		Name = Read("Info", "Name");
		Description = Read("Info", "Description");
		Category = path.Substring(7, path.Substring(7).LastIndexOf(@"\")).Replace(@"\", "/");
		Status = Update();
	}

	string Read(string section, string key, string defaultValue = "") {
		StringBuilder value = new StringBuilder(255);
		GetPrivateProfileString(section, key, defaultValue, value, 255, File);
		return value.ToString();
	}

	public void Toggle() {
		ProcessStartInfo startInfo = new ProcessStartInfo() {
			FileName = "cmd",
			Arguments = "/C " + Read("Toggle", Status == TweakStatus.DISABLED || Status == TweakStatus.INDETERMINATE ? "Enable" : "Disable").Replace("{}", Directory),
			WorkingDirectory = Directory,
			UseShellExecute = false,
			CreateNoWindow = true
		};

		startInfo.EnvironmentVariables["TWEAKY"] = (1 - Status).ToString();

		Process.Start(startInfo).WaitForExit();
		Status = Update();
	}

	public TweakStatus Update() {
		// Return indeterminate if status section not configured.
		if (Read("Status", "Command").Trim().Length == 0) return TweakStatus.INDETERMINATE;

		Process process = Process.Start(new ProcessStartInfo("cmd", "/C " + Read("Status", "Command")) {
			RedirectStandardOutput = true,
			WorkingDirectory = Directory,
			UseShellExecute = false,
			CreateNoWindow = true
		});

		process.WaitForExit();
		return (new Regex(Read("Status", "Value"))).IsMatch(Read("Status", "Type") == "output" ? process.StandardOutput.ReadToEnd().Replace("\r\n", "\n") : process.ExitCode.ToString()) ? TweakStatus.ENABLED : TweakStatus.DISABLED;
	}

}

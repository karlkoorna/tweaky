using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

class Tweak {

	public enum TweakStatus {
		Enabled = 1,
		Disabled = 0,
		Indeterminate = 2
	}

	[DllImport("kernel32", CharSet = CharSet.Unicode)]
	private static extern int GetPrivateProfileString(string section, string key, string defaultValue, StringBuilder value, int size, string path);

	private readonly string PathDirectory;
	private readonly string PathFile;

	public string Name { get; }
	public string Description { get; }
	public string Category { get; }

	public TweakStatus Status;

	public int State => (int) Status;

	public Tweak(string path) {
		PathDirectory = System.IO.Path.GetFullPath(Path.GetDirectoryName(path));
		PathFile = path;

		Name = Read("Info", "Name");
		Description = Read("Info", "Description");
		Category = path.Substring(7, path.Substring(7).LastIndexOf(@"\")).Replace(@"\", "/");
		Status = Update();
	}

	private string Read(string section, string key, string defaultValue = "") {
		var value = new StringBuilder(255);
		GetPrivateProfileString(section, key, defaultValue, value, 255, PathFile);
		return value.ToString();
	}

	public void Toggle() {
		var startInfo = new ProcessStartInfo() {
			FileName = "cmd",
			Arguments = "/C " + Read("Toggle", Status == TweakStatus.Disabled || Status == TweakStatus.Indeterminate ? "Enable" : "Disable").Replace("{}", PathDirectory),
			WorkingDirectory = PathDirectory,
			UseShellExecute = false,
			CreateNoWindow = true
		};

		startInfo.EnvironmentVariables["TWEAKY"] = (1 - Status).ToString();

		Process.Start(startInfo).WaitForExit();
		Status = Update();
	}

	private TweakStatus Update() {
		// Return indeterminate if status section not configured.
		if (Read("Status", "Command").Trim().Length == 0) return TweakStatus.Indeterminate;

		var process = Process.Start(new ProcessStartInfo("cmd", "/C " + Read("Status", "Command")) {
			RedirectStandardOutput = true,
			WorkingDirectory = PathDirectory,
			UseShellExecute = false,
			CreateNoWindow = true
		});

		process.WaitForExit();
		return (new Regex(Read("Status", "Value"))).IsMatch(Read("Status", "Type") == "output" ? process.StandardOutput.ReadToEnd().Replace("\r\n", "\n") : process.ExitCode.ToString()) ? TweakStatus.Enabled : TweakStatus.Disabled;
	}

}

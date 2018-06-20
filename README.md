# Tweaky
A collection of useful tweaks for Windows 10.

Tweaks are defined by INI files stored in a category folder (including its subfolders) in the Tweaky folder next to the executable. After build the predefined tweaks in the `Tweaks` folders will be copied over.

Example:

* Tweaky.exe
* /Tweaky
	* /[category]
		* [tweak].ini

Tweak files consist of 3 sections:

**Info**

The `Info` section makes a tweak recognizable in the UI.

```ini
[Info]
Name=Disable ducking
Description=Disable automatic volume adjustment.
```

**Toggle**

The `Toggle` section defines console commands to be executed on toggle. Before execution:
1. `{0}` will be replaced with the full path of the current directory.
2. Environmental variable `TWEAKY` with value `0` or `1` indicating new state will be added to the child process.

```ini
[Toggle]
Enable=regedit /S "{0}/enable.reg"
Disable=regedit /S "{0}/disable.reg"
```

**Status**

The `Status` section defines the console command whose output (`output`) or exit code (`code`) to be checked against the provided Regex value.

```ini
[Status]
Command=status.bat
Check=code
Value=1
```

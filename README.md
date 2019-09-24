# Tweaky
GUI for Windows tweaks.

## Usage

Tweaks are defined by INI files stored in a category folder (including its subfolders) in the Tweaky folder next to the executable. Included tweaks must be manually copied from `Tweaks/` to `Tweaky/` next to the executable.

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
Name=My amazing tweak
Description=Disables an annoying feature.
```

**Toggle**

The `Toggle` section defines console commands to be executed on toggle. Before execution:
1. `{}` will be replaced with an absolute path to the script directory.
2. Environmental variable `TWEAKY` with value `0` or `1` indicating new state will be set for the started process.

```ini
[Toggle]
Enable=enable.bat
Disable=disabe.bat
```

**Status**

The `Status` section defines the console command which's output (`output`) or exit code (`code`) to be checked against the provided Regex value. If there is a match the tweak will be considered enabled. If the section is not present the tweak will be treated not toggleable and can only be enabled.

```ini
[Status]
Command=status.bat
Check=code
Value=1
```

## Known issues

* Disabling a tweak reverts to a defined (not previous) setting.
* Unsortable columns.

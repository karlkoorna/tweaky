# Tweaky
GUI for Windows tweaks.

## Usage

Tweaks are defined by INI files stored in a category folder (including its subfolders) in the Tweaky folder next to the executable.

Example file structure:

```
Tweaky.exe
Tweaky/
    [Category]/
        [Tweak].ini
        [Subcategory]/
            [Tweak].ini
```

Tweak files consist of 3 sections:

**Info**

Makes a tweak recognizable in the UI.

```ini
[Info]
Name=My amazing tweak
Description=Disables an annoying feature.
```

**Toggle**

Defines commands to be executed on toggle.

Before toggling:
1. `{}` will be replaced with the absolute path to the script directory.
2. Environment variable `TWEAKY` with value `0` or `1` indicating new state will be set for the started process.

```ini
[Toggle]
Enable=enable.bat
Disable=disabe.bat
```

**Status**

Defines the tweak's status in the UI.

The command's output (`output`) or exit code (`code`) will be checked against the provided Regex value. If there is a match the tweak will be considered enabled. If the section is not present the tweak will be treated not toggleable and can only be enabled.

```ini
[Status]
Command=status.bat
Type=output
Value=(success|ok)
```

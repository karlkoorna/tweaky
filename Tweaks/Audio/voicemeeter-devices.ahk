CoordMode, Mouse, Client

Loop, 2 {
	
	Run, mmsys.cpl
	WinWait, Sound
	
	ControlGet Output, List, Col2, SysListView321, Sound
	Devices := StrSplit(Output, "`n")
	
	Loop % Devices.MaxIndex() {
		if (Devices[A_Index] = "VB-Audio VoiceMeeter VAIO") {
			ControlSend, SysListView321, {Down %A_Index%}
		}
	}
	
	Sleep, 10
	
	ControlClick, &Set Default
	ControlClick, Ok
	
	Click, 100, 20 
	
}

WinClose, Sound

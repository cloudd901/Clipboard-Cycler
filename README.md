# Clipboard Cycler
Cycle through Text using Hotkeys.

![Icon](https://github.com/cloudd901/Clipboard-Cycler/blob/master/Clipboard%20Cycler/CC.ico)

I created my initial Clipboard Cycler using AutoIT script.
Thought that it was about time to update it using C#.
Split parts of this project into DLL files that can be found in my other repositories.
[HotkeyCommands.dll](https://github.com/cloudd901/HotkeyCommands)
[SendInputKeyCommands.dll](https://github.com/cloudd901/SendInputKeyCommands)
[MouseCommands.dll](https://github.com/cloudd901/MouseCommands)

</br></br>
<b>Cycle Keys</b>
</br></br>

F1 will copy text into the Cycler.
 - It will send a Ctrl+C and grab the data from the Clipboard.
 - It will auto separate Newlines and Tabs so it will work fine with Excel.
 
F2 will paste the text.
 - It will send either a Ctrl+V or individual keys depending on your setting.
 - Individual keys work well for programs or folders that you need to simulate typing.
 - It will paste the data shown in the box then automatically move to the next item.
 - It will stop once the last item has been pasted.
 
F3 will send the Enter key.
 - Useful when using paste to do searches or data entry.
 
(Optional) Esc will doubleclick the mouse.
 - Useful for highlighting sections of text to replace.

</br></br>
<b>Run Features</b>
</br></br>

Some F keys can be used to run applications such as F4 on the 2nd and 3rd Forms.
 - Full path must be entered without quotes if file is not in the same directory.
 - Parameters can be used by putting them in doublequotes and comma separated.
 - Example: [C:\Program Files\Internet Explorer\iexplore.exe "google.com, msn.com"]
 - Example: [taskkill "/f, /im, notepad.exe"]

</br></br>
<b>Other Paste Features</b>
</br></br>

Other F keys can be used to simply paste text entered in the adjacent textbox.
 - Any text is allowed except the backquote( ` ) as it is used for saving and retrieving data.

When using the SendKeystrokes Setting; you can send special keys by using brackets { }.
 - Example: To use a Paste key as an Enter key, use {Enter}.
 - Other keys can be chained together such as calling {F5} from F6.
   - Example: [Text{Tab}{F8}{Enter}]
 - You can also send delays by entering a bracketed number such as {2} for a 2 second delay.

</br></br>
<b>Known Issues</b>
</br></br>

Depending on where you launch the Clipboard Cycler, you may get an 'Open File Security Warning'.
If so, the application will not automatically reopen when switching Window types.

When using Paste Only mode, some workstations will not allow F12 as a Hotkey.
The program will the attempt to use {CTRL}F12, {Shift}F12, then {ALT}F12 as a backup Hotkey.

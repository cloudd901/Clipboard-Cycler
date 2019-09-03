# Clipboard Cycler
Cycle through Text using Hotkeys.

I created my initial Clipboard Cycler using AutoIT script.
Thought that it was about time to update it using C#.


Cycle Keys -
 
 F1 will copy text into the Cycler.
 - It will send a Ctrl+C and grab the data from the Clipboard.
 - It will auto separate Newlines and Tabs so it will work fine with Excel.
 
 F2 will paste the text.
 - It will send either a Ctrl+V or individual keys depending on your setting.
 - Individual keys work well for programs or folders that you need to simulate typing.
 - It will paste the data shown in the box then automatically move to the next item.
 - It will stop once the last item has been pasted.
 
 F3 will send the Enter key.
 - Usefull when using paste to do searches or data entry.
 
 (Optional) Esc will doubleclick the mouse.
 - Usefull for highlighting sections of text to replace.
 
 
Run Features -

 Some F keys can be used to run applications such as F4 on the 2nd and 3rd Forms.
 - Full path must be entered without quotes if file is not in the same directory.
 - Parameters can be used by putting them in doublequotes and comma separated.
 - Example: [C:\Program Files\Internet Explorer\iexplorer.exe "google.com, msn.com"]

 Other F keys can be used to simply paste text entered in the adjacent textbox.
 - Any text is allowed except the backquote(`)
 - That key is used for saving and retrieving data when the application is closed.

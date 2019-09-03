# Clipboard Cycler
Cycle through Text using Hotkeys.

I created my initial Clipboard Cycler using AutoIT script.
Thought that it was about time to update it using C#.


 - Main Keys -
 
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
 
 
 - Other Features -
 

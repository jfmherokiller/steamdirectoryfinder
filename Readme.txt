Mountfix Installer For Obsidian Conflict:

Original manual workaround solution discovered by raidensnake (OC Beta) & Neico (OC Dev)

Original LUA Mountfix by Neico (OC Dev)

Improved C# version Coded & Debugged from scratch by mrchemist (OC Beta)
Uses .NET Framework 4.5
Digitally Codesigned by raidensnake (OC Beta)

Lead Testing & Debugging:
raidensnake (OC Beta)
mrchemist (OC Beta)

Testers:
Shana (OC Dev Leader)
Maestro Fénix (OC Beta)


Special Thanks:
Neico (OC Dev)
Shana (OC Dev Leader)
Obsidian Conflict Development Team
Obsidian Conflict Community


Confirmed Tested Client OS:

Windows 7 32/64-bit SP1 All Editions
Windows 8/8.1 32/64-bit All Editions
Windows 10 Tech Preview #2 32/64-bit All Editions

Confirmed Tested Server OS:

Windows Server 2008/R2 64-bit All Editions
Windows Server 2012/R2 64-bit All Editions
Windows Server 10 Tech Preview #2 64-Bit All Editions

Requirements:
.NET framework 4.5
Download Link: http://www.microsoft.com/en-gb/download/details.aspx?id=30653

Features:
Client & Server-side mount fixing
Client-side mount loading by writing blank files into the obsidian/mounts folder
Server-side mount download & installation
Server-side folder cleanup
Command-Line options for Installer Intergration

Usage:

Double Clicking Method:

Client side:
when prompted type client and press enter, the mountfix will run the process automaticly.

Server side:
When prompted type server and press enter
a dialogue will ask for the installation location.
Enter the location including the obsidian folder in the path using quotes " and press enter. eg. "c:\obsidian conflict\obsidian"
Please Note: The obsidian folder will not be touched only the path that leads to it will be used for the mounts eg. "c:\obsidian conflict" during the installation process.
A new window will appear asking for a valid steam username and password. To proceed enter your steam username and password and click install server. The mountfix will begin the process.

PRIVACY & DATA PROTECTION LEGAL DISCLAIMER: 
The steam username and password that is requested by the mountfix is only ever used for the login to Official Valve SteamCMD background commands and is never logged or stored in any way shape or form.
The login details entered are automaticly purged when the mountfix has completed the SteamCMD downloading tasks.
We respect people's privacy and data protection.


Command Line Method:

Please Note: These commands can also be used for installer integration.

The usage commands are available by typing the command -help and pressing enter

Client side:

to run the mount fix use cmd to point to the obsidian folder and type mountfix.exe -client

Example:

cd "c:\program files (x86)\steam\steamapps\sourcemod\obsidian"

mountfix.exe -client

Just like the double click method the process will be automated

Server side:

To run the server side commands, use the following syntax on cmd -server "<steammountfolder\obsidian>" steamusername steampassword

Example:

cd c:\mountfix

mountfix.exe -server "c:\obsidian conflict\obsidian" steamusername steampassword

Just like before in the earlier disclaimer. The login details used are only used for SteamCMD commands and are never logged or stored in any way shape or form.
;InnoSetupVersion=5.3.9 (Unicode)

[Setup]
AppName=Obsidian Conflict Beta 0.1.3.5 hotfix+mountfix Full
AppVerName=Obsidian Conflict Beta 0.1.3.5 hotfix+mountfix Full
AppVersion=1.35
AppPublisher=Obsidian Conflict Team
AppPublisherURL=http://obsidianconflict.net
AppSupportURL=http://obsidianconflict.net/?page=support
AppUpdatesURL=http://obsidianconflict.net/?page=news
DefaultDirName={code:MyInstallPath}
DefaultGroupName=Obsidian Conflict
UninstallDisplayName=Obsidian Conflict Beta 1.35 Full
OutputBaseFilename=oc-beta1.35_full
PrivilegesRequired=admin
AllowNoIcons=yes
CompressionThreads=2
UninstallDisplaySize=1337
Compression=lzma2
SetupIconFile=obsidian.ico
EnableDirDoesntExistWarning=True
RestartIfNeededByRun=False
AlwaysShowDirOnReadyPage=yes

[Run]
;Filename: "{tmp}\setup.exe"; Parameters: "/DIR=""{app}"" /verysilent /group=""{groupname}"""; Flags: skipifdoesntexist; StatusMsg: "Installing  'Obsdian Conflict - Custom PlayerModels'"; MinVersion: 0.0,5.0
Filename: "{app}\mountfix\mountfix.exe"; Parameters: "-client"; Flags: waituntilterminated; Components: client
Filename: "{app}\mountfix\mountfix.exe"; Parameters: "-server ""{app}"" {code:GetUsername} {code:GetPassword} {code:GetSteamAuth} ""{code:GetHl2},{code:GetHl2ep1},{code:Getlostcoast},{code:GetHl2ep2},{code:GetHl1},{code:Getcstrike},{code:Getdod},0"""; Flags: waituntilterminated hidewizard; Components: server

[Icons]
Name: "{group}\Obsidian Conflict Beta 1.35"; Filename: "{reg:HKCU\Software\Valve\Steam,SteamExe}"; WorkingDir: "{reg:HKCU\Software\Valve\Steam,SteamPath}"; IconFilename: "{reg:HKCU\Software\Valve\Steam,SteamPath}\obsidian.ico"; IconIndex: 0; Parameters: "-gameidlaunch 218 -game ""{app}"""; MinVersion: 0.0,5.0; Components: Client
Name: "{group}\{cm:ProgramOnTheWeb,Website}"; Filename: "http://obsidianconflict.net"; MinVersion: 0.0,5.0
Name: "{group}\{cm:UninstallProgram,UnInstall Obsidian Conflict Beta 1.35 Full}"; Filename: "{uninstallexe}"; MinVersion: 0.0,5.0
Name: "{commondesktop}\Obsidian Conflict Beta 1.35"; Filename: "{reg:HKCU\Software\Valve\Steam,SteamExe}"; WorkingDir: "{reg:HKCU\Software\Valve\Steam,SteamPath}"; IconFilename: "{reg:HKCU\Software\Valve\Steam,SteamPath}\obsidian.ico"; Parameters: "-gameidlaunch 218 -game ""{app}"""; MinVersion: 0.0,5.0; Components: Client; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\Obsidian Conflict Beta 1.35"; Filename: "{reg:HKCU\Software\Valve\Steam,SteamExe}"; WorkingDir: "{reg:HKCU\Software\Valve\Steam,SteamPath}"; IconFilename: "{reg:HKCU\Software\Valve\Steam,SteamPath}\obsidian.ico"; Parameters: "-gameidlaunch 218 -game ""{app}"""; MinVersion: 0.0,5.0; Components: Client; Tasks: quicklaunchicon

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Components: "Client"; MinVersion: 0.0,5.0; 
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Components: "Client"; MinVersion: 0.0,5.0; 

[Components]
Name: "client"; Description: "Client Files"; Types: client; MinVersion: 0.0,5.0
Name: "server"; Description: "Server"; Types: server; MinVersion: 0.0,5.0

[Types]
Name: "client"; Description: "Client Installation (Steam)"; MinVersion: 0.0,5.0
Name: "server"; Description: "Server Installation (HLDS)"; MinVersion: 0.0,5.0

[CustomMessages]

en.NameAndVersion=%1 version %2
en.AdditionalIcons=Additional icons:
en.CreateDesktopIcon=Create a &desktop icon
en.CreateQuickLaunchIcon=Create a &Quick Launch icon
en.ProgramOnTheWeb=%1 on the Web
en.UninstallProgram=Uninstall %1
en.LaunchProgram=Launch %1
en.AssocFileExtension=&Associate %1 with the %2 file extension
en.AssocingFileExtension=Associating %1 with the %2 file extension...
IssiLanguageVersion=0x05010000
IssiTxtScriptBackup=YOU HAVE TO MAKE BACKUPS OF YOUR SCRIPTS!!!
IssiTxtScriptSavePath=Select where %1 has to be saved.
IssiTxtFileExtractSuccess=File extracted.
IssiTxtFileCopyFailed=Failed to copy file.
IssiTxtFileExtractFailed=Failed to extract file.
IssiTxtProdAlreadyInstalledPath=%1 is already installed in %2
IssiTxtProdNotInstalled=%1 is not installed.
IssiTxtDownloadingProd=Downloading: %1
IssiTxtDownloadingPleaseWait=Please wait while Setup is downloading %1 to your computer.
IssiTxtDownloadingFailed=Setup could not download %1. Try again later or download and install %1 manually.%n%nSetup will now continue installing normally.
IssiTxtLicencePrintOnDefaultPrinter=Do you want to print License to default printer?
IssiTxtLicencePrintFailed=Problems printing License file!
IssiTxtLicenceExtractFailed=Problems extracting License file!
IssiTxtLicencePrintButton=&Print License
IssiTxtAboutButton=&About...
IssiTxtProdUpdated=The current installation of %1%nis already up to date.
IssiRequiresNet=This software requires the Microsoft .NET Framework %1.%n%nPlease use Windows Update to install this version,%nand then re-run the setup program.
de.NameAndVersion=%1 Version %2
de.AdditionalIcons=Zusätzliche Symbole:
de.CreateDesktopIcon=&Desktop-Symbol erstellen
de.CreateQuickLaunchIcon=Symbol in der Schnellstartleiste erstellen
de.ProgramOnTheWeb=%1 im Internet
de.UninstallProgram=%1 entfernen
de.LaunchProgram=%1 starten
de.AssocFileExtension=&Registriere %1 mit der %2-Dateierweiterung
de.AssocingFileExtension=%1 wird mit der %2-Dateierweiterung registriert...
de.IssiLanguageVersion=0x05010000
de.IssiTxtScriptBackup=SIE MÜSSEN EIN BACKUP IHRER SKRIPTE ERSTELLEN!!!
de.IssiTxtScriptSavePath=Wählen Sie den Pfad, unter dem %1 gespeichert werden soll.
de.IssiTxtFileExtractSuccess=Datei extrahiert.
de.IssiTxtFileCopyFailed=Datei konnte nicht kopiert werden.
de.IssiTxtFileExtractFailed=Datei konnte nicht extrahiert werden.
de.IssiTxtProdAlreadyInstalledPath=%1 ist bereits in %2 installiert.
de.IssiTxtProdNotInstalled=%1 ist nicht installiert.
de.IssiTxtDownloadingProd=Download von: %1
de.IssiTxtDownloadingPleaseWait=Bitte warten Sie, während Setup %1 auf Ihren Computer herunterlädt.
de.IssiTxtDownloadingFailed=Setup konnte %1 nicht herunterladen. Bitte versuchen Sie es später nochmals, oder laden Sie %1 selbst herunter, und installieren Sie es manuell.%n%nSetup wird nun normal fortgesetzt.
de.IssiTxtLicencePrintOnDefaultPrinter=Wollen Sie die Lizenz über den Standarddrucker ausdrucken?
de.IssiTxtLicencePrintFailed=Es ist ein Problem beim Drucken der Lizenzdatei aufgetreten!
de.IssiTxtLicenceExtractFailed=Es ist ein Problem beim Extrahieren der Lizenzdatei aufgetreten!
de.IssiTxtLicencePrintButton=Lizenz &drucken
de.IssiTxtAboutButton=Ü&ber...
de.IssiTxtProdUpdated=Die aktuelle Installation von %1%n ist bereits auf dem neusten Stand.
de.IssiRequiresNet=Diese Software benötigt Microsoft .NET Framework %1.%n%nBitte verwenden Sie Windows Update, um diese Version zu installieren,%nund dann starten Sie das Setup noch einmal.
ja.NameAndVersion=%1 バージョン %2
ja.AdditionalIcons=アイコンを追加する:
ja.CreateDesktopIcon=デスクトップ上にアイコンを作成する(&D)
ja.CreateQuickLaunchIcon=クイック起動アイコンを作成する(&Q)
ja.ProgramOnTheWeb=%1 on the Web
ja.UninstallProgram=%1 をアンインストールする
ja.LaunchProgram=%1 を実行する
ja.AssocFileExtension=%2 ファイル拡張に %1を関連付けます。
ja.AssocingFileExtension=%2 に %1を関連付けます。
ja.IssiLanguageVersion=0x05010000
ja.IssiTxtScriptBackup=YOU HAVE TO MAKE BACKUPS OF YOUR SCRIPTS!!!
ja.IssiTxtScriptSavePath=Select where %1 has to be saved.
ja.IssiTxtFileExtractSuccess=File extracted.
ja.IssiTxtFileCopyFailed=Failed to copy file.
ja.IssiTxtFileExtractFailed=Failed to extract file.
ja.IssiTxtProdAlreadyInstalledPath=%1 is already installed in %2
ja.IssiTxtProdNotInstalled=%1 is not installed.
ja.IssiTxtDownloadingProd=Downloading: %1
ja.IssiTxtDownloadingPleaseWait=Please wait while Setup is downloading %1 to your computer.
ja.IssiTxtDownloadingFailed=Setup could not download %1. Try again later or download and install %1 manually.%n%nSetup will now continue installing normally.
ja.IssiTxtLicencePrintOnDefaultPrinter=Do you want to print License to default printer?
ja.IssiTxtLicencePrintFailed=Problems printing License file!
ja.IssiTxtLicenceExtractFailed=Problems extracting License file!
ja.IssiTxtLicencePrintButton=&Print License
ja.IssiTxtAboutButton=&About...
ja.IssiTxtProdUpdated=The current installation of %1%nis already up to date.
ja.IssiRequiresNet=This software requires the Microsoft .NET Framework %1.%n%nPlease use Windows Update to install this version,%nand then re-run the setup program.

[Languages]
; These files are stubs
; To achieve better results after recompilation, use the real language files
;Name: "english"; MessagesFile: "compiler:Default.isl"
;Name: "german"; MessagesFile: "compiler:Languages\German.isl"
;Name: "japanese"; MessagesFile: "compiler:Languages\Japanese.isl"
Name: "en"; MessagesFile: "compiler:Default.isl"
Name: "de"; MessagesFile: "compiler:Languages\German.isl"
Name: "ja"; MessagesFile: "compiler:Languages\Japanese.isl"

[Files]
Source: "{app}\*"; DestDir: "{app}"; Flags: ignoreversion createallsubdirs recursesubdirs sortfilesbyextension sortfilesbyname
Source: "client_135_hotfix\*"; DestDir: "{app}"; Flags: ignoreversion createallsubdirs recursesubdirs sortfilesbyextension sortfilesbyname; Components: client
Source: "server_135_hotfix\*"; DestDir: "{app}"; Flags: ignoreversion createallsubdirs recursesubdirs sortfilesbyextension sortfilesbyname; Components: server

[UninstallDelete]
Type: filesandordirs; Name: "{app}\*"
Type: filesandordirs; Name: "{app}\..\bin"; Components: server
Type: filesandordirs; Name: "{app}\..\cstrike"; Components: server
Type: filesandordirs; Name: "{app}\..\dod"; Components: server
Type: filesandordirs; Name: "{app}\..\ep2"; Components: server
Type: filesandordirs; Name: "{app}\..\episodic"; Components: server
Type: filesandordirs; Name: "{app}\..\hl1"; Components: server
Type: filesandordirs; Name: "{app}\..\hl2"; Components: server
Type: filesandordirs; Name: "{app}\..\lostcoast"; Components: server
Type: filesandordirs; Name: "{app}\..\obsidian"; Components: server
Type: filesandordirs; Name: "{app}\..\platform"; Components: server
Type: files; Name: "{app}\..\srcds.exe"; Components: server
Type: files; Name: "{app}\..\StartServer.bat"; Components: server
Type: files; Name: "{app}\..\steam.dll"; Components: server
Type: files; Name: "{app}\..\steamclient.dll"; Components: server
Type: files; Name: "{app}\..\tier0_s.dll"; Components: server
Type: files; Name: "{app}\..\vstdlib_s.dll"; Components: server

[Code]
var
  ServerAccount: TInputQueryWizardPage;
  MountsAndSteamAuth: TInputOptionWizardPage;
  InstallPathS: String;
//...
function PrepareToInstall(var NeedsRestart: Boolean): String;
begin
if not (Pos(':\obsidian',WizardDirValue())= 0) then
begin
Result := 'Error Attempt to install Obsidian to Root Denied';
end; 
end;
function ShouldSkipPage(PageID: Integer): Boolean;
begin
  { Skip pages that shouldn't be shown }
  if (PageID = ServerAccount.ID) and (IsComponentSelected('client')) then
    Result := True
  else if (PageID = MountsAndSteamAuth.ID) and (IsComponentSelected('client')) then
    Result := True
  else
    Result := False;
end;
procedure InitializeWizard;
begin
// Create the page
ServerAccount := CreateInputQueryPage(wpSelectComponents,
  'Personal Information', 'Please Enter Steam Username And Password',
  'Please specify your Steam username and the password that you wish to use to install the server, then click Next.');

// Add items (False means it's not a password edit)
ServerAccount.Add('Username:', False);
ServerAccount.Add('Password:', True);

// Set initial values (optional)
//ServerAccount.Values[0] := ExpandConstant('{sysuserinfoname}');
//ServerAccount.Values[1] := ExpandConstant('{sysuserinfoorg}');

//...

// Read values into variables



//...

// Create the page
MountsAndSteamAuth := CreateInputOptionPage(ServerAccount.ID,
  'Server Mounts and SteamAuth', 'Does the account you are using to install the server have steamguard authentication?',
  'If you do not wish to install certain mounts please select them.',
  False, False);

// Add items
MountsAndSteamAuth.Add('steamguard authentication');
MountsAndSteamAuth.Add('Half Life 1');
MountsAndSteamAuth.Add('Half Life 2');
MountsAndSteamAuth.Add('Half Life 2: Episode 1');
MountsAndSteamAuth.Add('Half Life 2: Episode 2');
MountsAndSteamAuth.Add('LostCoast');
MountsAndSteamAuth.Add('Counter Strike: Source');
MountsAndSteamAuth.Add('Day of Defeat: Source');
// Set initial values (optional)
MountsAndSteamAuth.Values[0] := True;

//...


end;    
function MyInstallPath(Param: String) :string;
begin
begin
  
  if not RegQueryStringValue(HKEY_CURRENT_USER,'Software\Valve\Steam','SourceModInstallPath',InstallPathS)then
  begin
    Result := 'C:\server\obsidian'
  end
  else begin
     Result := InstallPathS + '\obsidian'
    // handle failure if necessary; ResultCode contains the error code
  end;
end;
end;
function GetUserName(Param: String): string;
begin
  Result := ServerAccount.Values[0];
end;
function GetPassword(Param: String): string;
begin
  Result := ServerAccount.Values[1];
end;
function GetSteamAuth(Param: String): string;
begin
  if MountsAndSteamAuth.Values[0] then 
  begin
  Result := '-steamauth';
  end
  else
  begin
  Result := '';
  end;
end;

function GetHl1(Param: String): string;
begin
  if MountsAndSteamAuth.Values[1] then 
  begin 
  Result := '1';
  end
  else 
  begin
  Result := '0';
  end;
end;
function GetHl2(Param: String): string;
begin
if MountsAndSteamAuth.Values[2] then 
begin 
Result := '1';
end
else 
begin
Result := '0';
end;
end;
function GetHl2ep1(Param: String): string;
begin
if MountsAndSteamAuth.Values[3] then 
begin 
Result := '1';
end
else 
begin
Result := '0';
end;
end;
function GetHl2ep2(Param: String): string;
begin
if MountsAndSteamAuth.Values[4] then 
begin 
Result := '1';
end
else 
begin
Result := '0';
end;
end;
function Getlostcoast(Param: String): string;
begin
if MountsAndSteamAuth.Values[5] then 
begin 
Result := '1';
end
else 
begin
Result := '0';
end;
end;
function Getcstrike(Param: String): string;
begin
if MountsAndSteamAuth.Values[6] then 
begin 
Result := '1';
end
else 
begin
Result := '0';
end;
end;
function Getdod(Param: String): string;
begin
if MountsAndSteamAuth.Values[7] then 
begin 
Result := '1';
end
else 
begin
Result := '0';
end;
end;

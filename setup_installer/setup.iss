[Setup]
AppName=SI Pemesanan Tiket Bus
AppVerName=SI Pemesanan Tiket Bus Versi 1.0.0
AppPublisher=Kelompok 11
AppCopyright=Copyright © 2023. Kelompok 11
DefaultDirName={pf}\SI Pemesanan Tiket Bus
DefaultGroupName=SI Pemesanan Tiket Bus
OutputDir=file setup
OutputBaseFilename=SetupSIPemesananTiketBus
DisableProgramGroupPage = yes
CreateUninstallRegKey = yes
Uninstallable = yes
UninstallFilesDir={app}\uninst
UninstallDisplayIcon={app}\PemesananTiketBus.exe,0
UninstallDisplayName=SI Pemesanan Tiket Bus
VersionInfoVersion=1.0.0.0
SetupIconFile=Setup.ico

[Languages]
Name: ina; MessagesFile: Indonesian.isl

[Tasks]
Name: desktopicon; Description: {cm:CreateDesktopIcon}; GroupDescription: {cm:AdditionalIcons}; Flags: unchecked


[Files]
;file-file aplikasi
Source: "E:\KULIAH\Semester 3\Pemrog lanjut\FP\PemesananTiketBus\PemesananTiketBus\bin\Debug\PemesananTiketBus.exe"; DestDir: {app}; Flags: ignoreversion
Source: "E:\KULIAH\Semester 3\Pemrog lanjut\FP\PemesananTiketBus\PemesananTiketBus\bin\Debug\PemesananTiketBus.exe.config"; DestDir: {app}; Flags: ignoreversion
Source: "E:\KULIAH\Semester 3\Pemrog lanjut\FP\PemesananTiketBus\PemesananTiketBus\bin\Debug\Database\PesanTiket.db"; DestDir: {app}\Database; Flags: ignoreversion

; file-file pendukung
Source: "E:\KULIAH\Semester 3\Pemrog lanjut\FP\PemesananTiketBus\PemesananTiketBus\bin\Debug\System.Data.SQLite.dll"; DestDir: {app}; Flags: ignoreversion
Source: "E:\KULIAH\Semester 3\Pemrog lanjut\FP\PemesananTiketBus\PemesananTiketBus\bin\Debug\x64\SQLite.Interop.dll"; DestDir: {app}\x64; Flags: ignoreversion
Source: "E:\KULIAH\Semester 3\Pemrog lanjut\FP\PemesananTiketBus\PemesananTiketBus\bin\Debug\x86\SQLite.Interop.dll"; DestDir: {app}\x86; Flags: ignoreversion

Source: bus.ico; DestDir: {app}; Flags: ignoreversion

[Icons]
Name: {group}\SI Pemesanan Tiket Bus; Filename: {app}\PemesananTiketBus.exe; WorkingDir: {app}; IconFilename: {app}\bus.ico
Name: {userdesktop}\SI Pemesanan Tiket Bus; Filename: {app}\PemesananTiketBus.exe; WorkingDir: {app}; IconFilename: {app}\bus.ico; Tasks: desktopicon

[Dirs]
;memberikan ijin user untuk menulis database tanpa harus run administrator
Name: {app}; Permissions: users-full

[Registry]
;mencatat lokasi instalasi program, ini dibutuhkan jika kita ingin membuat paket instalasi update
Root: HKCU; Subkey: "Software\SI Pemesanan Tiket Bus"; ValueName: "installDir"; ValueType: String; ValueData: {app}; Flags: uninsdeletevalue
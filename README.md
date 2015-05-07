# Claunia.IO

## Scope and intention
This is a .NET library designed to provide developers with an easy way to handle underlying filesystem extended attributes (also called EAs and xattrs) as well as file forks (also called Alternate Data Streams, like for example, Mac OS' 
Resource Fork).

The intention is to provide a drop-in replacement for common file I/O classes that support all major operating systems APIs for accessing forks, common file metadata and extended attributes, as well as common interchange containers.

It is currently under heavy development and will take some time to be complete.

## Targetted operating systems
* Windows NT (XP, Vista, 7, 8 and 10) for Desktop
* Linux
* FreeBSD and derivates (PC-BSD et al.)
* Mac OS X

## Operating systems that may be targetted
* Solaris (need to get Mono running on it for testing)
* NetBSD (need to get Mono running on it for testing)
* OpenBSD (need to get Mono running on it for testing)

## Operating systems not targetted
* Haiku (while xattrs are an extensive part of Haiku, there is no .NET support at all for it)
* OS/2 or eComStation (while xattrs are an extensive part of OS/2, there is no .NET support at all for it)
* AIX (no way to get it for testing)
* Any other OS where there is no .NET support
* Game consoles
* Any OS without xattrs, forks or EAs

## Currently implemented
* Ability to accurately detect which *nix flavour or Windows flavour is the library running on
* Invoking Mac OS X xattr, file metadata and volume metadata APIs:
* * uname(3)
* * getattrlist(2) and setattrlist(2)
* * getxattr(2), listxattr(2), removexattr(2) and setxattr(2)
* * stat(2) and statfs(2)
* Invoking Linux xattr, file metadata and volume metadata APIs:
* * uname(3)
* * getxattr(2), listxattr(2), removexattr(2) and setxattr(2)
* * stat(2) and statfs(2)
* Invoking FreeBSD xattr, file metadata and volume metadata APIs:
* * uname(3)
* * extattr_get_file(2), extattr_list_file(2), extattr_delete_file(2) and extattr_set_file(2)
* * stat(2) and statfs(2)
* Invoking Windows EAs, ADS, file metadata and volume metadata APIs:
* * NtClose() and NtCreateFile()
* * NtQueryEaFile() and NtSetEaFile()
* * CreateFile()
* * BackupRead() and BackupSeek()
* * GetVolumeInformation()
* * GetFileInformationByHandle() and GetFileInformationByHandleEx()
* * FindFirstStreamW() and FindNextStreamW()

## To be implemented
### Platform APIs:
* A high-level, .NET object-based access to all information obtainable by low-level APIs
* A working replacement of .NET FileInfo, DirectoryInfo and FileStream classes where applicable
### Interchange containers:
* AppleSingle
* AppleDouble
* MacBinary
* BinHex
* Apple's PC Exchange "RESOURCE.FRK" folder
* Basilisk II and SheepShaver ".finf" folder
* Netatalk ".AppleDouble" folder
* Mac OS X "._File" and ".DS_Store" files
* WinUAE "_UAEFSDB.___" and FS-UAE ".uaem" metadata files
* Cygwin EAs.
* Windows NT Server ADS for Mac OS metadata and forks
* Archive Utility.app "__MACOSX" folders
### Tools:
* Methods to convert between containers and native capatibilities
* Methods to handle and understand, and where applicable convert, between same metadata stored in different formats and places (e.g. rename a 8.3 filename to the name stored by PC Exchange)
* A wholly complete, platform independent Resource Fork system


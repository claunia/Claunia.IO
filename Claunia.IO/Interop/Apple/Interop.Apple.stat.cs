//
// Interop.Apple.stat.cs
//
// Author:
//       Natalia Portillo <claunia@claunia.com>
//
// Copyright (c) 2015 © Claunia.com
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System.Runtime.InteropServices;
using System;

internal static partial class Interop
{
    internal static partial class Apple
    {
        /// <summary>
        /// stat(2) structure when __DARWIN_64_BIT_INO_T is defined
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct Stat64
        {
            /// <summary>
            /// ID of device containing file
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int st_dev;
            /// <summary>
            /// Mode of file
            /// </summary>
            [MarshalAs(UnmanagedType.U2)]
            public mode_t st_mode;
            /// <summary>
            /// Number of hard links
            /// </summary>
            [MarshalAs(UnmanagedType.U2)]
            public ushort st_nlink;
            /// <summary>
            /// File serial number
            /// </summary>
            [MarshalAs(UnmanagedType.U8)]
            public ulong st_ino;
            /// <summary>
            /// User ID of the file
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            public uint st_uid;
            /// <summary>
            /// Group ID of the file
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            public uint st_gid;
            /// <summary>
            /// Device ID
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int st_rdev;
            /// <summary>
            /// time of last access
            /// </summary>
            public Timespec st_atimespec;
            /// <summary>
            /// time of last data modification
            /// </summary>
            public Timespec st_mtimespec;
            /// <summary>
            /// time of last status change
            /// </summary>
            public Timespec st_ctimespec;
            /// <summary>
            /// time of file creation(birth)
            /// </summary>
            public Timespec st_birthtimespec;
            /// <summary>
            /// file size, in bytes
            /// </summary>
            [MarshalAs(UnmanagedType.I8)]
            public long st_size;
            /// <summary>
            /// blocks allocated for file
            /// </summary>
            [MarshalAs(UnmanagedType.I8)]
            public long st_blocks;
            /// <summary>
            /// optimal blocksize for I/O
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int st_blksize;
            /// <summary>
            /// user defined flags for file
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            public flags_t st_flags;
            /// <summary>
            /// file generation number
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            public uint st_gen;
            /// <summary>
            /// Reserved: DO NOT USE
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            [Obsolete("RESERVED: DO NOT USE")]
            public uint st_lspare;
            /// <summary>
            /// Reserved: DO NOT USE
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, 
                ArraySubType = UnmanagedType.U8, SizeConst = 2)]
            [Obsolete("RESERVED: DO NOT USE")]
            public ulong[] st_qspare;
        }

        /// <summary>
        /// stat(2) structure when __DARWIN_64_BIT_INO_T is NOT defined
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct Stat
        {
            /// <summary>
            /// ID of device containing file
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int st_dev;
            /// <summary>
            /// File serial number
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            public uint st_ino;
            /// <summary>
            /// Mode of file
            /// </summary>
            [MarshalAs(UnmanagedType.U2)]
            public mode_t st_mode;
            /// <summary>
            /// Number of hard links
            /// </summary>
            [MarshalAs(UnmanagedType.U2)]
            public ushort st_nlink;
            /// <summary>
            /// User ID of the file
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            public uint st_uid;
            /// <summary>
            /// Group ID of the file
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            public uint st_gid;
            /// <summary>
            /// Device ID
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int st_rdev;
            /// <summary>
            /// time of last access
            /// </summary>
            public Timespec st_atimespec;
            /// <summary>
            /// time of last data modification
            /// </summary>
            public Timespec st_mtimespec;
            /// <summary>
            /// time of last status change
            /// </summary>
            public Timespec st_ctimespec;
            /// <summary>
            /// file size, in bytes
            /// </summary>
            [MarshalAs(UnmanagedType.I8)]
            public long st_size;
            /// <summary>
            /// blocks allocated for file
            /// </summary>
            [MarshalAs(UnmanagedType.I8)]
            public long st_blocks;
            /// <summary>
            /// optimal blocksize for I/O
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int st_blksize;
            /// <summary>
            /// user defined flags for file
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            public flags_t st_flags;
            /// <summary>
            /// file generation number
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            public uint st_gen;
            /// <summary>
            /// Reserved: DO NOT USE
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            [Obsolete("RESERVED: DO NOT USE")]
            public uint st_lspare;
            /// <summary>
            /// Reserved: DO NOT USE
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, 
                ArraySubType = UnmanagedType.U8, SizeConst = 2)]
            [Obsolete("RESERVED: DO NOT USE")]
            public ulong[] st_qspare;
        }

        /// <summary>
        /// File mode and permissions
        /// </summary>
        [Flags]
        internal enum mode_t : ushort
        {
            // File type

            /// <summary>
            /// File type mask
            /// </summary>
            S_IFMT = 0xF000,
            /// <summary>
            /// Named pipe (FIFO)
            /// </summary>
            S_IFIFO = 0x1000,
            /// <summary>
            /// Character device
            /// </summary>
            S_IFCHR = 0x2000,
            /// <summary>
            /// Directory
            /// </summary>
            S_IFDIR = 0x4000,
            /// <summary>
            /// Block device
            /// </summary>
            S_IFBLK = 0x6000,
            /// <summary>
            /// Regular file
            /// </summary>
            S_IFREG = 0x8000,
            /// <summary>
            /// Symbolic link
            /// </summary>
            S_IFLNK = 0xA000,
            /// <summary>
            /// Socket file
            /// </summary>
            S_IFSOCK = 0xC000,
            /// <summary>
            /// OBSOLETE: whiteout
            /// </summary>
            [Obsolete]
            S_IFWHT = 0xE000,

            // POSIX Permissions

            /// <summary>
            /// Owner permissions mask
            /// </summary>
            S_IRWXU = 0x01C0,
            /// <summary>
            /// Readable by owner
            /// </summary>
            S_IRUSR = 0x0100,
            /// <summary>
            /// Writable by owner
            /// </summary>
            S_IWUSR = 0x0080,
            /// <summary>
            /// Executable by owner
            /// </summary>
            S_IXUSR = 0x0040,

            /// <summary>
            /// Group permissions mask
            /// </summary>
            S_IRWXG = 0x0038,
            /// <summary>
            /// Readable by group
            /// </summary>
            S_IRGRP = 0x0020,
            /// <summary>
            /// Writable by group
            /// </summary>
            S_IWGRP = 0x0010,
            /// <summary>
            /// Executable by group
            /// </summary>
            S_IXGRP = 0x0008,

            /// <summary>
            /// Others permissions mask
            /// </summary>
            S_IRWXO = 0x0007,
            /// <summary>
            /// Readable by others
            /// </summary>
            S_IROTH = 0x0004,
            /// <summary>
            /// Writable by others
            /// </summary>
            S_IWOTH = 0x0002,
            /// <summary>
            /// Executable by others
            /// </summary>
            S_IXOTH = 0x0001,

            /// <summary>
            /// Set UID on execution
            /// </summary>
            S_ISUID = 0x0800,
            /// <summary>
            /// Set GID on execution
            /// </summary>
            S_ISGID = 0x0400,
            /// <summary>
            /// Only file/directory owners (or suser) can removed files from directory
            /// </summary>
            S_ISVTX = 0x0200,

            /// <summary>
            /// Sticky bit, not supported by OS X
            /// </summary>
            [Obsolete("Not supported under OS X")]
            S_ISTXT = S_ISVTX,
            /// <summary>
            /// For backwards compatibility
            /// </summary>
            S_IREAD = S_IRUSR,
            /// <summary>
            /// For backwards compatibility
            /// </summary>
            S_IWRITE = S_IWUSR,
            /// <summary>
            /// For backwards compatibility
            /// </summary>
            S_IEXEC = S_IXUSR
        }

        /// <summary>
        /// User-set flags
        /// </summary>
        [Flags]
        internal enum flags_t : uint
        {
            /// <summary>
            /// Mask of flags changeable by owner
            /// </summary>
            UF_SETTABLE = 0x0000FFFF,
            /// <summary>
            /// Do not dump file
            /// </summary>
            UF_NODUMP = 0x00000001,
            /// <summary>
            /// File is immutable (read-only)
            /// </summary>
            UF_IMMUTABLE = 0x00000002,
            /// <summary>
            /// File can only be appended
            /// </summary>
            UF_APPEND = 0x00000004,
            /// <summary>
            /// The directory is opaque when viewed through a union stack.
            /// </summary>
            UF_OPAQUE = 0x00000008,
            /// <summary>
            /// INCOMPATIBLE: Used in FreeBSD, unimplemented in OS X.
            /// File cannot be removed or renamed.
            /// </summary>
            [Obsolete("Unimplemented in OS X")]
            UF_NOUNLINK = 0x00000010,
            /// <summary>
            /// File is compressed in HFS+ (>=10.6)
            /// </summary>
            UF_COMPRESSED = 0x00000020,
            /// <summary>
            /// OBSOLETE: No longer used.
            /// Issue notifications for deletes or renames of files with this flag set
            /// </summary>
            [Obsolete("No longer used")]
            UF_TRACKED = 0x00000040,
            /// <summary>
            /// Hide the file in Finder
            /// </summary>
            UF_HIDDEN = 0x00008000,

            /// <summary>
            /// Mask of flags changeable by the superuser
            /// </summary>
            SF_SETTABLE = 0xffff0000,
            /// <summary>
            /// File has been archived
            /// </summary>
            SF_ARCHIVED = 0x00010000,
            /// <summary>
            /// File is immutable (read-only)
            /// </summary>
            SF_IMMUTABLE = 0x00020000,
            /// <summary>
            /// File can only be appended
            /// </summary>
            SF_APPEND = 0x00040000,
            /// <summary>
            /// Restricted access
            /// </summary>
            SF_RESTRICTED = 0x00080000,
            /// <summary>
            /// INCOMPATIBLE: Used in FreeBSD, unimplemented in OS X.
            /// File cannot be removed or renamed.
            /// </summary>
            [Obsolete("Unimplemented in OS X")]
            SF_NOUNLINK = 0x00100000,
            /// <summary>
            /// INCOMPATIBLE: Used in FreeBSD, unimplemented in OS X.
            /// Snapshot inode
            /// </summary>
            [Obsolete("Unimplemented in OS X")]
            SF_SNAPSHOT = 0x00200000
        }

        /// <summary>
        /// Obtains information of the file pointed by <paramref name="path"/>.
        /// Calls to system's stat(2)
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <param name="buf"><see cref="Stat"/> on 32 bit systems and <see cref="Stat64"/> on 64 bit systems.</param>
        [DllImport(Libraries.Libc, SetLastError = true)]
        public static extern int stat(string path, out Stat buf);

        /// <summary>
        /// Obtains information of the file pointed by <paramref name="path"/>.
        /// Calls to system's stat64(2)
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <param name="buf"><see cref="Stat64"/>.</param>
        [DllImport(Libraries.Libc, SetLastError = true)]
        public static extern int stat64(string path, out Stat64 buf);
    }
}


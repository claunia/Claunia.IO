//
// Interop.Linux.stat.cs
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
    internal static partial class Linux
    {
        /// <summary>
        /// stat(2) structure when 64 bits
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct Stat64
        {
            /// <summary>
            /// ID of device containing file
            /// </summary>
            UInt64 st_dev;
            /// <summary>
            /// inode number
            /// </summary>
            UInt64 st_ino;
            /// <summary>
            /// number of hard links
            /// </summary>
            UInt64 st_nlink;
            /// <summary>
            /// protection
            /// </summary>
            mode_t st_mode;
            /// <summary>
            /// user ID of owner
            /// </summary>
            UInt32 st_uid;
            /// <summary>
            /// group ID of owner
            /// </summary>
            UInt32 st_gid;
            /// <summary>
            /// padding
            /// </summary>
            Int32 __pad0;
            /// <summary>
            /// device ID (if special file)
            /// </summary>
            UInt64 st_rdev;
            /// <summary>
            /// total size, in bytes
            /// </summary>
            Int64 st_size;
            /// <summary>
            /// blocksize for filesystem I/O
            /// </summary>
            Int64 st_blksize;
            /// <summary>
            /// number of 512B blocks allocated
            /// </summary>
            Int64 st_blocks;
            /// <summary>
            /// time of last access
            /// </summary>
            Int64 st_atime;
            /// <summary>
            /// time of last access nanosecond
            /// </summary>
            UInt64 st_atimensec;
            /// <summary>
            /// time of last modification
            /// </summary>
            Int64 st_mtime;
            /// <summary>
            /// time of last modification naonsecond
            /// </summary>
            UInt64 st_mtimensec;
            /// <summary>
            /// time of last status change
            /// </summary>
            Int64 st_ctime;
            /// <summary>
            /// time of last status change nanosecond
            /// </summary>
            UInt64 st_ctimensec;
            [MarshalAs(UnmanagedType.ByValArray, 
                ArraySubType = UnmanagedType.I8, SizeConst = 3)]
            [Obsolete("RESERVED: DO NOT USE")]
            Int64[] __glibc_reserved;
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
            UInt64 st_dev;
            /// <summary>
            /// padding
            /// </summary>
            UInt16 __pad1;
            /// <summary>
            /// inode number
            /// </summary>
            UInt32 st_ino;
            /// <summary>
            /// protection
            /// </summary>
            mode_t st_mode;
            /// <summary>
            /// number of hard links
            /// </summary>
            UInt32 st_nlink;
            /// <summary>
            /// user ID of owner
            /// </summary>
            UInt32 st_uid;
            /// <summary>
            /// group ID of owner
            /// </summary>
            UInt32 st_gid;
            /// <summary>
            /// device ID (if special file)
            /// </summary>
            UInt64 st_rdev;
            /// <summary>
            /// padding
            /// </summary>
            UInt16 __pad2;
            /// <summary>
            /// total size, in bytes
            /// </summary>
            Int32 st_size;
            /// <summary>
            /// blocksize for filesystem I/O
            /// </summary>
            Int32 st_blksize;
            /// <summary>
            /// number of 512B blocks allocated
            /// </summary>
            Int32 st_blocks;
            /// <summary>
            /// time of last access
            /// </summary>
            Timespec st_atim;
            /// <summary>
            /// time of last modification
            /// </summary>
            Timespec st_mtim;
            /// <summary>
            /// time of last status change
            /// </summary>
            Timespec st_ctim;
            [Obsolete("RESERVED: DO NOT USE")]
            UInt32 __glibc_reserved4;
            [Obsolete("RESERVED: DO NOT USE")]
            UInt32 __glibc_reserved5;
        }

        /// <summary>
        /// File mode and permissions
        /// </summary>
        [Flags]
        internal enum mode_t : UInt32
        {
            /// <summary>
            ///    bit mask for the file type bit fields
            /// </summary>
            S_IFMT = 0x0170000,
            /// <summary>
            /// socket
            /// </summary>
            S_IFSOCK = 0x0140000,
            /// <summary>
            /// symbolic link
            /// </summary>
            S_IFLNK = 0x0120000,
            /// <summary>
            /// regular file
            /// </summary>
            S_IFREG = 0x0100000,
            /// <summary>
            /// block device
            /// </summary>
            S_IFBLK = 0x0060000,
            /// <summary>
            /// directory
            /// </summary>
            S_IFDIR = 0x0040000,
            /// <summary>
            /// character device
            /// </summary>
            S_IFCHR = 0x0020000,
            /// <summary>
            /// FIFO
            /// </summary>
            S_IFIFO = 0x0010000,
            /// <summary>
            /// set-user-ID bit
            /// </summary>
            S_ISUID = 0x0004000,
            /// <summary>
            /// set-group-ID bit
            /// </summary>
            S_ISGID = 0x0002000,
            /// <summary>
            /// sticky bit (see below)
            /// </summary>
            S_ISVTX = 0x0001000,
            /// <summary>
            /// mask for file owner permissions
            /// </summary>
            S_IRWXU = 0x00700,
            /// <summary>
            /// owner has read permission
            /// </summary>
            S_IRUSR = 0x00400,
            /// <summary>
            /// owner has write permission
            /// </summary>
            S_IWUSR = 0x00200,
            /// <summary>
            /// owner has execute permission
            /// </summary>
            S_IXUSR = 0x00100,
            /// <summary>
            /// mask for group permissions
            /// </summary>
            S_IRWXG = 0x00070,
            /// <summary>
            /// group has read permission
            /// </summary>
            S_IRGRP = 0x00040,
            /// <summary>
            /// group has write permission
            /// </summary>
            S_IWGRP = 0x00020,
            /// <summary>
            /// group has execute permission
            /// </summary>
            S_IXGRP = 0x00010,
            /// <summary>
            /// mask for permissions for others (not in group)
            /// </summary>
            S_IRWXO = 0x00007,
            /// <summary>
            /// others have read permission
            /// </summary>
            S_IROTH = 0x00004,
            /// <summary>
            /// others have write permission
            /// </summary>
            S_IWOTH = 0x00002,
            /// <summary>
            /// others have execute permission
            /// </summary>
            S_IXOTH = 0x00001
        }


        /// <summary>
        /// Obtains information of the file pointed by <paramref name="path"/>.
        /// Calls to system's stat(2) for 32 bit systems
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <param name="buf"><see cref="Stat"/>.</param>
        /// <returns>On success, 0. On failure, -1, and errno is set.</returns>
        [DllImport(Libraries.Libc, SetLastError = true)]
        public static extern int stat(string path, out Stat buf);

        /// <summary>
        /// Obtains information of the file pointed by <paramref name="path"/>.
        /// Calls to system's stat(2) for 64 bit systems
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <param name="buf"><see cref="Stat64"/>.</param>
        /// <returns>On success, 0. On failure, -1, and errno is set.</returns>
        [DllImport(Libraries.Libc, SetLastError = true, EntryPoint="stat")]
        public static extern int stat64(string path, out Stat64 buf);
    }
}


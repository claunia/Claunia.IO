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
    internal static partial class FreeBSD
    {
        /// <summary>
        /// stat(2) structure when 64 bit
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct Stat64
        {
            /// <summary>
            /// inode's device
            /// </summary>
            UInt32 st_dev;
            /// <summary>
            /// inode's number
            /// </summary>
            UInt32 st_ino;
            /// <summary>
            /// inode protection mode
            /// </summary>
            mode_t st_mode;
            /// <summary>
            /// number of hard links
            /// </summary>
            UInt16 st_nlink;
            /// <summary>
            /// user ID of the file's owner
            /// </summary>
            UInt32 st_uid;
            /// <summary>
            /// group ID of the file's group
            /// </summary>
            UInt32 st_gid;
            /// <summary>
            /// device type
            /// </summary>
            UInt32 st_rdev;
            /// <summary>
            /// time of last access
            /// </summary>
            Timespec64 st_atim;
            /// <summary>
            /// time of last data modification
            /// </summary>
            Timespec64 st_mtim;
            /// <summary>
            /// time of last file status change
            /// </summary>
            Timespec64 st_ctim;
            /// <summary>
            /// file size, in bytes
            /// </summary>
            Int64 st_size;
            /// <summary>
            /// blocks allocated for file
            /// </summary>
            Int64 st_blocks;
            /// <summary>
            /// optimal blocksize for I/O
            /// </summary>
            Int32 st_blksize;
            /// <summary>
            /// user defined flags for file
            /// </summary>
            flags_t st_flags;
            /// <summary>
            /// file generation number
            /// </summary>
            UInt32 st_gen;
            Int32 st_lspare;
            /// <summary>
            /// time of file creation
            /// </summary>
            Timespec64 st_birthtim;
        }

        /// <summary>
        /// stat(2) structure when 32 bit
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct Stat
        {
            /// <summary>
            /// inode's device
            /// </summary>
            UInt32 st_dev;
            /// <summary>
            /// inode's number
            /// </summary>
            UInt32 st_ino;
            /// <summary>
            /// inode protection mode
            /// </summary>
            mode_t st_mode;
            /// <summary>
            /// number of hard links
            /// </summary>
            UInt16 st_nlink;
            /// <summary>
            /// user ID of the file's owner
            /// </summary>
            UInt32 st_uid;
            /// <summary>
            /// group ID of the file's group
            /// </summary>
            UInt32 st_gid;
            /// <summary>
            /// device type
            /// </summary>
            UInt32 st_rdev;
            /// <summary>
            /// time of last access
            /// </summary>
            Timespec st_atim;
            /// <summary>
            /// time of last data modification
            /// </summary>
            Timespec st_mtim;
            /// <summary>
            /// time of last file status change
            /// </summary>
            Timespec st_ctim;
            /// <summary>
            /// file size, in bytes
            /// </summary>
            Int64 st_size;
            /// <summary>
            /// blocks allocated for file
            /// </summary>
            Int64 st_blocks;
            /// <summary>
            /// optimal blocksize for I/O
            /// </summary>
            Int32 st_blksize;
            /// <summary>
            /// user defined flags for file
            /// </summary>
            flags_t st_flags;
            /// <summary>
            /// file generation number
            /// </summary>
            UInt32 st_gen;
            Int32 st_lspare;
            /// <summary>
            /// time of file creation
            /// </summary>
            Timespec st_birthtim;
        }

        /// <summary>
        /// File mode and permissions
        /// </summary>
        [Flags]
        internal enum mode_t : ushort
        {
            /// <summary>type of file mask</summary>
            S_IFMT = 0xF000,
            /// <summary>named  pipe (fifo)</summary>
            S_IFIFO = 0x1000,
            /// <summary>character special</summary>
            S_IFCHR = 0x2000,
            /// <summary>directory</summary>
            S_IFDIR = 0x4000,
            /// <summary>block  special</summary>
            S_IFBLK = 0x6000,
            /// <summary>regular</summary>
            S_IFREG = 0x8000,
            /// <summary>symbolic link </summary>
            S_IFLNK = 0xA000,
            /// <summary>socket</summary>
            S_IFSOCK = 0xC000,
            /// <summary>whiteout</summary>
            S_IFWHT = 0xE000,
            /// <summary>set user id on execution</summary>
            S_ISUID = 0x0800,
            /// <summary>set group id on execution</summary>
            S_ISGID = 0x0400,
            /// <summary>save swapped text even after use</summary>
            S_ISVTX = 0x0200,
            /// <summary>RWX mask for owner</summary>
            S_IRWXU = 0x01C0,
            /// <summary>read permission, owner</summary>
            S_IRUSR = 0x0100,
            /// <summary>write  permission, owner</summary>
            S_IWUSR = 0x0080,
            /// <summary>execute/search permission, owner</summary>
            S_IXUSR = 0x0040,
            /// <summary>RWX mask for group</summary>
            S_IRWXG = 0x0038,
            /// <summary>read permission, group</summary>
            S_IRGRP = 0x0020,
            /// <summary>write  permission, group</summary>
            S_IWGRP = 0x0010,
            /// <summary>execute/search permission, group</summary>
            S_IXGRP = 0x0008,
            /// <summary>RWX mask for other</summary>
            S_IRWXO = 0x0007,
            /// <summary>read permission, other</summary>
            S_IROTH = 0x0004,
            /// <summary>write  permission, other</summary>
            S_IWOTH = 0x0002,
            /// <summary>execute/search permission, other</summary>
            S_IXOTH = 0x0001
        }

        /// <summary>
        /// User-set flags
        /// </summary>
        [Flags]
        internal enum flags_t : uint
        {
            /// <summary>
            /// Mask of owner changeable flags
            /// </summary>
            UF_SETTABLE = 0x0000FFFF,
            /// <summary>
            /// Do not dump file
            /// </summary>
            UF_NODUMP = 0x00000001,
            /// <summary>
            /// File may not be changed
            /// </summary>
            UF_IMMUTABLE = 0x00000002,
            /// <summary>
            /// Writes to file may only append
            /// </summary>
            UF_APPEND = 0x00000004,
            /// <summary>
            /// The directory is opaque when viewed through a union stack.
            /// </summary>
            UF_OPAQUE = 0x00000008,
            /// <summary>
            /// File may not be removed or renamed.
            /// </summary>
            UF_NOUNLINK = 0x00000010,
            /// <summary>
            /// File is compressed in HFS+ (>=10.6)
            /// </summary>
            [Obsolete("Unimplemented in FreeBSD")]
            UF_COMPRESSED = 0x00000020,
            /// <summary>
            /// OBSOLETE: No longer used.
            /// Issue notifications for deletes or renames of files with this flag set
            /// </summary>
            [Obsolete("Unimplemented in FreeBSD")]
            UF_TRACKED = 0x00000040,
            /// <summary>
            /// Windows system file bit
            /// </summary>
            UF_SYSTEM = 0x00000080,
            /// <summary>
            /// Sparse file
            /// </summary>
            UF_SPARSE = 0x00000100,
            /// <summary>
            /// File is offline
            /// </summary>
            UF_OFFLINE = 0x00000200,
            /// <summary>
            /// Windows reparse point file bit
            /// </summary>
            UF_REPARSE = 0x00000400,
            /// <summary>
            /// File needs to be archived
            /// </summary>
            UF_ARCHIVE = 0x00000800,
            /// <summary>
            /// Windows readonly file bit
            /// </summary>
            UF_READONLY = 0x00001000,

            /// <summary>
            /// File is hidden
            /// </summary>
            UF_HIDDEN = 0x00008000,

            /// <summary>
            /// Mask of superuser changeable flags
            /// </summary>
            SF_SETTABLE = 0xffff0000,
            /// <summary>
            /// File is archived
            /// </summary>
            SF_ARCHIVED = 0x00010000,
            /// <summary>
            /// File may not be changed
            /// </summary>
            SF_IMMUTABLE = 0x00020000,
            /// <summary>
            /// Writes to file may only append
            /// </summary>
            SF_APPEND = 0x00040000,
            /// <summary>
            /// File may not be removed or renamed
            /// </summary>
            SF_NOUNLINK = 0x00100000,
            /// <summary>
            /// Snapshot inode
            /// </summary>
            SF_SNAPSHOT = 0x00200000
        }

        /// <summary>
        /// Obtains information of the file pointed by <paramref name="path"/>.
        /// Calls to system's stat(2)
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <param name="buf"><see cref="Stat"/> on 32 bit systems and <see cref="Stat64"/> on 64 bit systems.</param>
        /// <returns>On success, 0. On failure, -1, and errno is set.</returns>
        [DllImport(Libraries.Libc, SetLastError = true)]
        public static extern int stat(string path, out Stat buf);

        /// <summary>
        /// Obtains information of the file pointed by <paramref name="path"/>.
        /// Calls to system's stat64(2)
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <param name="buf"><see cref="Stat64"/>.</param>
        /// <returns>On success, 0. On failure, -1, and errno is set.</returns>
        [DllImport(Libraries.Libc, SetLastError = true, EntryPoint="stat")]
        public static extern int stat64(string path, out Stat64 buf);
    }
}
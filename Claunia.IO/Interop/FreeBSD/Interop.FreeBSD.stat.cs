﻿//
// Interop.FreeBSD.stat.cs
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
using System;
using System.Runtime.InteropServices;

#region FreeBSD 32-bit type definitions
using blkcnt_t = System.Int64;
using blksize_t = System.Int32;
using gid_t = System.UInt32;
using ino_t = System.UInt32;
using int64_t = System.Int64;
using nlink_t = System.UInt16;
using off_t = System.Int64;
using size_t = System.Int32;
using ssize_t = System.Int32;
using uid_t = System.UInt32;
using uint32_t = System.UInt32;
using uint64_t = System.UInt64;
using __dev_t = System.UInt32;
using __int32_t = System.Int32;
using __uint32_t = System.UInt32;

#endregion

internal static partial class Interop
{
    internal static partial class FreeBSD
    {
        /// <summary>
        /// stat(2) structure when 32 bit
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct Stat
        {
            /// <summary>
            /// inode's device
            /// </summary>
            __dev_t st_dev;
            /// <summary>
            /// inode's number
            /// </summary>
            ino_t st_ino;
            /// <summary>
            /// inode protection mode
            /// </summary>
            mode_t st_mode;
            /// <summary>
            /// number of hard links
            /// </summary>
            nlink_t st_nlink;
            /// <summary>
            /// user ID of the file's owner
            /// </summary>
            uid_t st_uid;
            /// <summary>
            /// group ID of the file's group
            /// </summary>
            gid_t st_gid;
            /// <summary>
            /// device type
            /// </summary>
            __dev_t st_rdev;
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
            off_t st_size;
            /// <summary>
            /// blocks allocated for file
            /// </summary>
            blkcnt_t st_blocks;
            /// <summary>
            /// optimal blocksize for I/O
            /// </summary>
            blksize_t st_blksize;
            /// <summary>
            /// user defined flags for file
            /// </summary>
            flags_t st_flags;
            /// <summary>
            /// file generation number
            /// </summary>
            __uint32_t st_gen;
            __int32_t st_lspare;
            /// <summary>
            /// time of file creation
            /// </summary>
            Timespec st_birthtim;
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
    }
}
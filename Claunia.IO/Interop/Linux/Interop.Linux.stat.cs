﻿//
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
        /// stat(2) structure when 32 bits
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
        /// Obtains information of the file pointed by <paramref name="path"/>.
        /// Calls to system's stat(2) for 32 bit systems
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <param name="buf"><see cref="Stat"/>.</param>
        /// <returns>On success, 0. On failure, -1, and errno is set.</returns>
        [DllImport(Libraries.Libc, SetLastError = true)]
        public static extern int stat(string path, out Stat buf);
    }
}


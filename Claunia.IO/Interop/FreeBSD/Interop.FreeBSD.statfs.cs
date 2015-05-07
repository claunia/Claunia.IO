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
using System.Runtime.InteropServices;
using System;

internal static partial class Interop
{
    internal static partial class FreeBSD
    {
        /// <summary>
        /// statfs(2) structure
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct StatFS
        {
            /// <summary>structure version number</summary>
            UInt32 f_version;
            /// <summary>type of filesystem</summary>
            UInt32 f_type;
            /// <summary>copy of mount exported flags</summary>
            mntflags_t f_flags;
            /// <summary>filesystem fragment size</summary>
            UInt64 f_bsize;
            /// <summary>optimal transfer block size</summary>
            UInt64 f_iosize;
            /// <summary>total data blocks in filesystem</summary>
            UInt64 f_blocks;
            /// <summary>free blocks in filesystem</summary>
            UInt64 f_bfree;
            /// <summary>free blocks avail to non-superuser</summary>
            Int64 f_bavail;
            /// <summary>total file nodes in filesystem</summary>
            UInt64 f_files;
            /// <summary>free nodes avail to non-superuser</summary>
            Int64 f_ffree;
            /// <summary>count of sync writes since mount</summary>
            UInt64 f_syncwrites;
            /// <summary>count of async writes since mount</summary>
            UInt64 f_asyncwrites;
            /// <summary>count of sync reads since mount</summary>
            UInt64 f_syncreads;
            /// <summary>count of async reads since mount</summary>
            UInt64 f_asyncreads;
            /// <summary>unused spare</summary>
            [MarshalAs(UnmanagedType.ByValArray, 
                ArraySubType = UnmanagedType.U8, SizeConst = 10)]
            [Obsolete("RESERVED: DO NOT USE")]
            UInt64[] f_spare;
            /// <summary>maximum filename length</summary>
            UInt32 f_namemax;
            /// <summary>user that mounted the filesystem</summary>
            UInt32 f_owner;
            /// <summary>filesystem id</summary>
            fsid_t f_fsid;
            /// <summary>spare string space</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            string f_charspare;
            /// <summary>filesystem type name</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            string f_fstypename;
            /// <summary>mounted filesystem</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 88)]
            string f_mntfromname;
            /// <summary>directory on which mounted</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 88)]
            string f_mntonname;

        }

        /// <summary>
        /// Obtains information of the file system mounted at <paramref name="path"/>.
        /// Calls to system's statfs(2)
        /// </summary>
        /// <param name="path">Path to the filesystem mount point.</param>
        /// <param name="buf"><see cref="StatFS"/>.</param>
        /// <returns>On success, 0. On failure, -1, and errno is set.</returns>
        [DllImport(Libraries.Libc, SetLastError = true)]
        public static extern int statfs(string path, out StatFS buf);
    }
}

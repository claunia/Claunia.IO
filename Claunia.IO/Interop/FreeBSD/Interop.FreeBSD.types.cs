//
// Interop.FreeBSD.types.cs
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
        [StructLayout(LayoutKind.Sequential)]
        internal struct Timespec
        {
            /// <summary>
            /// Seconds
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public Int32 tv_sec;
            /// <summary>
            /// Nanoseconds
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public Int32 tv_nsec;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct Timespec64
        {
            /// <summary>
            /// Seconds
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public Int64 tv_sec;
            /// <summary>
            /// Nanoseconds
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public Int64 tv_nsec;
        }

        /// <summary>
        /// File system ID type
        /// </summary>
        struct fsid_t
        {
            public Int32 val1;
            public Int32 val2;
        }

        [Flags]
        enum mntflags_t : UInt64
        {
            MNT_RDONLY = 0x0000000000000001,
            /// <summary>read only filesystem</summary>
            MNT_SYNCHRONOUS = 0x0000000000000002,
            /// <summary>fs written synchronously</summary>
            MNT_NOEXEC = 0x0000000000000004,
            /// <summary>can't exec from filesystem</summary>
            MNT_NOSUID = 0x0000000000000008,
            /// <summary>don't honor setuid fs bits</summary>
            MNT_NFS4ACLS = 0x0000000000000010,
            /// <summary>enable NFS version 4 ACLs</summary>
            MNT_UNION = 0x0000000000000020,
            /// <summary>union with underlying fs</summary>
            MNT_ASYNC = 0x0000000000000040,
            /// <summary>fs written asynchronously</summary>
            MNT_SUIDDIR = 0x0000000000100000,
            /// <summary>special SUID dir handling</summary>
            MNT_SOFTDEP = 0x0000000000200000,
            /// <summary>using soft updates</summary>
            MNT_NOSYMFOLLOW = 0x0000000000400000,
            /// <summary>do not follow symlinks</summary>
            MNT_GJOURNAL = 0x0000000002000000,
            /// <summary>GEOM journal support enabled</summary>
            MNT_MULTILABEL = 0x0000000004000000,
            /// <summary>MAC support for objects</summary>
            MNT_ACLS = 0x0000000008000000,
            /// <summary>ACL support enabled</summary>
            MNT_NOATIME = 0x0000000010000000,
            /// <summary>dont update file access time</summary>
            MNT_NOCLUSTERR = 0x0000000040000000,
            /// <summary>disable cluster read</summary>
            MNT_NOCLUSTERW = 0x0000000080000000,
            /// <summary>disable cluster write</summary>
            MNT_SUJ = 0x0000000100000000,
            /// <summary>using journaled soft updates</summary>
            MNT_AUTOMOUNTED = 0x0000000200000000,
            /// <summary>mounted by automountd(8)</summary>
             
            /*
              * NFS export related mount flags.
              */
            MNT_EXRDONLY = 0x0000000000000080,
            /// <summary>exported read only</summary>
            MNT_EXPORTED = 0x0000000000000100,
            /// <summary>filesystem is exported</summary>
            MNT_DEFEXPORTED = 0x0000000000000200,
            /// <summary>exported to the world</summary>
            MNT_EXPORTANON = 0x0000000000000400,
            /// <summary>anon uid mapping for all</summary>
            MNT_EXKERB = 0x0000000000000800,
            /// <summary>exported with Kerberos</summary>
            MNT_EXPUBLIC = 0x0000000020000000,
            /// <summary>public export (WebNFS)</summary>
             
            /*
              * Flags set by internal operations,
              * but visible to the user.
              * XXX some of these are not quite right.. (I've never seen the root flag set)
              */
            MNT_LOCAL = 0x0000000000001000,
            /// <summary>filesystem is stored locally</summary>
            MNT_QUOTA = 0x0000000000002000,
            /// <summary>quotas are enabled on fs</summary>
            MNT_ROOTFS = 0x0000000000004000,
            /// <summary>identifies the root fs</summary>
            MNT_USER = 0x0000000000008000,
            /// <summary>mounted by a user</summary>
            MNT_IGNORE = 0x0000000000800000
            /// <summary>do not show entry in df</summary>
        }
    }
}
//
// Interop.Linux.types.cs
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
        enum f_type_t : uint
        {
            ADFS_SUPER_MAGIC = 0xadf5,
            AFFS_SUPER_MAGIC = 0xADFF,
            AFS_SUPER_MAGIC = 0x5346414F,
            ANON_INODE_FS_MAGIC = 0x09041934,
            AUTOFS_SUPER_MAGIC = 0x0187,
            BDEVFS_MAGIC = 0x62646576,
            BEFS_SUPER_MAGIC = 0x42465331,
            BFS_MAGIC = 0x1BADFACE,
            BINFMTFS_MAGIC = 0x42494e4d,
            BTRFS_SUPER_MAGIC = 0x9123683E,
            BTRFS_TEST_MAGIC = 0x73727279,
            CGROUP_SUPER_MAGIC = 0x27e0eb,
            CIFS_MAGIC_NUMBER = 0xFF534D42,
            CODA_SUPER_MAGIC = 0x73757245,
            COH_SUPER_MAGIC = 0x012FF7B7,
            CRAMFS_MAGIC = 0x28cd3d45,
            CRAMFS_MAGIC_WEND = 0x453dcd28,
            /* magic number with the wrong endianess */
            DEBUGFS_MAGIC = 0x64626720,
            DEVFS_SUPER_MAGIC = 0x1373,
            DEVPTS_SUPER_MAGIC = 0x1cd1,
            ECRYPTFS_SUPER_MAGIC = 0xf15f,
            EFIVARFS_MAGIC = 0xde5e81e4,
            EFS_SUPER_MAGIC = 0x00414A53,
            EXT_SUPER_MAGIC = 0x137D,
            EXT2_OLD_SUPER_MAGIC = 0xEF51,
            EXT2_SUPER_MAGIC = 0xEF53,
            EXT3_SUPER_MAGIC = 0xEF53,
            EXT4_SUPER_MAGIC = 0xEF53,
            F2FS_SUPER_MAGIC = 0xF2F52010,
            FUSE_SUPER_MAGIC = 0x65735546,
            FUTEXFS_SUPER_MAGIC = 0xBAD1DEA,
            HFS_SUPER_MAGIC = 0x4244,
            HOSTFS_SUPER_MAGIC = 0x00c0ffee,
            HPFS_SUPER_MAGIC = 0xF995E849,
            HUGETLBFS_MAGIC = 0x958458f6,
            ISOFS_SUPER_MAGIC = 0x9660,
            JFFS2_SUPER_MAGIC = 0x72b6,
            JFS_SUPER_MAGIC = 0x3153464a,
            /// <summary>
            /// /* orig. minix */
            /// </summary>
            MINIX_SUPER_MAGIC = 0x137F,
            /// <summary>
            /// /* 30 char minix */
            /// </summary>
            MINIX_SUPER_MAGIC2 = 0x138F,
            /// <summary>
            /// /* minix V2 */
            /// </summary>
            MINIX2_SUPER_MAGIC = 0x2468,
            /// <summary>
            /// /* minix V2, 30 char names */
            /// </summary>
            MINIX2_SUPER_MAGIC2 = 0x2478,
            /// <summary>
            /// /* minix V3 fs, 60 char names */
            /// </summary>
            MINIX3_SUPER_MAGIC = 0x4d5a,
            MQUEUE_MAGIC = 0x19800202,
            MSDOS_SUPER_MAGIC = 0x4d44,
            MTD_INODE_FS_MAGIC = 0x11307854,
            NCP_SUPER_MAGIC = 0x564c,
            NFS_SUPER_MAGIC = 0x6969,
            NILFS_SUPER_MAGIC = 0x3434,
            NTFS_SB_MAGIC = 0x5346544e,
            OCFS2_SUPER_MAGIC = 0x7461636f,
            OPENPROM_SUPER_MAGIC = 0x9fa1,
            PIPEFS_MAGIC = 0x50495045,
            PROC_SUPER_MAGIC = 0x9fa0,
            PSTOREFS_MAGIC = 0x6165676C,
            QNX4_SUPER_MAGIC = 0x002f,
            QNX6_SUPER_MAGIC = 0x68191122,
            RAMFS_MAGIC = 0x858458f6,
            REISERFS_SUPER_MAGIC = 0x52654973,
            ROMFS_MAGIC = 0x7275,
            SELINUX_MAGIC = 0xf97cff8c,
            SECURITYFS_MAGIC = 0x73636673,
            SMACK_MAGIC = 0x43415d53,
            SMB_SUPER_MAGIC = 0x517B,
            SOCKFS_MAGIC = 0x534F434B,
            SQUASHFS_MAGIC = 0x73717368,
            STACK_END_MAGIC = 0x57AC6E9D,
            SYSFS_MAGIC = 0x62656572,
            SYSV2_SUPER_MAGIC = 0x012FF7B6,
            SYSV4_SUPER_MAGIC = 0x012FF7B5,
            TMPFS_MAGIC = 0x01021994,
            UDF_SUPER_MAGIC = 0x15013346,
            UFS_MAGIC = 0x00011954,
            USBDEVICE_SUPER_MAGIC = 0x9fa2,
            V9FS_MAGIC = 0x01021997,
            VXFS_SUPER_MAGIC = 0xa501FCF5,
            XENFS_SUPER_MAGIC = 0xabba1974,
            XENIX_SUPER_MAGIC = 0x012FF7B4,
            XFS_SUPER_MAGIC = 0x58465342,
            _XIAFS_SUPER_MAGIC = 0x012FD16D
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
        enum f_flags_t : Int32
        {
            /// <summary>
            /// This filesystem is mounted read-only.
            /// </summary>
            ST_RDONLY = 0x0001,
            /// <summary>
            /// The set-user-ID and set-group-ID bits are ignored by exec(3) for executable files on this filesystem
            /// </summary>
            ST_NOSUID = 0x0002,
            /// <summary>
            /// Disallow access to device special files on this filesystem.
            /// </summary>
            ST_NODEV = 0x0004,
            /// <summary>
            /// Execution of programs is disallowed on this filesystem.
            /// </summary>
            ST_NOEXEC = 0x0008,
            /// <summary>
            /// Writes are synched to the filesystem immediately (see the description of O_SYNC in open(2)).
            /// </summary>
            ST_SYNCHRONOUS = 0x0010,
            /// <summary>
            /// f_flags support is implemented
            /// </summary>
            ST_VALID = 0x0020,
            /// <summary>
            /// Mandatory locking is permitted on the filesystem (see fcntl(2)).
            /// </summary>
            ST_MANDLOCK = 0x0040,
            ST_WRITE = 0x0080,
            ST_APPEND = 0x0100,
            ST_IMMUTABLE = 0x0200,
            /// <summary>
            /// Do not update access times; see mount(2).
            /// </summary>
            ST_NOATIME = 0x0400,
            /// <summary>
            /// Do not update directory access times; see mount(2).
            /// </summary>
            ST_NODIRATIME = 0x0800,
            /// <summary>
            /// Update atime relative to mtime/ctime; see mount(2).
            /// </summary>
            ST_RELATIME = 0x1000
        }

        [Flags]
        enum f_flags64_t : Int64
        {
            /// <summary>
            /// This filesystem is mounted read-only.
            /// </summary>
            ST_RDONLY = 0x0001,
            /// <summary>
            /// The set-user-ID and set-group-ID bits are ignored by exec(3) for executable files on this filesystem
            /// </summary>
            ST_NOSUID = 0x0002,
            /// <summary>
            /// Disallow access to device special files on this filesystem.
            /// </summary>
            ST_NODEV = 0x0004,
            /// <summary>
            /// Execution of programs is disallowed on this filesystem.
            /// </summary>
            ST_NOEXEC = 0x0008,
            /// <summary>
            /// Writes are synched to the filesystem immediately (see the description of O_SYNC in open(2)).
            /// </summary>
            ST_SYNCHRONOUS = 0x0010,
            /// <summary>
            /// f_flags support is implemented
            /// </summary>
            ST_VALID = 0x0020,
            /// <summary>
            /// Mandatory locking is permitted on the filesystem (see fcntl(2)).
            /// </summary>
            ST_MANDLOCK = 0x0040,
            ST_WRITE = 0x0080,
            ST_APPEND = 0x0100,
            ST_IMMUTABLE = 0x0200,
            /// <summary>
            /// Do not update access times; see mount(2).
            /// </summary>
            ST_NOATIME = 0x0400,
            /// <summary>
            /// Do not update directory access times; see mount(2).
            /// </summary>
            ST_NODIRATIME = 0x0800,
            /// <summary>
            /// Update atime relative to mtime/ctime; see mount(2).
            /// </summary>
            ST_RELATIME = 0x1000
        }
    }
}
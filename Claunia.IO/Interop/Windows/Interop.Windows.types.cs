//
// Interop.Windows.types.cs
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
    internal static partial class Windows
    {
        [Flags]
        public enum ACCESS_MASK : UInt32
        {
            /// <summary>Right to read data from the file. (FILE)</summary>
            FILE_READ_DATA = 0x00000001,
            /// <summary>Right to list contents of a directory. (DIRECTORY)</summary>
            FILE_LIST_DIRECTORY = 0x00000001,

            /// <summary>Right to write data to the file. (FILE)</summary>
            FILE_WRITE_DATA = 0x00000002,
            /// <summary>Right to create a file in the directory. (DIRECTORY)</summary>
            FILE_ADD_FILE = 0x00000002,

            /// <summary>Right to append data to the file. (FILE)</summary>
            FILE_APPEND_DATA = 0x00000004,
            /// <summary>Right to create a subdirectory. (DIRECTORY)</summary>
            FILE_ADD_SUBDIRECTORY = 0x00000004,

            /// <summary>Right to read extended attributes. (FILE/DIRECTORY)</summary>
            FILE_READ_EA = 0x00000008,

            /// <summary>Right to write extended attributes. (FILE/DIRECTORY)</summary>
            FILE_WRITE_EA = 0x00000010,

            /// <summary>Right to execute a file. (FILE)</summary>
            FILE_EXECUTE = 0x00000020,
            /// <summary>Right to traverse the directory. (DIRECTORY)</summary>
            FILE_TRAVERSE = 0x00000020,

            /// <summary>
            /// Right to delete a directory and all the files it contains (its
            /// children, even if the files are read-only. (DIRECTORY)
            /// </summary>
            FILE_DELETE_CHILD = 0x00000040,

            /// <summary>Right to read file attributes. (FILE/DIRECTORY)</summary>
            FILE_READ_ATTRIBUTES = 0x00000080,

            /// <summary>Right to change file attributes. (FILE/DIRECTORY)</summary>
            FILE_WRITE_ATTRIBUTES = 0x00000100,

            /// <summary>
            /// The standard rights (bits 16 to 23). Are independent of the type of
            /// object being secured.
            /// </summary>

            /// <summary>Right to delete the object.</summary>
            DELETE = 0x00010000,

            /// <summary>
            /// Right to read the information in the object's security descriptor,
            /// not including the information in the SACL. I.e. right to read the
            /// security descriptor and owner.
            /// </summary>
            READ_CONTROL = 0x00020000,

            /// <summary>Right to modify the DACL in the object's security descriptor.</summary>
            WRITE_DAC = 0x00040000,

            /// <summary>Right to change the owner in the object's security descriptor.</summary>
            WRITE_OWNER = 0x00080000,

            /// <summary>
            /// Right to use the object for synchronization. Enables a process to
            /// wait until the object is in the signalled state. Some object types
            /// do not support this access right.
            /// </summary>
            SYNCHRONIZE = 0x00100000,

            /// <summary>
            /// The following STANDARD_RIGHTS_* are combinations of the above for
            /// convenience and are defined by the Win32 API.
            /// </summary>

            /// <summary>These are currently defined to READ_CONTROL.</summary>
            STANDARD_RIGHTS_READ = 0x00020000,
            STANDARD_RIGHTS_WRITE = 0x00020000,
            STANDARD_RIGHTS_EXECUTE = 0x00020000,

            /// <summary>Combines DELETE, READ_CONTROL, WRITE_DAC, and WRITE_OWNER access.</summary>
            STANDARD_RIGHTS_REQUIRED = 0x000f0000,

            /// <summary>
            /// Combines DELETE, READ_CONTROL, WRITE_DAC, WRITE_OWNER, and
            /// SYNCHRONIZE access.
            /// </summary>
            STANDARD_RIGHTS_ALL = 0x001f0000,

            /// <summary>
            /// The access system ACL and maximum allowed access types (bits 24 to
            /// 25, bits 26 to 27 are reserved).
            /// </summary>
            ACCESS_SYSTEM_SECURITY = 0x01000000,
            MAXIMUM_ALLOWED = 0x02000000,

            /// <summary>
            /// The generic rights (bits 28 to 31). These map onto the standard and
            /// specific rights.
            /// </summary>

            /// <summary>Read, write, and execute access.</summary>
            GENERIC_ALL = 0x10000000,

            /// <summary>Execute access.</summary>
            GENERIC_EXECUTE = 0x20000000,

            /// <summary>
            /// Write access. For files, this maps onto:
            ///  FILE_APPEND_DATA | FILE_WRITE_ATTRIBUTES | FILE_WRITE_DATA |
            ///  FILE_WRITE_EA | STANDARD_RIGHTS_WRITE | SYNCHRONIZE
            /// For directories, the mapping has the same numerical value. See
            /// above for the descriptions of the rights granted.
            /// </summary>
            GENERIC_WRITE = 0x40000000,

            /// <summary>
            /// Read access. For files, this maps onto:
            ///  FILE_READ_ATTRIBUTES | FILE_READ_DATA | FILE_READ_EA |
            ///  STANDARD_RIGHTS_READ | SYNCHRONIZE
            /// For directories, the mapping has the same numerical value. See
            /// above for the descriptions of the rights granted.
            /// </summary>
            GENERIC_READ = 0x80000000,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct UNICODE_STRING : IDisposable
        {
            public ushort Length;
            public ushort MaximumLength;
            private IntPtr buffer;

            public UNICODE_STRING(string s)
            {
                Length = (ushort)(s.Length * 2);
                MaximumLength = (ushort)(Length + 2);
                buffer = Marshal.StringToHGlobalUni(s);
            }

            public void Dispose()
            {
                Marshal.FreeHGlobal(buffer);
                buffer = IntPtr.Zero;
            }

            public override string ToString()
            {
                return Marshal.PtrToStringUni(buffer);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct OBJECT_ATTRIBUTES : IDisposable
        {
            public int Length;
            public IntPtr RootDirectory;
            private IntPtr objectName;
            public uint Attributes;
            public IntPtr SecurityDescriptor;
            public IntPtr SecurityQualityOfService;

            public OBJECT_ATTRIBUTES(string name, uint attrs)
            {
                Length = 0;
                RootDirectory = IntPtr.Zero;
                objectName = IntPtr.Zero;
                Attributes = attrs;
                SecurityDescriptor = IntPtr.Zero;
                SecurityQualityOfService = IntPtr.Zero;

                Length = Marshal.SizeOf(this);
                ObjectName = new UNICODE_STRING(name);
            }

            public UNICODE_STRING ObjectName
            {
                get
                {
                    return (UNICODE_STRING)Marshal.PtrToStructure(
                        objectName, typeof(UNICODE_STRING));
                }

                set
                {
                    bool fDeleteOld = objectName != IntPtr.Zero;
                    if (!fDeleteOld)
                        objectName = Marshal.AllocHGlobal(Marshal.SizeOf(value));
                    Marshal.StructureToPtr(value, objectName, fDeleteOld);
                }
            }

            public void Dispose()
            {
                if (objectName != IntPtr.Zero)
                {
                    Marshal.DestroyStructure(objectName, typeof(UNICODE_STRING));
                    Marshal.FreeHGlobal(objectName);
                    objectName = IntPtr.Zero;
                }
            }
        }
    }
}
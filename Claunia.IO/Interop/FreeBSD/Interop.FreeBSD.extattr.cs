//
// Interop.Apple.xattr.cs
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

internal static partial class Interop
{
    internal static partial class FreeBSD
    {
        public enum attrNamespace
        {
            /// <summary>
            /// Empty namespace
            /// </summary>
            EXTATTR_NAMESPACE_EMPTY = 0x00000000,
            /// <summary>
            /// User namespace
            /// </summary>
            EXTATTR_NAMESPACE_USER = 0x00000001,
            /// <summary>
            /// System namespace
            /// </summary>
            EXTATTR_NAMESPACE_SYSTEM = 0x00000002
        }

        /// <summary>
        /// Gets an extended attribute value
        /// Calls to system's extattr_get_file(2)
        /// </summary>
        /// <returns>Number of bytes read. If <paramref name="data"/> is <see cref="null"/>, then the size for the buffer to store the data.</returns>
        /// <param name="path">Path to the file.</param>
        /// <param name="attrnamespace">Extended attribute namespace, <see cref="attrNamespace"/>.</param>
        /// <param name="attrname">Extended attribute name.</param>
        /// <param name="data">Pointer to buffer where to store the data.</param>
        /// <param name="nbytes">Size of the buffer.</param>
        [DllImport(Libraries.Libc, SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern Int64 extattr_get_file(string path, attrNamespace attrnamespace, string attrname, IntPtr data, Int64 nbytes);

        /// <summary>
        /// Sets an extended attribute value
        /// Calls to system's extattr_set_file(2)
        /// </summary>
        /// <returns>Number of bytes written.</returns>
        /// <param name="path">Path to the file.</param>
        /// <param name="attrnamespace">Extended attribute namespace, <see cref="attrNamespace"/>.</param>
        /// <param name="attrname">Extended attribute name.</param>
        /// <param name="data">Pointer where the data is stored.</param>
        /// <param name="nbytes">Size of the data.</param>
        [DllImport(Libraries.Libc, SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern Int64 extattr_set_file(string path, attrNamespace attrnamespace, string attrname, IntPtr data, Int64 nbytes);

        /// <summary>
        /// Deletes an extended attribute value
        /// Calls to system's extattr_delete_file(2)
        /// </summary>
        /// <returns>0 if successful, -1 if failure.</returns>
        /// <param name="path">Path to the file.</param>
        /// <param name="attrnamespace">Extended attribute namespace, <see cref="attrNamespace"/>.</param>
        /// <param name="attrname">Extended attribute name.</param>
        /// <param name="data">Pointer to buffer where the data is stored.</param>
        /// <param name="nbytes">Size of the pointer.</param>
        [DllImport(Libraries.Libc, SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern Int64 extattr_delete_file(string path, attrNamespace attrnamespace, string attrname);

        /// <summary>
        /// Gets a list of extended attributes that the file has in that namespace
        /// The list is stored in the buffer as an undetermined length of Pascal strings,
        /// 1 byte tells the size of the extended attribute name in bytes, and is followed by the name.
        /// Calls to system's extattr_list_file(2)
        /// </summary>
        /// <returns>Size of the list in bytes. If <paramref name="data"/> is <see cref="null"/>, then the size for the buffer to store the list.</returns>
        /// <param name="path">Path to the file.</param>
        /// <param name="attrnamespace">Extended attribute namespace, <see cref="attrNamespace"/>.</param>
        /// <param name="attrname">Extended attribute name.</param>
        /// <param name="data">Pointer to buffer where to store the list.</param>
        /// <param name="nbytes">Size of the buffer.</param>
        [DllImport(Libraries.Libc, SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern Int64 extattr_list_file(string path, attrNamespace attrnamespace, IntPtr data, Int64 nbytes);

        /// <summary>
        /// Gets an extended attribute value
        /// Calls to system's extattr_get_file(2)
        /// For 32-bit systems
        /// </summary>
        /// <returns>Number of bytes read. If <paramref name="data"/> is <see cref="null"/>, then the size for the buffer to store the data.</returns>
        /// <param name="path">Path to the file.</param>
        /// <param name="attrnamespace">Extended attribute namespace, <see cref="attrNamespace"/>.</param>
        /// <param name="attrname">Extended attribute name.</param>
        /// <param name="data">Pointer to buffer where to store the data.</param>
        /// <param name="nbytes">Size of the buffer.</param>
        [DllImport(Libraries.Libc, SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "extattr_get_file")]
        public static extern Int32 extattr_get_file32(string path, attrNamespace attrnamespace, string attrname, IntPtr data, Int32 nbytes);

        /// <summary>
        /// Sets an extended attribute value
        /// Calls to system's extattr_set_file(2)
        /// For 32-bit systems
        /// </summary>
        /// <returns>Number of bytes written.</returns>
        /// <param name="path">Path to the file.</param>
        /// <param name="attrnamespace">Extended attribute namespace, <see cref="attrNamespace"/>.</param>
        /// <param name="attrname">Extended attribute name.</param>
        /// <param name="data">Pointer where the data is stored.</param>
        /// <param name="nbytes">Size of the data.</param>
        [DllImport(Libraries.Libc, SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "extattr_set_file")]
        public static extern Int32 extattr_set_file32(string path, attrNamespace attrnamespace, string attrname, IntPtr data, Int32 nbytes);

        /// <summary>
        /// Deletes an extended attribute value
        /// Calls to system's extattr_delete_file(2)
        /// For 32-bit systems
        /// </summary>
        /// <returns>0 if successful, -1 if failure.</returns>
        /// <param name="path">Path to the file.</param>
        /// <param name="attrnamespace">Extended attribute namespace, <see cref="attrNamespace"/>.</param>
        /// <param name="attrname">Extended attribute name.</param>
        /// <param name="data">Pointer to buffer where the data is stored.</param>
        /// <param name="nbytes">Size of the pointer.</param>
        [DllImport(Libraries.Libc, SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "extattr_delete_file")]
        public static extern Int32 extattr_delete_file32(string path, attrNamespace attrnamespace, string attrname);

        /// <summary>
        /// Gets a list of extended attributes that the file has in that namespace
        /// The list is stored in the buffer as an undetermined length of Pascal strings,
        /// 1 byte tells the size of the extended attribute name in bytes, and is followed by the name.
        /// Calls to system's extattr_list_file(2)
        /// For 32-bit systems
        /// </summary>
        /// <returns>Size of the list in bytes. If <paramref name="data"/> is <see cref="null"/>, then the size for the buffer to store the list.</returns>
        /// <param name="path">Path to the file.</param>
        /// <param name="attrnamespace">Extended attribute namespace, <see cref="attrNamespace"/>.</param>
        /// <param name="attrname">Extended attribute name.</param>
        /// <param name="data">Pointer to buffer where to store the list.</param>
        /// <param name="nbytes">Size of the buffer.</param>
        [DllImport(Libraries.Libc, SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "extattr_list_file")]
        public static extern Int32 extattr_list_file32(string path, attrNamespace attrnamespace, IntPtr data, Int32 nbytes);
    }
}


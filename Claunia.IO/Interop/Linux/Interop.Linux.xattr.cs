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
    internal static partial class Linux
    {
        public enum xattrFlags : int
        {
            /// <summary>
            /// Set the value and fail if the xattr already exists
            /// </summary>
            XATTR_CREATE = 0x0001,
            /// <summary>
            /// Set the value and fail if the xattr does not exist
            /// </summary>
            XATTR_REPLACE = 0x0002
        }

        /// <summary>
        /// Gets an extended attribute value
        /// Calls to system's getxattr(2)
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <param name="name">Name of the extended attribute.</param>
        /// <param name="value">Pointer to a buffer where to store the extended attribute.</param>
        /// <param name="size">Size of the allocated buffer.</param>
        /// <returns>Size of the extended attribute. On failure, -1, and errno is set</returns>
        [DllImport(Libraries.Libc, SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern Int64 getxattr(string path, string name, IntPtr value, UInt64 size);

        /// <summary>
        /// Sets an extended attribute value
        /// Calls to system's setxattr(2)
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <param name="name">Name of the extended attribute.</param>
        /// <param name="value">Pointer to a buffer where the extended attribute is stored.</param>
        /// <param name="size">Size of the allocated buffer.</param>
        /// <returns>On success, 0. On failure, -1, and errno is set</returns>
        [DllImport(Libraries.Libc, SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern Int64 setxattr(string path, string name, IntPtr value, UInt64 size, xattrFlags options);

        /// <summary>
        /// Removes an extended attribute
        /// Calls to system's removexattr(2)
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <param name="name">Name of the extended attribute.</param>
        /// <returns>On success, 0. On failure, -1, and errno is set</returns>
        [DllImport(Libraries.Libc, SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern Int64 removexattr(string path, string name);

        /// <summary>
        /// Lists the extended attributes from a file
        /// Calls to system's listxattr(2)
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <param name="namebuf">Pointer to a buffer where an unordered list of null terminated strings wth the extended attributes names is to be stored.</param>
        /// <param name="size">Size of the allocated buffer.</param>
        /// <returns>If <paramref name="namebuf"/> is set to null, the needed size to store the whole list.
        /// On success, the size of the list.
        /// If the file has no extended attributes, 0.
        /// On failure, -1, and errno is set</returns>
        [DllImport(Libraries.Libc, SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern Int64 listxattr(string path, IntPtr namebuf, UInt64 size);


        /// <summary>
        /// Gets an extended attribute value
        /// Calls to system's getxattr(2)
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <param name="name">Name of the extended attribute.</param>
        /// <param name="value">Pointer to a buffer where to store the extended attribute.</param>
        /// <param name="size">Size of the allocated buffer.</param>
        /// <returns>Size of the extended attribute. On failure, -1, and errno is set</returns>
        [DllImport(Libraries.Libc, SetLastError = true, EntryPoint = "getxattr", CharSet = CharSet.Ansi)]
        public static extern int getxattr32(string path, string name, IntPtr value, UInt32 size);

        /// <summary>
        /// Sets an extended attribute value
        /// Calls to system's setxattr(2)
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <param name="name">Name of the extended attribute.</param>
        /// <param name="value">Pointer to a buffer where the extended attribute is stored.</param>
        /// <param name="size">Size of the allocated buffer.</param>
        /// <returns>On success, 0. On failure, -1, and errno is set</returns>
        [DllImport(Libraries.Libc, SetLastError = true, EntryPoint = "setxattr", CharSet = CharSet.Ansi)]
        public static extern int setxattr32(string path, string name, IntPtr value, UInt32 size, xattrFlags options);

        /// <summary>
        /// Removes an extended attribute
        /// Calls to system's removexattr(2)
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <param name="name">Name of the extended attribute.</param>
        /// <returns>On success, 0. On failure, -1, and errno is set</returns>
        [DllImport(Libraries.Libc, SetLastError = true, EntryPoint = "removexattr", CharSet = CharSet.Ansi)]
        public static extern int removexattr32(string path, string name);

        /// <summary>
        /// Lists the extended attributes from a file
        /// Calls to system's listxattr(2)
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <param name="namebuf">Pointer to a buffer where an unordered list of null terminated strings wth the extended attributes names is to be stored.</param>
        /// <param name="size">Size of the allocated buffer.</param>
        /// <returns>If <paramref name="namebuf"/> is set to null, the needed size to store the whole list.
        /// On success, the size of the list.
        /// If the file has no extended attributes, 0.
        /// On failure, -1, and errno is set</returns>
        [DllImport(Libraries.Libc, SetLastError = true, EntryPoint = "listxattr", CharSet = CharSet.Ansi)]
        public static extern int listxattr32(string path, IntPtr namebuf, UInt32 size);
    }
}


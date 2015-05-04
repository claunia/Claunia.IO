//
// Interop.Windows.Files.cs
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
using Microsoft.Win32.SafeHandles;
using System.IO;

internal static partial class Interop
{
    internal static partial class Windows
    {

        public enum CreateDispositionFlags : uint
        {
            /// <summary>
            /// Replaces the file if it exists.
            /// Creates a new file if it does not.
            /// </summary>
            FILE_SUPERSEDE = 0x00000000,
            /// <summary>
            /// Opens the file if it exists, error otherwise.
            /// </summary>
            FILE_OPEN = 0x00000001,
            /// <summary>
            /// Create the file if it does not exists, error otherwise.
            /// </summary>
            FILE_CREATE = 0x00000002,
            /// <summary>
            /// Opens the file if it exists, creates it if it does not.
            /// </summary>
            FILE_OPEN_IF = 0x00000003,
            /// <summary>
            /// Overwrites the file if it exists, error otherwise.
            /// </summary>
            FILE_OVERWRITE = 0x00000004,
            /// <summary>
            /// Overwrites the file if it exists, creates it if it does not.
            /// </summary>
            FILE_OVERWRITE_IF = 0x00000005,
            FILE_MAXIMUM_DISPOSITION = FILE_OVERWRITE_IF
        }

        public enum CreateOptionsFlags : uint
        {
            /// <summary>
            /// The file is a directory.
            /// </summary>
            FILE_DIRECTORY_FILE = 0x00000001,
            /// <summary>
            /// System services, file-system drivers, and drivers that write data to the file must actually transfer the data to the file before any requested write operation is considered complete.
            /// </summary>
            FILE_WRITE_THROUGH = 0x00000002,
            /// <summary>
            /// All access to the file will be sequential.
            /// </summary>
            FILE_SEQUENTIAL_ONLY = 0x00000004,
            /// <summary>
            /// The file cannot be cached or buffered in a driver's internal buffers. This flag is incompatible with the <see cref="ACCESS_MASK.FILE_APPEND_DATA"/> flag.
            /// </summary>
            FILE_NO_INTERMEDIATE_BUFFERING = 0x00000008,

            /// <summary>
            /// All operations on the file are performed synchronously. Any wait on behalf of the caller is subject to premature termination from alerts. This flag also causes the I/O system to maintain the file-position pointer. If this flag is set, <see cref="ACCESS_MASK.SYNCHRONIZE"/> must be set.
            /// </summary>
            FILE_SYNCHRONOUS_IO_ALERT = 0x00000010,
            /// <summary>
            /// All operations on the file are performed synchronously. Waits in the system that synchronize I/O queuing and completion are not subject to alerts. This flag also causes the I/O system to maintain the file-position context. If this flag is set, <see cref="ACCESS_MASK.SYNCHRONIZE"/> must be set.
            /// </summary>
            FILE_SYNCHRONOUS_IO_NONALERT = 0x00000020,
            /// <summary>
            /// The file is not a directory. The file object to open can represent a data file; a logical, virtual, or physical device; or a volume.
            /// </summary>
            FILE_NON_DIRECTORY_FILE = 0x00000040,
            /// <summary>
            /// Create a tree connection for this file in order to open it over the network.
            /// </summary>
            FILE_CREATE_TREE_CONNECTION = 0x00000080,

            /// <summary>
            /// Complete this operation immediately with an alternate success code of <see cref="NTSTATUS.STATUS_OPLOCK_BREAK_IN_PROGRESS"/> if the target file is oplocked, rather than blocking the caller's thread. If the file is oplocked, another caller already has access to the file. This flag is not used by device and intermediate drivers.
            /// </summary>
            FILE_COMPLETE_IF_OPLOCKED = 0x00000100,
            /// <summary>
            /// If the extended attributes (EAs) for an existing file being opened indicate that the caller must understand EAs to properly interpret the file, NtCreateFile should return an error.
            /// </summary>
            FILE_NO_EA_KNOWLEDGE = 0x00000200,
            /// <summary>
            /// Undocumented
            /// </summary>
            FILE_OPEN_REMOTE_INSTANCE = 0x00000400,
            /// <summary>
            /// Access to the file can be random, so no sequential read-ahead operations should be performed by file-system drivers or by the system.
            /// </summary>
            FILE_RANDOM_ACCESS = 0x00000800,

            /// <summary>
            /// The system deletes the file when the last handle to the file is passed to NtClose. If this flag is set, the <see cref="ACCESS_MASK.DELETE"/> flag must be set.
            /// </summary>
            FILE_DELETE_ON_CLOSE = 0x00001000,
            /// <summary>
            /// The file name that is specified by the ObjectAttributes parameter includes a binary 8-byte or 16-byte file reference number or object ID for the file, depending on the file system.
            /// </summary>
            FILE_OPEN_BY_FILE_ID = 0x00002000,
            /// <summary>
            /// The file is being opened for backup intent. Therefore, the system should check for certain access rights and grant the caller the appropriate access to the file—before checking the DesiredAccess parameter against the file's security descriptor.
            /// </summary>
            FILE_OPEN_FOR_BACKUP_INTENT = 0x00004000,
            /// <summary>
            /// Undocumented
            /// </summary>
            FILE_NO_COMPRESSION = 0x00008000,

            /// <summary>
            /// The file is being opened and an opportunistic lock (oplock) on the file is being requested as a single atomic operation. The file system checks for oplocks before it performs the create operation, and will fail the create with a return code of <see cref="NTSTATUS.STATUS_CANNOT_BREAK_OPLOCK"/> if the result would be to break an existing oplock.
            /// </summary>
            FILE_OPEN_REQUIRING_OPLOCK = 0x00010000,
            /// <summary>
            /// Undocumented
            /// </summary>
            FILE_DISALLOW_EXCLUSIVE = 0x00020000,

            /// <summary>
            /// This flag allows an application to request a Filter opportunistic lock (oplock) to prevent other applications from getting share violations. If there are already open handles, the create request will fail with <see cref="NTSTATUS.STATUS_OPLOCK_NOT_GRANTED"/>.
            /// </summary>
            FILE_RESERVE_OPFILTER = 0x00100000,
            /// <summary>
            /// Open a file with a reparse point and bypass normal reparse point processing for the file.
            /// </summary>
            FILE_OPEN_REPARSE_POINT = 0x00200000,
            /// <summary>
            /// Undocumented
            /// </summary>
            FILE_OPEN_NO_RECALL = 0x00400000,
            /// <summary>
            /// Undocumented
            /// </summary>
            FILE_OPEN_FOR_FREE_SPACE_QUERY = 0x00800000,

            FILE_VALID_OPTION_FLAGS = 0x00ffffff,
            FILE_VALID_PIPE_OPTION_FLAGS = 0x00000032,
            FILE_VALID_MAILSLOT_OPTION_FLAGS = 0x00000032,
            FILE_VALID_SET_FLAGS = 0x00000036
        }

        /// <summary>
        /// Creates a new file or opens an existing file.
        /// </summary>
        /// <returns>ZwCreateFile returns <see cref="NTSTATUS.STATUS_SUCCESS"/> on success or an appropriate <see cref="NTSTATUS"/> error code on failure. In the latter case, the caller can determine the cause of the failure by checking the <paramref name="IoStatusBlock"/> parameter.</returns>
        /// <param name="FileHandle">A pointer to a HANDLE variable that receives a handle to the file.</param>
        /// <param name="DesiredAccess">Specifies an <see cref="ACCESS_MASK"/> value that determines the requested access to the object. In addition to the access rights that are defined for all types of objects, the caller can specify any of the following access rights, which are specific to files.</param>
        /// <param name="ObjectAttributes">A pointer to an <see cref="OBJECT_ATTRIBUTES"/> structure that specifies the object name and other attributes.</param>
        /// <param name="IoStatusBlock">A pointer to an <see cref="IO_STATUS_BLOCK"/> structure that receives the final completion status and other information about the requested operation.</param>
        /// <param name="AllocationSize">A pointer to a LARGE_INTEGER that contains the initial allocation size, in bytes, for a file that is created or overwritten. If AllocationSize is <c>null</c>, no allocation size is specified. If no file is created or overwritten, AllocationSize is ignored.</param>
        /// <param name="FileAttributes">Specifies one or more FILE_ATTRIBUTE_XXX flags, which represent the file attributes to set if you create or overwrite a file. The caller usually specifies FILE_ATTRIBUTE_NORMAL, which sets the default attributes. For a list of valid FILE_ATTRIBUTE_XXX flags, see the CreateFile routine in the Microsoft Windows SDK documentation. If no file is created or overwritten, FileAttributes is ignored.</param>
        /// <param name="ShareAccess">Type of share access.</param>
        /// <param name="CreateDisposition">Specifies the action to perform if the file does or does not exist. <see cref="CreateDispositionFlags"/></param>
        /// <param name="CreateOptions">Specifies the options to apply when the file is created or opened. <see cref="CreateOptionsFlags"/></param>
        /// <param name="EaBuffer">Pointer to a <see cref="FILE_FULL_EA_INFORMATION"/>-structured buffer that contains the starting attributes to write to the file when creating, replacing or overwriting it.</param>
        /// <param name="EaLength">Length of the buffer pointed by <paramref name="EaBuffer"/></param>
        [DllImport(Libraries.NTDLL)]
        public static extern NTSTATUS NtCreateFile(out SafeFileHandle FileHandle,
                                                   ACCESS_MASK DesiredAccess, ref OBJECT_ATTRIBUTES ObjectAttributes,
                                                   ref IO_STATUS_BLOCK IoStatusBlock, ref long AllocationSize, uint FileAttributes,
                                                   System.IO.FileShare ShareAccess, CreateDispositionFlags CreateDisposition, CreateOptionsFlags CreateOptions,
                                                   IntPtr EaBuffer, uint EaLength);

        /// <summary>
        /// Closes an object handle
        /// </summary>
        /// <returns>returns <see cref="NTSTATUS.STATUS_SUCCESS"/> on success, or the appropriate <see cref="NTSTATUS"/> error code on failure. In particular, it returns <see cref="NTSTATUS.STATUS_INVALID_HANDLE"/> if Handle is not a valid handle, or <see cref="NTSTATUS.STATUS_HANDLE_NOT_CLOSABLE"/> if the calling thread does not have permission to close the handle.</returns>
        /// <param name="handle">Handle to an object of any type.</param>
        [DllImport(Libraries.NTDLL)]
        public static extern NTSTATUS NtClose(SafeFileHandle handle);

        /// <summary>
        /// Creates or opens a file or I/O device. The most commonly used I/O devices are as follows: file, file stream, directory, physical disk, volume, console buffer, tape drive, communications resource, mailslot, and pipe. The function returns a handle that can be used to access the file or device for various types of I/O depending on the file or device and the flags and attributes specified.
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is an open handle to the specified file, device, named pipe, or mail slot.
        /// If the function fails, <see cref="SafeFileHandle.IsInvalid"/> is set.
        /// </returns>
        /// <param name="lpFileName">The name of the file or device to be created or opened. You may use either forward slashes (/) or backslashes (\) in this name.</param>
        /// <param name="dwDesiredAccess">The requested access to the file or device, which can be summarized as read, write, both or neither (zero).</param>
        /// <param name="dwShareMode">The requested sharing mode of the file or device, which can be read, write, both, delete, all of these, or none (refer to the following table). Access requests to attributes or extended attributes are not affected by this flag.</param>
        /// <param name="lpSecurityAttributes">A pointer to a SECURITY_ATTRIBUTES structure that contains two separate but related data members: an optional security descriptor, and a Boolean value that determines whether the returned handle can be inherited by child processes. This parameter can be <c>null</c>.</param>
        /// <param name="dwCreationDisposition">An action to take on a file or device that exists or does not exist.</param>
        /// <param name="dwFlagsAndAttributes">The file or device attributes and flags.</param>
        /// <param name="hTemplateFile">A valid handle to a template file with the GENERIC_READ access right. The template file supplies file attributes and extended attributes for the file that is being created. This parameter can be <c>null</c>.</param>
        [DllImport(Libraries.Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern SafeFileHandle CreateFile(string lpFileName,
            FileAccess dwDesiredAccess, FileShare dwShareMode,
            IntPtr lpSecurityAttributes, FileMode dwCreationDisposition,
            int dwFlagsAndAttributes, IntPtr hTemplateFile);
    }
}


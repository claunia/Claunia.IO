﻿//
// FileInfo.cs
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
using System.Runtime.Serialization;
using System.Security;
using System;
using System.IO;

#if !MOBILE
using System.Security.AccessControl;
#endif

namespace Claunia.IO
{
    [SerializableAttribute]
    [ComVisibleAttribute(true)]
    public sealed class FileInfo : System.IO.FileSystemInfo
    {
        // As FileInfo is sealed, let's gonna cheat a little :p
        readonly System.IO.FileInfo _fileInfo;

        public FileInfo (string fileName)
        {
            _fileInfo = new System.IO.FileInfo(fileName);
        }

        // For manual casting
        public FileInfo (System.IO.FileInfo fileInfo)
        {
            _fileInfo = fileInfo;
        }

        public override bool Exists {
            get {
                return _fileInfo.Exists;
            }
        }

        public override string Name {
            get {
                return _fileInfo.Name;
            }
        }

        public bool IsReadOnly {
            get {
                return _fileInfo.IsReadOnly;
            }

            set {
                _fileInfo.IsReadOnly = value;
            }
        }

        public void Encrypt ()
        {
            _fileInfo.Encrypt();
        }

        public void Decrypt ()
        {
            _fileInfo.Decrypt();
        }

        public long Length {
            get {
                return _fileInfo.Length;
            }
        }

        public string DirectoryName {
            get {
                return _fileInfo.DirectoryName;
            }
        }

        public DirectoryInfo Directory {
            get {
                return new DirectoryInfo(_fileInfo.Directory);
            }
        }

        public StreamReader OpenText ()
        {
            return _fileInfo.OpenText();
        }

        public StreamWriter CreateText ()
        {
            return _fileInfo.CreateText();
        }

        public StreamWriter AppendText ()
        {
            return _fileInfo.AppendText();
        }

        public FileStream Create ()
        {
            return _fileInfo.Create();
        }

        public FileStream OpenRead ()
        {
            return _fileInfo.OpenRead();
        }

        public FileStream OpenWrite ()
        {
            return _fileInfo.OpenWrite();
        }

        public FileStream Open (FileMode mode)
        {
            return _fileInfo.Open(mode);
        }

        public FileStream Open (FileMode mode, FileAccess access)
        {
            return _fileInfo.Open(mode, access);
        }

        public FileStream Open (FileMode mode, FileAccess access, FileShare share)
        {
            return _fileInfo.Open(mode, access, share);
        }

        public override void Delete ()
        {
            _fileInfo.Delete();
        }

        public void MoveTo (string destFileName)
        {
            _fileInfo.MoveTo(destFileName);
        }

        public FileInfo CopyTo (string destFileName)
        {
            System.IO.FileInfo tmpFileInfo = _fileInfo.CopyTo(destFileName);
            return new FileInfo(tmpFileInfo);
        }

        public FileInfo CopyTo (string destFileName, bool overwrite)
        {
            System.IO.FileInfo tmpFileInfo = _fileInfo.CopyTo(destFileName, overwrite);
            return new FileInfo(tmpFileInfo);
        }

        public override string ToString ()
        {
            return _fileInfo.ToString();
        }

        #if !MOBILE
        public FileSecurity GetAccessControl ()
        {
            return _fileInfo.GetAccessControl();
        }

        public FileSecurity GetAccessControl (AccessControlSections includeSections)
        {
            return _fileInfo.GetAccessControl(includeSections);
        }

        public FileInfo Replace (string destinationFileName,
            string destinationBackupFileName)
        {
            System.IO.FileInfo tmpFileInfo =_fileInfo.Replace(destinationFileName, destinationBackupFileName);
            return new FileInfo(tmpFileInfo);
        }

        public FileInfo Replace (string destinationFileName,
            string destinationBackupFileName,
            bool ignoreMetadataErrors)
        {
            System.IO.FileInfo tmpFileInfo = _fileInfo.Replace(destinationFileName, destinationBackupFileName, ignoreMetadataErrors);
            return new FileInfo(tmpFileInfo);
        }

        public void SetAccessControl (FileSecurity fileSecurity)
        {
            _fileInfo.SetAccessControl(fileSecurity);
        }
        #endif
    }
}
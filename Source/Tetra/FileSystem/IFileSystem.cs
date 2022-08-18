﻿namespace Tetra;

public interface IFileSystem
{
   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public AbsoluteDirectoryPath CurrentDirectory();

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public Error Create(AbsoluteDirectoryPath path);

   /* ------------------------------------------------------------ */

   public bool Exists(AbsoluteDirectoryPath path);

   /* ------------------------------------------------------------ */

   public IOpenFileResult<Stream> Open(AbsoluteFilePath path);

   /* ------------------------------------------------------------ */

   public IOpenFileResult<string> Read(AbsoluteFilePath path);

   /* ------------------------------------------------------------ */

   public Error SetCurrentDirectory(AbsoluteDirectoryPath path);

   /* ------------------------------------------------------------ */
}
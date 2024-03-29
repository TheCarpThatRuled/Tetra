﻿namespace Tetra.Testing;

public sealed class FileSystem : IFileSystem
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly List<AbsoluteDirectoryPath> _directories = new();

   //Mutable
   private AbsoluteDirectoryPath                         _currentDirectory;
   private Func<AbsoluteDirectoryPath, IOption<Message>> _setCurrentDirectory;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FileSystem
   (
      AbsoluteDirectoryPath currentDirectory
   )
   {
      _setCurrentDirectory = SuccessfullySetCurrentDirectory;

      _currentDirectory = currentDirectory;

      _directories.AddRange(currentDirectory.Ancestry());
   }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FileSystem From
   (
      AbsoluteDirectoryPath currentDirectory
   )
      => new(currentDirectory);

   /* ------------------------------------------------------------ */
   // IFileSystem Properties
   /* ------------------------------------------------------------ */

   public AbsoluteDirectoryPath CurrentDirectory()
      => _currentDirectory;

   /* ------------------------------------------------------------ */
   // IFileSystem Methods
   /* ------------------------------------------------------------ */

   public IOption<Message> Create
   (
      AbsoluteDirectoryPath path
   )
   {
      _directories.AddRange(path.Ancestry());

      return Option<Message>.None();
   }

   /* ------------------------------------------------------------ */

   public bool DoesNotExist
   (
      AbsoluteDirectoryPath path
   )
      => !Exists(path);

   /* ------------------------------------------------------------ */

   public bool DoesNotExist
   (
      AbsoluteFilePath path
   )
      => !Exists(path);

   /* ------------------------------------------------------------ */

   public bool Exists
   (
      AbsoluteDirectoryPath path
   )
      => _directories
        .Contains(path);

   /* ------------------------------------------------------------ */

   public bool Exists
   (
      AbsoluteFilePath path
   )
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */

   public IOpenFileResult<Stream> Open
   (
      AbsoluteFilePath path
   )
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */

   public IOpenFileResult<string> Read
   (
      AbsoluteFilePath path
   )
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */

   public IOption<Message> SetCurrentDirectory
   (
      AbsoluteDirectoryPath path
   )
      => _setCurrentDirectory(path);

   /* ------------------------------------------------------------ */

   public IEither<ISequence<AbsoluteDirectoryPath>, Message> SubDirectoriesOf
   (
      AbsoluteDirectoryPath path
   )
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */

   public IEither<ISequence<AbsoluteFilePath>, Message> SubFilesOf
   (
      AbsoluteDirectoryPath path
   )
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public void SettingTheCurrentDirectoryShallFail
   (
      Message error
   )
      => _setCurrentDirectory = _ => Option<Message>.Some(error);

   /* ------------------------------------------------------------ */

   public void SettingTheCurrentDirectoryShallSucceed()
      => _setCurrentDirectory = SuccessfullySetCurrentDirectory;

   /* ------------------------------------------------------------ */
   // Private Methods
   /* ------------------------------------------------------------ */

   private IOption<Message> SuccessfullySetCurrentDirectory
   (
      AbsoluteDirectoryPath path
   )
   {
      if (DoesNotExist(path))
      {
         return Option.Some(Messages.DirectoryNotFound(path));
      }

      _currentDirectory = path;

      return Option<Message>.None();
   }

   /* ------------------------------------------------------------ */
}
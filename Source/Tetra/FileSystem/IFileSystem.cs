namespace Tetra;

public interface IFileSystem
{
   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public AbsoluteDirectoryPath CurrentDirectory();

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public IOption<Message> Create
   (
      AbsoluteDirectoryPath path
   );

   /* ------------------------------------------------------------ */

   public bool DoesNotExist
   (
      AbsoluteDirectoryPath path
   );

   /* ------------------------------------------------------------ */

   public bool DoesNotExist
   (
      AbsoluteFilePath path
   );

   /* ------------------------------------------------------------ */

   public bool Exists
   (
      AbsoluteDirectoryPath path
   );

   /* ------------------------------------------------------------ */

   public bool Exists
   (
      AbsoluteFilePath path
   );

   /* ------------------------------------------------------------ */

   public IOpenFileResult<Stream> Open
   (
      AbsoluteFilePath path
   );

   /* ------------------------------------------------------------ */

   public IOpenFileResult<string> Read
   (
      AbsoluteFilePath path
   );

   /* ------------------------------------------------------------ */

   public IOption<Message> SetCurrentDirectory
   (
      AbsoluteDirectoryPath path
   );

   /* ------------------------------------------------------------ */

   public IEither<ISequence<AbsoluteDirectoryPath>, Message> SubDirectoriesOf
   (
      AbsoluteDirectoryPath path
   );

   /* ------------------------------------------------------------ */

   public IEither<ISequence<AbsoluteFilePath>, Message> SubFilesOf
   (
      AbsoluteDirectoryPath path
   );

   /* ------------------------------------------------------------ */
}
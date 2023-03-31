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

   public IResult<Message> Create(AbsoluteDirectoryPath path);

   /* ------------------------------------------------------------ */

   public bool DoesNotExist(AbsoluteDirectoryPath path);

   /* ------------------------------------------------------------ */

   public bool DoesNotExist(AbsoluteFilePath path);

   /* ------------------------------------------------------------ */

   public bool Exists(AbsoluteDirectoryPath path);

   /* ------------------------------------------------------------ */

   public bool Exists(AbsoluteFilePath path);

   /* ------------------------------------------------------------ */

   public IOpenFileResult<Stream> Open(AbsoluteFilePath path);

   /* ------------------------------------------------------------ */

   public IOpenFileResult<string> Read(AbsoluteFilePath path);

   /* ------------------------------------------------------------ */

   public IResult<Message> SetCurrentDirectory(AbsoluteDirectoryPath path);

   /* ------------------------------------------------------------ */

   public IResult<ISequence<AbsoluteFilePath>, Message> SubDirectoriesOf(AbsoluteDirectoryPath path);

   /* ------------------------------------------------------------ */

   public IResult<ISequence<AbsoluteFilePath>, Message> SubFileOf(AbsoluteDirectoryPath path);

   /* ------------------------------------------------------------ */
}
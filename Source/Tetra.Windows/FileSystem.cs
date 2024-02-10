namespace Tetra;

public sealed class FileSystem : IFileSystem
{
   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FileSystem() { }

   /* ------------------------------------------------------------ */
   // IFileSystem Methods
   /* ------------------------------------------------------------ */

   public AbsoluteDirectoryPath CurrentDirectory()
      => AbsoluteDirectoryPath
        .Create(Directory.GetCurrentDirectory());

   /* ------------------------------------------------------------ */

   public IOption<Message> Create
   (
      AbsoluteDirectoryPath path
   )
   {
      try
      {
         Directory.CreateDirectory(path.Value());

         return Option<Message>.None();
      }
      catch (Exception e)
      {
         return Option.Some(Message.Create(e.ToString()));
      }
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
      => Directory
        .Exists(path.Value());

   /* ------------------------------------------------------------ */

   public bool Exists
   (
      AbsoluteFilePath path
   )
      => File
        .Exists(path.Value());

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
   {
      try
      {
         Directory.SetCurrentDirectory(path.Value());

         return Option<Message>.None();
      }
      catch (Exception e)
      {
         return Option.Some(Message.Create(e.ToString()));
      }
   }

   /* ------------------------------------------------------------ */

   public IEither<ISequence<AbsoluteDirectoryPath>, Message> SubDirectoriesOf
   (
      AbsoluteDirectoryPath path
   )
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */

   public IEither<ISequence<AbsoluteFilePath>, Message> SubFileOf
   (
      AbsoluteDirectoryPath path
   )
      => throw new NotImplementedException();
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static IFileSystem Create()
      => new FileSystem();

   /* ------------------------------------------------------------ */
}
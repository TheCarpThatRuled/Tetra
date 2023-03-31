namespace Tetra;

public sealed class FileSystem : IFileSystem
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static IFileSystem Create()
      => new FileSystem();

   /* ------------------------------------------------------------ */
   // IFileSystem Methods
   /* ------------------------------------------------------------ */

   public AbsoluteDirectoryPath CurrentDirectory()
      => AbsoluteDirectoryPath
        .Create(Directory.GetCurrentDirectory());

   /* ------------------------------------------------------------ */

   public IResult<Message> Create(AbsoluteDirectoryPath path)
   {
      try
      {
         Directory.CreateDirectory(path.Value());

         return Result<Message>.Success();
      }
      catch (Exception e)
      {
         return Result.Failure(Message.Create(e.ToString()));
      }
   }

   /* ------------------------------------------------------------ */

   public bool DoesNotExist(AbsoluteDirectoryPath path)
      => !Exists(path);

   /* ------------------------------------------------------------ */

   public bool DoesNotExist(AbsoluteFilePath path)
      => !Exists(path);

   /* ------------------------------------------------------------ */

   public bool Exists(AbsoluteDirectoryPath path)
      => Directory
        .Exists(path.Value());

   /* ------------------------------------------------------------ */

   public bool Exists(AbsoluteFilePath path)
      => File
        .Exists(path.Value());

   /* ------------------------------------------------------------ */

   public IOpenFileResult<Stream> Open(AbsoluteFilePath path)
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */

   public IOpenFileResult<string> Read(AbsoluteFilePath path)
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */

   public IResult<Message> SetCurrentDirectory(AbsoluteDirectoryPath path)
   {
      try
      {
         Directory.SetCurrentDirectory(path.Value());

         return Result<Message>.Success();
      }
      catch (Exception e)
      {
         return Result.Failure(Message.Create(e.ToString()));
      }
   }

   /* ------------------------------------------------------------ */

   public IResult<ISequence<AbsoluteFilePath>, Message> SubDirectoriesOf(AbsoluteDirectoryPath path)
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */

   public IResult<ISequence<AbsoluteFilePath>, Message> SubFileOf(AbsoluteDirectoryPath path)
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FileSystem() { }

   /* ------------------------------------------------------------ */
}
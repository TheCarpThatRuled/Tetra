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

   public IError Create(AbsoluteDirectoryPath path);

   /* ------------------------------------------------------------ */

   public bool Exists(AbsoluteDirectoryPath path);

   /* ------------------------------------------------------------ */

   public IOpenFileResult<Stream> Open(AbsoluteFilePath path);

   /* ------------------------------------------------------------ */

   public IOpenFileResult<string> Read(AbsoluteFilePath path);

   /* ------------------------------------------------------------ */

   public IError SetCurrentDirectory(AbsoluteDirectoryPath path);

   /* ------------------------------------------------------------ */
}
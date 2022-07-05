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

   public Error Create(AbsoluteDirectoryPath path);

   /* ------------------------------------------------------------ */

   public bool Exists(AbsoluteDirectoryPath path);

   /* ------------------------------------------------------------ */

   public Error SetCurrentDirectory(AbsoluteDirectoryPath path);

   /* ------------------------------------------------------------ */
}
using Tetra;
using Tetra.Testing;

namespace Check;

partial class Actions
{
   private interface IActions
   {
      /* ------------------------------------------------------------ */
      // IActions Properties
      /* ------------------------------------------------------------ */

      public FileSystemActions<Actions> TestFileSystem { get; }

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Asserts Asserts();

      /* ------------------------------------------------------------ */

      public void Create
      (
         AbsoluteDirectoryPath path
      );

      /* ------------------------------------------------------------ */

      public void CreateFileSystem
      (
         AbsoluteDirectoryPath currentDirectory
      );

      /* ------------------------------------------------------------ */

      public void Exists
      (
         AbsoluteDirectoryPath path
      );

      /* ------------------------------------------------------------ */

      void SetCurrentDirectory
      (
         AbsoluteDirectoryPath path
      );

      /* ------------------------------------------------------------ */
   }
}
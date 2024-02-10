using Tetra;
using Tetra.Testing;

namespace Check;

partial class Actions
{
   private interface IActions
   {
      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      public FileSystemApiActions<Actions> Api { get; }

      /* ------------------------------------------------------------ */

      public FileSystemActions<Actions> ConfigurationApi { get; }

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Asserts Asserts();

      /* ------------------------------------------------------------ */

      public void CreateFileSystem
      (
         AbsoluteDirectoryPath currentDirectory
      );

      /* ------------------------------------------------------------ */
   }
}
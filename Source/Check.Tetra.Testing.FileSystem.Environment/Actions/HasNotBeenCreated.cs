using Tetra;
using Tetra.Testing;

namespace Check;

partial class Actions
{
   private sealed class HasNotBeenCreated : IActions
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Func<IActions, IActions> _updateState;
      private readonly Actions                  _parent;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private HasNotBeenCreated
      (
         Func<IActions, IActions> updateState,
         Actions                  parent
      )
      {
         _updateState = updateState;
         _parent      = parent;
      }

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static HasNotBeenCreated Create
      (
         Func<IActions, IActions> updateState,
         Actions                  parent
      )
         => new(updateState,
                parent);

      /* ------------------------------------------------------------ */
      // IActions Properties
      /* ------------------------------------------------------------ */

      public FileSystemActions<Actions> TestFileSystem
         => throw Failed.InTestSetup("Cannot perform the file system; it has not been created.");

      /* ------------------------------------------------------------ */
      // IActions Methods
      /* ------------------------------------------------------------ */

      public Asserts Asserts()
         => throw Failed.InTestSetup("Cannot progress to the asserts; no actions have been performed.");

      public void Create
      (
         AbsoluteDirectoryPath path
      )
      {
         throw new NotImplementedException();
      }

      /* ------------------------------------------------------------ */

      public void CreateFileSystem
      (
         AbsoluteDirectoryPath currentDirectory
      )
         => _updateState(HasBeenCreated.Create(FileSystem.From(currentDirectory),
                                               _parent));

      /* ------------------------------------------------------------ */

      public void Exists
      (
         AbsoluteDirectoryPath path
      )
         => throw Failed.InTestSetup("Cannot test if a directory exists; the file system has not been created.");

      /* ------------------------------------------------------------ */

      public void SetCurrentDirectory
      (
         AbsoluteDirectoryPath path
      )
         => throw Failed.InTestSetup("Cannot set the current directory; the file system has not been created.");

      /* ------------------------------------------------------------ */
   }
}
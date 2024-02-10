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

      public FileSystemApiActions<Actions> Api
         => throw Failed.InTestSetup("Cannot perform any actions on the file system API; it has not been created.");

      /* ------------------------------------------------------------ */

      public FileSystemActions<Actions> ConfigurationApi
         => throw Failed.InTestSetup("Cannot perform any actions on the file system configuration API; it has not been created.");

      /* ------------------------------------------------------------ */
      // IActions Methods
      /* ------------------------------------------------------------ */

      public Asserts Asserts()
         => throw Failed.InTestSetup("Cannot progress to the asserts; no actions have been performed.");

      /* ------------------------------------------------------------ */

      public void CreateFileSystem
      (
         AbsoluteDirectoryPath currentDirectory
      )
         => _updateState(HasBeenCreated.Create(FileSystem.From(currentDirectory),
                                               _parent));

      /* ------------------------------------------------------------ */
   }
}
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
         => throw Failed
                 .CannotPerformAnActionOnBecauseADependencyHasNotBeenCreated("the file system API",
                                                                             "it")
                 .ToAssertFailedException();

      /* ------------------------------------------------------------ */

      public FileSystemActions<Actions> ConfigurationApi
         => throw Failed
                 .CannotPerformAnActionOnBecauseADependencyHasNotBeenCreated("the file system configuration API",
                                                                             "it")
                 .ToAssertFailedException();

      /* ------------------------------------------------------------ */
      // IActions Methods
      /* ------------------------------------------------------------ */

      public Asserts Asserts()
         => throw Failed
                 .CannotProgressToTheAssertsBecauseNoActionsHaveBeenPerformed()
                 .ToAssertFailedException();

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
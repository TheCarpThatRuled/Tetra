namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test<TActions, TAsserts>
{
   public sealed class SilentInitialAction : IInitialAction
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IInitialAction _action;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private SilentInitialAction
      (
         IInitialAction action
      )
         => _action = action;

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static SilentInitialAction Create
      (
         IInitialAction action
      )
         => new(action);

      /* ------------------------------------------------------------ */
      // IInitialAction Methods
      /* ------------------------------------------------------------ */

      public TActions Run
      (
         AAA_test1.Disposables disposables
      )
         => _action.Run(disposables);

      /* ------------------------------------------------------------ */
      // ICharacterised Methods
      /* ------------------------------------------------------------ */

      public string Characterisation()
         => string.Empty;

      /* ------------------------------------------------------------ */
   }
}
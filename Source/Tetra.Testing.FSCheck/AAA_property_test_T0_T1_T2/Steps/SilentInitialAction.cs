namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TParameters, TActions, TAsserts>
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
         TParameters                                parameters,
         AAA_property_test<TParameters>.Disposables disposables
      )
         => _action.Run(parameters,
                        disposables);

      /* ------------------------------------------------------------ */
      // ICharacterised Methods
      /* ------------------------------------------------------------ */

      public string Characterisation()
         => string.Empty;

      /* ------------------------------------------------------------ */
   }
}
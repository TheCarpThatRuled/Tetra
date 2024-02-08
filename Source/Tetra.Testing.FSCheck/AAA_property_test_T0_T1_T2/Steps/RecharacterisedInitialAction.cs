namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TParameters, TActions, TAsserts>
{
   public sealed class RecharacterisedInitialAction : IInitialAction
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IInitialAction _action;
      private readonly string         _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private RecharacterisedInitialAction
      (
         IInitialAction action,
         string         characterisation
      )
      {
         _action           = action;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static RecharacterisedInitialAction Create
      (
         string         characterisation,
         IInitialAction action
      )
         => new(action,
                characterisation);

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
         => _characterisation;

      /* ------------------------------------------------------------ */
   }
}
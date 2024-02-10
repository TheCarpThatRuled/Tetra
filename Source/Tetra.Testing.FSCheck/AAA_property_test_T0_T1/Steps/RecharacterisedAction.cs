namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TActions, TAsserts>
{
   public sealed class RecharacterisedAction : IAction
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IAction _action;
      private readonly string  _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private RecharacterisedAction
      (
         IAction action,
         string  characterisation
      )
      {
         _action           = action;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static RecharacterisedAction Create
      (
         string  characterisation,
         IAction action
      )
         => new(action,
                characterisation);

      /* ------------------------------------------------------------ */
      // IAction Methods
      /* ------------------------------------------------------------ */

      public TActions Run
      (
         AAA_property_test.Parameters parameters,
         TActions                     environment
      )
         => _action.Run(parameters,
                        environment);

      /* ------------------------------------------------------------ */
      // ICharacterised Methods
      /* ------------------------------------------------------------ */

      public string Characterisation()
         => _characterisation;

      /* ------------------------------------------------------------ */
   }
}
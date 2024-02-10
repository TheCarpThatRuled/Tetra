namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TActions, TAsserts>
{
   public sealed class SilentAction : IAction
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IAction _action;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private SilentAction
      (
         IAction action
      )
         => _action = action;

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static SilentAction Create
      (
         IAction action
      )
         => new(action);

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
         => string.Empty;

      /* ------------------------------------------------------------ */
   }
}
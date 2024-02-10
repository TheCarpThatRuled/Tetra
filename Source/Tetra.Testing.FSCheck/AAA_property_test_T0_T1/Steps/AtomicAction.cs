using static Tetra.Testing.AAA_property_test;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TActions, TAsserts>
{
   public sealed class AtomicAction : IAction
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Func<Parameters, TActions, TActions> _action;
      private readonly string                               _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private AtomicAction
      (
         Func<Parameters, TActions, TActions> action,
         string                               characterisation
      )
      {
         _action           = action;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static AtomicAction Create
      (
         string                               characterisation,
         Func<Parameters, TActions, TActions> action
      )
         => new(action,
                characterisation);

      /* ------------------------------------------------------------ */
      // IAction Methods
      /* ------------------------------------------------------------ */

      public TActions Run
      (
         Parameters parameters,
         TActions   environment
      )
      {
         Log.TestStep(parameters.SubstituteParametersForValues(_characterisation));
         return _action(parameters,
                        environment);
      }

      /* ------------------------------------------------------------ */
      // ICharacterised Methods
      /* ------------------------------------------------------------ */

      public string Characterisation()
         => _characterisation;

      /* ------------------------------------------------------------ */
   }
}
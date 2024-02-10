using static Tetra.Testing.AAA_property_test;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TActions, TAsserts>
{
   public sealed class AtomicInitialAction : IInitialAction
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Func<Parameters, Disposables, TActions> _action;
      private readonly string                                  _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private AtomicInitialAction
      (
         Func<Parameters, Disposables, TActions> action,
         string                                  characterisation
      )
      {
         _action           = action;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
      // IInitialAction Methods
      /* ------------------------------------------------------------ */

      public TActions Run
      (
         Parameters  parameters,
         Disposables disposables
      )
      {
         Log.TestStep(parameters.SubstituteParametersForValues(_characterisation));
         return _action(parameters,
                        disposables);
      }

      /* ------------------------------------------------------------ */
      // ICharacterised Methods
      /* ------------------------------------------------------------ */

      public string Characterisation()
         => _characterisation;

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static AtomicInitialAction Create
      (
         string                                  characterisation,
         Func<Parameters, Disposables, TActions> action
      )
         => new(action,
                characterisation);

      /* ------------------------------------------------------------ */
   }
}
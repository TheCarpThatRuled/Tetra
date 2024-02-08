namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TParameters, TActions, TAsserts>
{
   public sealed class AtomicInitialAction : IInitialAction
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Func<TParameters, AAA_property_test<TParameters>.Disposables, TActions> _action;
      private readonly string                                                                  _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private AtomicInitialAction
      (
         Func<TParameters, AAA_property_test<TParameters>.Disposables, TActions> action,
         string                                                                  characterisation
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
         TParameters                                parameters,
         AAA_property_test<TParameters>.Disposables disposables
      )
      {
         Log.TestStep(_characterisation);
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
         string                                                                  characterisation,
         Func<TParameters, AAA_property_test<TParameters>.Disposables, TActions> action
      )
         => new(action,
                characterisation);

      /* ------------------------------------------------------------ */
   }
}
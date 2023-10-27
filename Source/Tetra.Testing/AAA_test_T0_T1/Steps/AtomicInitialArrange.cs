namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test<TActions, TAsserts>
{
   public sealed class AtomicInitialArrange : IInitialArrange
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Func<AAA_test1.Disposables, TActions> _action;
      private readonly string                                _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private AtomicInitialArrange
      (
         Func<AAA_test1.Disposables, TActions> action,
         string                                characterisation
      )
      {
         _action           = action;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
      // IInitialArrange Methods
      /* ------------------------------------------------------------ */

      public TActions Arrange
      (
         AAA_test1.Disposables disposables
      )
      {
         Log.TestStep(_characterisation);
         return _action(disposables);
      }

      /* ------------------------------------------------------------ */
      // ICharacterised Methods
      /* ------------------------------------------------------------ */

      public string Characterisation()
         => _characterisation;

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static AtomicInitialArrange Create
      (
         string                                characterisation,
         Func<AAA_test1.Disposables, TActions> action
      )
         => new(action,
                characterisation);

      /* ------------------------------------------------------------ */
   }
}
namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test<TActions, TAsserts>
{
   public sealed class AtomicInitialAction : IInitialAction
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Func<AAA_test1.Disposables, TActions> _action;
      private readonly string                                _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private AtomicInitialAction
      (
         Func<AAA_test1.Disposables, TActions> action,
         string                                characterisation
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

      public static AtomicInitialAction Create
      (
         string                                characterisation,
         Func<AAA_test1.Disposables, TActions> action
      )
         => new(action,
                characterisation);

      /* ------------------------------------------------------------ */
   }
}
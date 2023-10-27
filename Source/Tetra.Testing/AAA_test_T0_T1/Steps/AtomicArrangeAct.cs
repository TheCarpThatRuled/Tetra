namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test<TActions, TAsserts>
{
   public sealed class AtomicArrangeAct : IArrangeAct
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Func<TActions, TActions> _action;
      private readonly string                   _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private AtomicArrangeAct
      (
         Func<TActions, TActions> action,
         string                   characterisation
      )
      {
         _action           = action;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static AtomicArrangeAct Create
      (
         string                   characterisation,
         Func<TActions, TActions> action
      )
         => new(action,
                characterisation);

      /* ------------------------------------------------------------ */
      // IAct Methods
      /* ------------------------------------------------------------ */

      public TActions Act
      (
         TActions environment
      )
      {
         Log.TestStep(_characterisation);
         return _action(environment);
      }

      /* ------------------------------------------------------------ */
      // IArrange Methods
      /* ------------------------------------------------------------ */

      public TActions Arrange
      (
         TActions environment
      )
         => _action(environment);

      /* ------------------------------------------------------------ */
      // ICharacterised Methods
      /* ------------------------------------------------------------ */

      public string Characterisation()
         => _characterisation;

      /* ------------------------------------------------------------ */
   }
}
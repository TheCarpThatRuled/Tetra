namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TParameters, TActions, TAsserts>
{
   public sealed class AtomicAssert : IAssert
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Func<TAsserts, TAsserts> _assert;
      private readonly string                   _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private AtomicAssert
      (
         Func<TAsserts, TAsserts> assert,
         string                   characterisation
      )
      {
         _assert           = assert;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static AtomicAssert Create
      (
         string                   characterisation,
         Func<TAsserts, TAsserts> assert
      )
         => new(assert,
                characterisation);

      /* ------------------------------------------------------------ */
      // IAssert Methods
      /* ------------------------------------------------------------ */

      public TAsserts Run
      (
         TAsserts environment
      )
      {
         Log.TestStep(_characterisation);
         return _assert(environment);
      }

      /* ------------------------------------------------------------ */
      // ICharacterised Methods
      /* ------------------------------------------------------------ */

      public string Characterisation()
         => _characterisation;

      /* ------------------------------------------------------------ */
   }
}
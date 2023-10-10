namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test
{
   public sealed class AtomicAssert<TInitialAsserts, TNextAsserts> : IAssert<TInitialAsserts, TNextAsserts>
      where TInitialAsserts : IAsserts
      where TNextAsserts : IAsserts
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Func<TInitialAsserts, TNextAsserts> _assert;
      private readonly string                              _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private AtomicAssert
      (
         Func<TInitialAsserts, TNextAsserts> assert,
         string                              characterisation
      )
      {
         _assert           = assert;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
      // IAssert<TInitialAsserts, TNextAsserts> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation
      (
         ThenCharacteriser characteriser
      )
         => characteriser
           .AddClauseToBriefCharacterisation(_characterisation);

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation
      (
         ThenCharacteriser characteriser
      )
         => characteriser
           .AddClauseToFullCharacterisation(_characterisation);

      /* ------------------------------------------------------------ */

      public TNextAsserts Assert
      (
         TInitialAsserts environment
      )
         => _assert(environment);
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static AtomicAssert<TInitialAsserts, TNextAsserts> Create
      (
         string                              characterisation,
         Func<TInitialAsserts, TNextAsserts> assert
      )
         => new(assert,
                characterisation);

      /* ------------------------------------------------------------ */
   }
}
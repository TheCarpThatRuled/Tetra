namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TState>
{
   public sealed class AtomicAssert<TInitialAsserts, TNextAsserts> : IAssert<TInitialAsserts, TNextAsserts>
      where TInitialAsserts : IAsserts
      where TNextAsserts : IAsserts
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Func<TState, TInitialAsserts, TNextAsserts> _assert;
      private readonly string                                      _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private AtomicAssert
      (
         Func<TState, TInitialAsserts, TNextAsserts> assert,
         string                                      characterisation
      )
      {
         _assert           = assert;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
      // IAssert<TState, TInitialAsserts, TNextAsserts> Methods
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
         TState          state,
         TInitialAsserts environment
      )
         => _assert(state,
                    environment);
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static AtomicAssert<TInitialAsserts, TNextAsserts> Create
      (
         Func<TState, TInitialAsserts, TNextAsserts> arrange,
         string                                      characterisation
      )
         => new(arrange,
                characterisation);

      /* ------------------------------------------------------------ */
   }
}
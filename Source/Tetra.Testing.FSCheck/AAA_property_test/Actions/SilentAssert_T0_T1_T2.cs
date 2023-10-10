namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TState>
{
   public sealed class SilentAssert<TInitialAsserts, TNextAsserts> : IAssert<TInitialAsserts, TNextAsserts>
      where TInitialAsserts : IAsserts
      where TNextAsserts : IAsserts
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IAssert<TInitialAsserts, TNextAsserts> _assert;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private SilentAssert
      (
         IAssert<TInitialAsserts, TNextAsserts> assert
      )
         => _assert = assert;

      /* ------------------------------------------------------------ */
      // IAssert<TState, TInitialAsserts, TNextAsserts> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation
      (
         ThenCharacteriser characteriser
      ) { }

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation
      (
         ThenCharacteriser characteriser
      ) { }

      /* ------------------------------------------------------------ */

      public TNextAsserts Assert
      (
         TState          state,
         TInitialAsserts environment
      )
         => _assert
           .Assert(state,
                   environment);
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static SilentAssert<TInitialAsserts, TNextAsserts> Create
      (
         IAssert<TInitialAsserts, TNextAsserts> assert
      )
         => new(assert);

      /* ------------------------------------------------------------ */

      public static SilentAssert<TInitialAsserts, TNextAsserts> Create
      (
         Func<TState, TInitialAsserts, TNextAsserts> assert
      )
         => new(AtomicAssert<TInitialAsserts, TNextAsserts>.Create(assert,
                                                                   ""));

      /* ------------------------------------------------------------ */
   }
}
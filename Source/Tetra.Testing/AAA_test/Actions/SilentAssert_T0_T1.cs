namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test
{
   public sealed class SilentAssert<TInitialAsserts, TNextAsserts> : IAssert<TInitialAsserts, TNextAsserts>
      where TInitialAsserts : IAsserts
      where TNextAsserts : IAsserts
   {
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static SilentAssert<TInitialAsserts, TNextAsserts> Create(IAssert<TInitialAsserts, TNextAsserts> assert)
         => new(assert);

      /* ------------------------------------------------------------ */

      public static SilentAssert<TInitialAsserts, TNextAsserts> Create(Func<TInitialAsserts, TNextAsserts> assert)
         => new(AtomicAssert<TInitialAsserts, TNextAsserts>.Create(assert,
                                                                   ""));

      /* ------------------------------------------------------------ */
      // IAssert<TInitialAsserts, TNextAsserts> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation(AAA_test.ThenCharacteriser characteriser) { }

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation(AAA_test.ThenCharacteriser characteriser) { }

      /* ------------------------------------------------------------ */

      public TNextAsserts Assert(TInitialAsserts environment)
         => _assert
           .Assert(environment);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IAssert<TInitialAsserts, TNextAsserts> _assert;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private SilentAssert(IAssert<TInitialAsserts, TNextAsserts> assert)
         => _assert = assert;

      /* ------------------------------------------------------------ */
   }
}
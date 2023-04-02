namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TState>
{
   public interface IAssert<in TInitialAsserts, out TNextAsserts>
      where TInitialAsserts : IAsserts
      where TNextAsserts : IAsserts
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation(ThenCharacteriser characteriser);

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation(ThenCharacteriser characteriser);

      /* ------------------------------------------------------------ */

      public TNextAsserts Assert(TState          state,
                                 TInitialAsserts environment);

      /* ------------------------------------------------------------ */
   }
}
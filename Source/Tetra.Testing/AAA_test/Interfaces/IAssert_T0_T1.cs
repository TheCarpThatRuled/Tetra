namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test
{
   public interface IAssert<in TInitialAsserts, out TNextAsserts>
      where TInitialAsserts : IAsserts
      where TNextAsserts : IAsserts
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation(AAA_test.ThenCharacteriser characteriser);

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation(AAA_test.ThenCharacteriser characteriser);

      /* ------------------------------------------------------------ */

      public TNextAsserts Assert(TInitialAsserts environment);

      /* ------------------------------------------------------------ */
   }
}
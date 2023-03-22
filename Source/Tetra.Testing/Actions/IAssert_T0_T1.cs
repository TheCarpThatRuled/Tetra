namespace Tetra.Testing;

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
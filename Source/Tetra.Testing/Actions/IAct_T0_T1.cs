namespace Tetra.Testing;

public interface IAct<in TArranges, out TAsserts>
   where TArranges : IArranges
   where TAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public void AddBriefCharacterisation(AAA_test.WhenCharacteriser characteriser);

   /* ------------------------------------------------------------ */

   public void AddFullCharacterisation(AAA_test.WhenCharacteriser characteriser);

   /* ------------------------------------------------------------ */

   public TAsserts Act(TArranges environment);

   /* ------------------------------------------------------------ */
}
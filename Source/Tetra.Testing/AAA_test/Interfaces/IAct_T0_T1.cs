namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test
{
   public interface IAct<in TArranges, out TAsserts>
      where TArranges : IArranges
      where TAsserts : IAsserts
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation(WhenCharacteriser characteriser);

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation(WhenCharacteriser characteriser);

      /* ------------------------------------------------------------ */

      public TAsserts Act(TArranges environment);

      /* ------------------------------------------------------------ */
   }
}
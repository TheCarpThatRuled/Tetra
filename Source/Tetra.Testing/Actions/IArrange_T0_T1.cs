namespace Tetra.Testing;

public interface IArrange<in TInitialArranges, out TNextArranges>
   where TInitialArranges : IArranges
   where TNextArranges : IArranges
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public void AddBriefCharacterisation(AAA_test.GivenCharacteriser characteriser);

   /* ------------------------------------------------------------ */

   public void AddFullCharacterisation(AAA_test.GivenCharacteriser characteriser);

   /* ------------------------------------------------------------ */

   public TNextArranges Arrange(TInitialArranges environment);

   /* ------------------------------------------------------------ */
}
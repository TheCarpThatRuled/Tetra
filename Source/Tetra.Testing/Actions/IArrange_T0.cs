namespace Tetra.Testing;

public interface IArrange<out TArranges>
   where TArranges : IArranges
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public void AddBriefCharacterisation(AAA_test.GivenCharacteriser characteriser);

   /* ------------------------------------------------------------ */

   public void AddFullCharacterisation(AAA_test.GivenCharacteriser characteriser);

   /* ------------------------------------------------------------ */

   public TArranges Arrange(AAA_test.Disposables disposables);

   /* ------------------------------------------------------------ */
}
namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test
{
   public interface IArrange<out TArranges>
      where TArranges : IArranges
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation
      (
         GivenCharacteriser characteriser
      );

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation
      (
         GivenCharacteriser characteriser
      );

      /* ------------------------------------------------------------ */

      public TArranges Arrange
      (
         Disposables disposables
      );

      /* ------------------------------------------------------------ */
   }
}
namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test
{
   public interface IArrange<in TInitialArranges, out TNextArranges>
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
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

      public TNextArranges Arrange
      (
         TInitialArranges environment
      );

      /* ------------------------------------------------------------ */
   }
}
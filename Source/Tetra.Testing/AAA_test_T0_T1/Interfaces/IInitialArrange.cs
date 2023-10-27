namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test<TActions, TAsserts>
{
   public interface IInitialArrange : ICharacterised
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public TActions Arrange
      (
         AAA_test1.Disposables disposables
      );

      /* ------------------------------------------------------------ */
   }
}
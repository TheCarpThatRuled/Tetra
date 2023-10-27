namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test<TActions, TAsserts>
{
   public interface IAssert : ICharacterised
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public TAsserts Assert
      (
         TAsserts environment
      );

      /* ------------------------------------------------------------ */
   }
}
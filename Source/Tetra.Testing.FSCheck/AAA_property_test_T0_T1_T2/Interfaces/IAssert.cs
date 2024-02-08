namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TParameters, TActions, TAsserts>
{
   public interface IAssert : ICharacterised
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public TAsserts Run
      (
         TAsserts environment
      );

      /* ------------------------------------------------------------ */
   }
}
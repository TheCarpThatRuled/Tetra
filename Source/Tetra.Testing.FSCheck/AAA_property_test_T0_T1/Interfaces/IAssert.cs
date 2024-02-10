namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TActions, TAsserts>
{
   public interface IAssert : ICharacterised
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public TAsserts Run
      (
         AAA_property_test.Parameters parameters,
         TAsserts                     environment
      );

      /* ------------------------------------------------------------ */
   }
}
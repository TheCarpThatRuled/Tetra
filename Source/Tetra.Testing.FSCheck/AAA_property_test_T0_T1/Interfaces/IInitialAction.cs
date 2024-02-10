namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TActions, TAsserts>
{
   public interface IInitialAction : ICharacterised
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public TActions Run
      (
         AAA_property_test.Parameters  parameters,
         AAA_property_test.Disposables disposables
      );

      /* ------------------------------------------------------------ */
   }
}
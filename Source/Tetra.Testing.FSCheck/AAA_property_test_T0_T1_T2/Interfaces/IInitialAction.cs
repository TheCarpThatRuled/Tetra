namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TParameters, TActions, TAsserts>
{
   public interface IInitialAction : ICharacterised
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public TActions Run
      (
         TParameters                                parameters,
         AAA_property_test<TParameters>.Disposables disposables
      );

      /* ------------------------------------------------------------ */
   }
}
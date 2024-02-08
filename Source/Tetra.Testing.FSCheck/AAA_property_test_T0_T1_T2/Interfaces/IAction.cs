namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TParameters, TActions, TAsserts>
{
   public interface IAction : ICharacterised
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public TActions Run
      (
         TActions environment
      );

      /* ------------------------------------------------------------ */
   }
}
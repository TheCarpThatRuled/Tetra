namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TActions, TAsserts>
{
   public interface IAction : ICharacterised
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public TActions Run
      (
         AAA_property_test.Parameters parameters,
         TActions                     environment
      );

      /* ------------------------------------------------------------ */
   }
}
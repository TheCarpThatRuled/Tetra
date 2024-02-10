// ReSharper disable InconsistentNaming

namespace Tetra.Testing;

partial class AAA_property_test
{
   public sealed class DefineInitialGiven
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Arbitrary<Parameters> _library;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private DefineInitialGiven
      (
         Arbitrary<Parameters> library
      )
         => _library = library;

      /* ------------------------------------------------------------ */
      // Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static DefineInitialGiven Create
      (
         Arbitrary<Parameters> library
      )
         => new(library);

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public AAA_property_test<TActions, TAsserts>.DefineGiven GIVEN<TActions, TAsserts>
      (
         AAA_property_test<TActions, TAsserts>.IInitialAction given
      )
         where TActions : TestEnvironment<TActions, TAsserts>
         where TAsserts : IPropertyAsserts
         => AAA_property_test<TActions, TAsserts>
           .DefineGiven
           .Create(_library,
                   given);

      /* ------------------------------------------------------------ */
   }
}
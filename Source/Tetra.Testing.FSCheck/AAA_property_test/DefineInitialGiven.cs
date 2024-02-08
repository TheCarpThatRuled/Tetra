// ReSharper disable InconsistentNaming

namespace Tetra.Testing;

partial class AAA_property_test<TParameters>
{
   public sealed class DefineInitialGiven
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Type _library;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private DefineInitialGiven
      (
         Type library
      )
         => _library = library;

      /* ------------------------------------------------------------ */
      // Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static DefineInitialGiven Create
      (
         Type library
      )
         => new(library);

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public AAA_property_test<TParameters, TActions, TAsserts>.DefineGiven GIVEN<TActions, TAsserts>
      (
         AAA_property_test<TParameters, TActions, TAsserts>.IInitialAction given
      )
         where TActions : TestEnvironment<TActions, TAsserts>
         where TAsserts : IPropertyAsserts
         => AAA_property_test<TParameters, TActions, TAsserts>
           .DefineGiven
           .Create(_library,
                   given);

      /* ------------------------------------------------------------ */
   }
}
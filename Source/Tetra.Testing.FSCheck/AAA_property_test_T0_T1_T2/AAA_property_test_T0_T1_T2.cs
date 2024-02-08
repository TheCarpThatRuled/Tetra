namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public partial class AAA_property_test<TParameters, TActions, TAsserts>
   where TActions : TestEnvironment<TActions, TAsserts>
   where TAsserts : IPropertyAsserts
{
   /* ------------------------------------------------------------ */
   // Private Functions
   /* ------------------------------------------------------------ */

   private static string And
   (
      string first,
      string second
   )
      => string.IsNullOrEmpty(first)
            ? second
            : string.IsNullOrEmpty(second)
               ? first
               : $"{first} AND {second}";

   /* ------------------------------------------------------------ */
}
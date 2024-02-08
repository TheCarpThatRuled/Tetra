namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public partial class AAA_test<TActions, TAsserts>
   where TActions : TestEnvironment<TActions, TAsserts>
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
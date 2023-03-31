using FsCheck;

namespace Check;

internal static partial class LocalLibraries
{
   /* ------------------------------------------------------------ */

   public sealed class ArrayOfAtLeastTwoStrings
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<string[]> Type()
         => Generators
           .NonEmptyArrayOf(Generators.String())
           .Where(x=> x.Length > 1)
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   public sealed class ListOfAtLeastTwoStrings
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<List<string>> Type()
         => Generators
           .NonEmptyListOf(Generators.String())
           .Where(x => x.Count > 1)
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}
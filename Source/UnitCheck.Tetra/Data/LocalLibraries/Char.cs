using FsCheck;
using Tetra.Testing;

namespace Check;

internal static partial class LocalLibraries
{
   /* ------------------------------------------------------------ */

   public sealed class AsciiLetterEqualToAsciiLetterCaseInsensitive
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(char first, char second)> Type()
         => Generators
           .AsciiLetter()
           .TwoValueTuples()
           .Where(tuple => StringComparer
                          .OrdinalIgnoreCase
                          .Compare(tuple.first
                                        .ToString(),
                                   tuple.second
                                        .ToString())
                         == 0)
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   public sealed class AsciiLetterGreaterThanAsciiLetterCaseInsensitive
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(char first, char second)> Type()
         => Generators
           .AsciiLetter()
           .TwoValueTuples()
           .Where(tuple => StringComparer
                          .OrdinalIgnoreCase
                          .Compare(tuple.first
                                        .ToString(),
                                   tuple.second
                                        .ToString())
                        > 0)
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   public sealed class AsciiLetterLessThanAsciiLetterCaseInsensitive
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(char first, char second)> Type()
         => Generators
           .AsciiLetter()
           .TwoValueTuples()
           .Where(tuple => StringComparer
                          .OrdinalIgnoreCase
                          .Compare(tuple.first
                                        .ToString(),
                                   tuple.second
                                        .ToString())
                        < 0)
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}
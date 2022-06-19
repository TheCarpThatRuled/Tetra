using FsCheck;
using Tetra;
using Tetra.Testing;

namespace Check;

partial class LocalLibraries
{
   /* ------------------------------------------------------------ */

   public sealed class ValidPathComponentEqualToValidPathComponentCaseInsensitive
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(string first, string second)> Type()
         => Generators
           .ValidPathComponent()
           .Select(path => (path,
                            path.ToLowerInvariant()))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   public sealed class ValidPathComponentGreaterThanValidPathComponentCaseInsensitive
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(string first, string second)> Type()
         => Generators
           .ValidPathComponent()
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

   public sealed class ValidPathComponentLessThanValidPathComponentCaseInsensitive
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(string first, string second)> Type()
         => Generators
           .ValidPathComponent()
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

   public sealed class ValidVolumeRootedPathEqualToValidVolumeRootedPathCaseInsensitive
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(string first, string second)> Type()
         => Generators
           .ValidVolumeRootedPath()
           .Select(path => (path,
                            path.ToLowerInvariant()))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   public sealed class ValidVolumeRootedPathGreaterThanValidVolumeRootedPathCaseInsensitive
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(string first, string second)> Type()
         => Generators
           .ValidVolumeRootedPath()
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

   public sealed class ValidVolumeRootedPathLessThanValidVolumeRootedPathCaseInsensitive
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(string first, string second)> Type()
         => Generators
           .ValidVolumeRootedPath()
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
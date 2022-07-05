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

   public sealed class ValidAbsoluteDirectoryPathEqualToValidAbsoluteDirectoryPathCaseInsensitive
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(string first, string second)> Type()
         => Generators
           .ValidPathWithVolumeRootAndTrailingDirectorySeparator()
           .Select(path => (path,
                            path.ToLowerInvariant()))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   public sealed class ValidAbsoluteDirectoryPathGreaterThanValidAbsoluteDirectoryPathCaseInsensitive
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(string first, string second)> Type()
         => Generators
           .ValidPathWithVolumeRootAndTrailingDirectorySeparator()
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

   public sealed class ValidAbsoluteDirectoryPathLessThanValidAbsoluteDirectoryPathCaseInsensitive
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(string first, string second)> Type()
         => Generators
           .ValidPathWithVolumeRootAndTrailingDirectorySeparator()
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

   public sealed class ValidVolumeRootedFilePathEqualToValidVolumeRootedFilePathCaseInsensitive
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(string first, string second)> Type()
         => Generators
           .ValidPathWithVolumeRootButWithoutTrailingDirectorySeparator()
           .Select(path => (path,
                            path.ToLowerInvariant()))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   public sealed class ValidVolumeRootedFilePathGreaterThanValidVolumeRootedFilePathCaseInsensitive
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(string first, string second)> Type()
         => Generators
           .ValidPathWithVolumeRootButWithoutTrailingDirectorySeparator()
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

   public sealed class ValidVolumeRootedFilePathLessThanValidVolumeRootedFilePathCaseInsensitive
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(string first, string second)> Type()
         => Generators
           .ValidPathWithVolumeRootButWithoutTrailingDirectorySeparator()
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
using FsCheck;

namespace Check;

internal partial class LocalLibraries
{
   /* ------------------------------------------------------------ */

   public sealed class ValidAbsoluteDirectoryPathEqualToValidAbsoluteDirectoryPathCaseInsensitive
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(string first, string second)> Type()
         => Generators
           .ValidPathWithAVolumeRootAndATrailingDirectorySeparator()
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
           .ValidPathWithAVolumeRootAndATrailingDirectorySeparator()
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
           .ValidPathWithAVolumeRootAndATrailingDirectorySeparator()
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

   public sealed class ValidAbsoluteFilePathEqualToValidAbsoluteFilePathCaseInsensitive
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(string first, string second)> Type()
         => Generators
           .ValidPathWithAVolumeRootButWithoutATrailingDirectorySeparator()
           .Select(path => (path,
                            path.ToLowerInvariant()))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   public sealed class ValidAbsoluteFilePathGreaterThanValidAbsoluteFilePathCaseInsensitive
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(string first, string second)> Type()
         => Generators
           .ValidPathWithAVolumeRootButWithoutATrailingDirectorySeparator()
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

   public sealed class ValidAbsoluteFilePathLessThanValidAbsoluteFilePathCaseInsensitive
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(string first, string second)> Type()
         => Generators
           .ValidPathWithAVolumeRootButWithoutATrailingDirectorySeparator()
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

   public sealed class ValidRelativeDirectoryPathEqualToValidRelativeDirectoryPathCaseInsensitive
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(string first, string second)> Type()
         => Generators
           .ValidPathWithoutARootButWithATrailingDirectorySeparator()
           .Select(path => (path,
                            path.ToLowerInvariant()))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   public sealed class ValidRelativeDirectoryPathGreaterThanValidRelativeDirectoryPathCaseInsensitive
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(string first, string second)> Type()
         => Generators
           .ValidPathWithoutARootButWithATrailingDirectorySeparator()
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

   public sealed class ValidRelativeDirectoryPathLessThanValidRelativeDirectoryPathCaseInsensitive
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(string first, string second)> Type()
         => Generators
           .ValidPathWithoutARootButWithATrailingDirectorySeparator()
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

   public sealed class ValidRelativeFilePathEqualToValidRelativeFilePathCaseInsensitive
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(string first, string second)> Type()
         => Generators
           .ValidPathWithoutARootOrATrailingDirectorySeparator()
           .Select(path => (path,
                            path.ToLowerInvariant()))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   public sealed class ValidRelativeFilePathGreaterThanValidRelativeFilePathCaseInsensitive
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(string first, string second)> Type()
         => Generators
           .ValidPathWithoutARootOrATrailingDirectorySeparator()
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

   public sealed class ValidRelativeFilePathLessThanValidRelativeFilePathCaseInsensitive
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(string first, string second)> Type()
         => Generators
           .ValidPathWithoutARootOrATrailingDirectorySeparator()
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
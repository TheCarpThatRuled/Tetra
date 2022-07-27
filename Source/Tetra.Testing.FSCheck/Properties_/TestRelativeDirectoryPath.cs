using FsCheck;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Properties
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static Property AreEqual(TestRelativeDirectoryPath expected,
                                   RelativeDirectoryPath     actual,
                                   string                    description)
      => AreEqual($"{description} - Value() returns an unexpected value",
                  expected.PathWithTrailingDirectorySeparator(),
                  actual.Value());

   /* ------------------------------------------------------------ */

   public static Property AreEqual(TestRelativeDirectoryPath               expected,
                                   IReadOnlyCollection<DirectoryComponent> actual,
                                   string                                  description)
      => AreSequenceEqual(expected.Directories(),
                          actual,
                          $"{description} - directories");

   /* ------------------------------------------------------------ */

   public static Property AreSequenceEqual(IEnumerable<TestRelativeDirectoryPath> expected,
                                           IEnumerable<RelativeDirectoryPath>     actual,
                                           string                                 description)
      => AreSequenceEqual(expected.ToArray(),
                          actual.ToArray(),
                          description);

   /* ------------------------------------------------------------ */

   public static Property AreSequenceEqual(IReadOnlyCollection<TestRelativeDirectoryPath> expected,
                                           IReadOnlyCollection<RelativeDirectoryPath>     actual,
                                           string                                         description)
      => AreSequenceEqual(expected,
                          actual,
                          x => x.PathWithTrailingDirectorySeparator(),
                          x => x.Value(),
                          AreEqual,
                          description);

   /* ------------------------------------------------------------ */
}
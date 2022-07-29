using FsCheck;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Properties
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static Property AreEqual(string                    description,
                                   TestRelativeDirectoryPath expected,
                                   RelativeDirectoryPath     actual)
      => AreEqual($"{description} - Value() returns an unexpected value",
                  expected.PathWithTrailingDirectorySeparator(),
                  actual.Value());

   /* ------------------------------------------------------------ */

   public static Property AreEqual(string                                  description,
                                   TestRelativeDirectoryPath               expected,
                                   IReadOnlyCollection<DirectoryComponent> actual)
      => AreSequenceEqual($"{description} - directories",
                          expected.Directories(),
                          actual);

   /* ------------------------------------------------------------ */

   public static Property AreSequenceEqual(string                                 description,
                                           IEnumerable<TestRelativeDirectoryPath> expected,
                                           IEnumerable<RelativeDirectoryPath>     actual)
      => AreSequenceEqual(description,
                          expected.ToArray(),
                          actual.ToArray());

   /* ------------------------------------------------------------ */

   public static Property AreSequenceEqual(string                                         description,
                                           IReadOnlyCollection<TestRelativeDirectoryPath> expected,
                                           IReadOnlyCollection<RelativeDirectoryPath>     actual)
      => AreSequenceEqual(description,
                          expected,
                          actual,
                          x => x.PathWithTrailingDirectorySeparator(),
                          x => x.Value(),
                          (expected1,
                           actual1,
                           description1) => AreEqual(description1,
                                                     expected1,
                                                     actual1));

   /* ------------------------------------------------------------ */
}
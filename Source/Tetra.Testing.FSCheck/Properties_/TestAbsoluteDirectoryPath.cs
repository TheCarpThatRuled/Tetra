using FsCheck;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Properties
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static Property AreEqual(string                    description,
                                   TestAbsoluteDirectoryPath expected,
                                   AbsoluteDirectoryPath     actual)
      => AreEqual($"{description} - Value() returns an unexpected value",
                  expected.PathWithTrailingDirectorySeparator(),
                  actual.Value())
        .And(AreEqual($"{description} - Volume() returns an unexpected value",
                      expected.Volume(),
                      actual.Volume()));

   /* ------------------------------------------------------------ */

   public static Property AreEqual(string                                                                        description,
                                   TestAbsoluteDirectoryPath                                                     expected,
                                   (VolumeComponent volume, IReadOnlyCollection<DirectoryComponent> directories) actual)
      => AreEqual($"{description} - the volumes do not match",
                  expected.Volume(),
                  actual.volume)
        .And(AreSequenceEqual($"{description} - directories",
                              expected.Directories(),
                              actual.directories));

   /* ------------------------------------------------------------ */

   public static Property AreSequenceEqual(string                                 description,
                                           IEnumerable<TestAbsoluteDirectoryPath> expected,
                                           IEnumerable<AbsoluteDirectoryPath>     actual)
      => AreSequenceEqual(description,
                          expected.ToArray(),
                          actual.ToArray());

   /* ------------------------------------------------------------ */

   public static Property AreSequenceEqual(string                                         description,
                                           IReadOnlyCollection<TestAbsoluteDirectoryPath> expected,
                                           IReadOnlyCollection<AbsoluteDirectoryPath>     actual)
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
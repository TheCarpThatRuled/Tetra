using FsCheck;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Properties
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static Property AreEqual(TestRelativeFilePath expected,
                                   RelativeFilePath     actual,
                                   string               description)
      => AreEqual($"{description} - Value() returns an unexpected value",
                  expected.PathWithoutTrailingDirectorySeparator(),
                  actual.Value())
        .And(AreEqual($"{description} - File() returns an unexpected value",
                      expected.File(),
                      actual.File()));

   /* ------------------------------------------------------------ */

   public static Property AreEqual(TestRelativeFilePath                                                      expected,
                                   (IReadOnlyCollection<DirectoryComponent> directories, FileComponent file) actual,
                                   string                                                                    description)
      => AreSequenceEqual(expected.Directories(),
                          actual.directories,
                          $"{description} - directories")
        .And(AreEqual($"{description} - the files do not match",
                      expected.File(),
                      actual.file));

   /* ------------------------------------------------------------ */

   public static Property AreSequenceEqual(IEnumerable<TestRelativeFilePath> expected,
                                           IEnumerable<RelativeFilePath>     actual,
                                           string                            description)
      => AreSequenceEqual(expected.ToArray(),
                          actual.ToArray(),
                          description);

   /* ------------------------------------------------------------ */

   public static Property AreSequenceEqual(IReadOnlyCollection<TestRelativeFilePath> expected,
                                           IReadOnlyCollection<RelativeFilePath>     actual,
                                           string                                    description)
      => AreSequenceEqual(expected,
                          actual,
                          x => x.PathWithoutTrailingDirectorySeparator(),
                          x => x.Value(),
                          AreEqual,
                          description);

   /* ------------------------------------------------------------ */
}
using FsCheck;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Properties
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static Property AreEqual(TestAbsoluteFilePath expected,
                                   AbsoluteFilePath     actual,
                                   string               description)
      => AreEqual($"{description} - Value() returns an unexpected value",
                  expected.PathWithoutTrailingDirectorySeparator(),
                  actual.Value())
        .And(AreEqual($"{description} - Volume() returns an unexpected value",
                      expected.Volume(),
                      actual.Volume()))
        .And(AreEqual($"{description} - File() returns an unexpected value",
                      expected.File(),
                      actual.File()));

   /* ------------------------------------------------------------ */

   public static Property AreEqual(TestAbsoluteFilePath                                                                              expected,
                                   (VolumeComponent volume, IReadOnlyCollection<DirectoryComponent> directories, FileComponent file) actual,
                                   string                                                                                            description)
      => AreEqual($"{description} - the volumes do not match",
                  expected.Volume(),
                  actual.volume)
        .And(AreSequenceEqual(expected.Directories(),
                              actual.directories,
                              $"{description} - directories"))
        .And(AreEqual($"{description} - the files do not match",
                      expected.File(),
                      actual.file));

   /* ------------------------------------------------------------ */

   public static Property AreSequenceEqual(IEnumerable<TestAbsoluteFilePath> expected,
                                           IEnumerable<AbsoluteFilePath>     actual,
                                           string                            description)
      => AreSequenceEqual(expected.ToArray(),
                          actual.ToArray(),
                          description);

   /* ------------------------------------------------------------ */

   public static Property AreSequenceEqual(IReadOnlyCollection<TestAbsoluteFilePath> expected,
                                           IReadOnlyCollection<AbsoluteFilePath>     actual,
                                           string                                    description)
      => AreSequenceEqual(expected,
                          actual,
                          x => x.PathWithoutTrailingDirectorySeparator(),
                          x => x.Value(),
                          AreEqual,
                          description);

   /* ------------------------------------------------------------ */
}
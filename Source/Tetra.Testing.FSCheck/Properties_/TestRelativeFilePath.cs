using FsCheck;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Properties
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static Property AreEqual
   (
      string               description,
      TestRelativeFilePath expected,
      RelativeFilePath     actual
   )
      => AreEqual($"{description} - Value() returns an unexpected value",
                  expected.PathWithoutTrailingDirectorySeparator(),
                  actual.Value())
        .And(AreEqual($"{description} - File() returns an unexpected value",
                      expected.File(),
                      actual.File()));

   /* ------------------------------------------------------------ */

   public static Property AreEqual
   (
      string                                                          description,
      TestRelativeFilePath                                            expected,
      (ISequence<DirectoryComponent> directories, FileComponent file) actual
   )
      => AreSequenceEqual($"{description} - directories",
                          expected.Directories(),
                          actual.directories)
        .And(AreEqual($"{description} - the files do not match",
                      expected.File(),
                      actual.file));

   /* ------------------------------------------------------------ */

   public static Property AreSequenceEqual
   (
      string                            description,
      IEnumerable<TestRelativeFilePath> expected,
      IEnumerable<RelativeFilePath>     actual
   )
      => AreSequenceEqual(description,
                          expected.Materialise(),
                          actual.Materialise());

   /* ------------------------------------------------------------ */

   public static Property AreSequenceEqual
   (
      string                          description,
      ISequence<TestRelativeFilePath> expected,
      ISequence<RelativeFilePath>     actual
   )
      => AreSequenceEqual(description,
                          expected,
                          actual,
                          x => x.PathWithoutTrailingDirectorySeparator(),
                          x => x.Value(),
                          (
                             expected1,
                             actual1,
                             description1
                          ) => AreEqual(description1,
                                        expected1,
                                        actual1));

   /* ------------------------------------------------------------ */
}
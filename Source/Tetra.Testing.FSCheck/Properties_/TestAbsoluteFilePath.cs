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
      TestAbsoluteFilePath expected,
      AbsoluteFilePath     actual
   )
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

   public static Property AreEqual
   (
      string                                                                                  description,
      TestAbsoluteFilePath                                                                    expected,
      (VolumeComponent volume, ISequence<DirectoryComponent> directories, FileComponent file) actual
   )
      => AreEqual($"{description} - the volumes do not match",
                  expected.Volume(),
                  actual.volume)
        .And(AreSequenceEqual($"{description} - directories",
                              expected.Directories(),
                              actual.directories))
        .And(AreEqual($"{description} - the files do not match",
                      expected.File(),
                      actual.file));

   /* ------------------------------------------------------------ */

   public static Property AreSequenceEqual
   (
      string                            description,
      IEnumerable<TestAbsoluteFilePath> expected,
      IEnumerable<AbsoluteFilePath>     actual
   )
      => AreSequenceEqual(description,
                          expected.Materialise(),
                          actual.Materialise());

   /* ------------------------------------------------------------ */

   public static Property AreSequenceEqual
   (
      string                          description,
      ISequence<TestAbsoluteFilePath> expected,
      ISequence<AbsoluteFilePath>     actual
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
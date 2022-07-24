using FsCheck;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Properties
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static Property AreEqual(TestAbsoluteDirectoryPath expected,
                                   AbsoluteDirectoryPath     actual,
                                   string                    description)
      => AsProperty(() => expected.PathWithTrailingDirectorySeparator() == actual.Value())
        .Label(Failed.Message($"{description} - Value() returns an unexpected value",
                              expected.PathWithTrailingDirectorySeparator(),
                              actual.Value()))
        .And(AsProperty(() => expected
                             .Volume()
                             .Equals(actual.Volume()))
               .Label(Failed.Message($"{description} - Volume() returns an unexpected value",
                                     expected.Volume(),
                                     actual.Volume())));

   /* ------------------------------------------------------------ */

   public static Property AreEqual(TestAbsoluteDirectoryPath                                                     expected,
                                   (VolumeComponent volume, IReadOnlyCollection<DirectoryComponent> directories) actual,
                                   string                                                                        description)
      => AsProperty(() => expected.Volume()
                                  .Equals(actual.volume))
        .Label(Failed.Message($"{description} - the volumes do not match",
                              expected.Volume(),
                              actual.volume))
        .And(AreSequenceEqual(expected.Directories(),
                              actual.directories,
                              $"{description} - directories"));

   /* ------------------------------------------------------------ */

   public static Property AreSequenceEqual(IEnumerable<TestAbsoluteDirectoryPath> expected,
                                           IEnumerable<AbsoluteDirectoryPath>     actual,
                                           string                                 description)
      => AreSequenceEqual(expected.ToArray(),
                          actual.ToArray(),
                          description);

   /* ------------------------------------------------------------ */

   public static Property AreSequenceEqual(IReadOnlyCollection<TestAbsoluteDirectoryPath> expected,
                                           IReadOnlyCollection<AbsoluteDirectoryPath>     actual,
                                           string                                         description)
      => AreSequenceEqual(expected,
                          actual,
                          x => x.PathWithTrailingDirectorySeparator(),
                          x => x.Value(),
                          AreEqual,
                          description);

   /* ------------------------------------------------------------ */
}
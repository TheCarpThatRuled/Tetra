using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<string> InvalidPathComponent()
      => Gen
        .Zip(ValidOrEmptyPathComponent(),
             InvalidPathComponentCharacter(),
             ValidOrEmptyPathComponent())
        .Select(x => x.Item1 + x.Item2 + x.Item3);

   /* ------------------------------------------------------------ */

   public static Gen<char> InvalidPathComponentCharacter()
      => Gen
        .Elements(Path.GetInvalidFileNameChars());

   /* ------------------------------------------------------------ */

   public static Gen<string> ValidOrEmptyPathComponent()
      => NonNullString()
        .Where(path => path.All(character => !Path
                                             .GetInvalidFileNameChars()
                                             .Contains(character)));

   /* ------------------------------------------------------------ */

   public static Gen<string> ValidPathComponent()
      => NonNullOrEmptyString()
        .Select(x => x.Get)
        .Where(path => path.All(character => !Path
                                             .GetInvalidFileNameChars()
                                             .Contains(character)));

   /* ------------------------------------------------------------ */

   public static Gen<char> ValidPathComponentCharacter()
      => Char()
        .Where(character => !Path
                            .GetInvalidFileNameChars()
                            .Contains(character));

   /* ------------------------------------------------------------ */

   public static Gen<string> ValidPathWithoutRoot()
      => Gen
        .OneOf(ValidPathWithoutRootAndTrailingDirectorySeparator(),
               ValidPathWithoutRootButWithTrailingDirectorySeparator());

   /* ------------------------------------------------------------ */

   public static Gen<string> ValidPathWithoutRootAndTrailingDirectorySeparator()
      => NonEmptyListOf(ValidPathComponent())
        .Select(directories => directories.ToDelimitedString(Path.DirectorySeparatorChar.ToString()));

   /* ------------------------------------------------------------ */

   public static Gen<string> ValidPathWithoutRootButWithTrailingDirectorySeparator()
      => NonEmptyListOf(ValidPathComponent())
        .Select(directories => directories.Aggregate(string.Empty,
                                                     (total,
                                                      next) => $"{total}{next}{Path.DirectorySeparatorChar}"));

   /* ------------------------------------------------------------ */

   public static Gen<string> ValidPathWithVolumeRoot()
      => Gen
        .OneOf(ValidPathWithVolumeRootAndTrailingDirectorySeparator(),
               ValidPathWithVolumeRootButWithoutTrailingDirectorySeparator());

   /* ------------------------------------------------------------ */

   public static Gen<string> ValidPathWithVolumeRootAndTrailingDirectorySeparator()
      => AsciiLetter()
        .Combine(ListOf(ValidPathComponent()),
                 (volume,
                  directories) => $"{volume}:{Path.DirectorySeparatorChar}{directories.Aggregate(string.Empty, (total, next) => $"{total}{next}{Path.DirectorySeparatorChar}")}");

   /* ------------------------------------------------------------ */

   public static Gen<string> ValidPathWithVolumeRootButWithoutTrailingDirectorySeparator()
      => AsciiLetter()
        .Combine(ValidPathWithoutRootAndTrailingDirectorySeparator(),
                 (volume,
                  directories) => $"{volume}:{Path.DirectorySeparatorChar}{directories}");

   /* ------------------------------------------------------------ */
}
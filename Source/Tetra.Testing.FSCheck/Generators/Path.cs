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
        .Select(x => $"{x.Item1}{x.Item2}{x.Item3}");

   /* ------------------------------------------------------------ */

   public static Gen<string> InvalidPathComponentExcludingDirectorySeparators()
      => Gen
        .Zip(ValidOrEmptyPathComponent(),
             InvalidPathComponentCharacterExcludingDirectorySeparators(),
             ValidOrEmptyPathComponent())
        .Select(x => $"{x.Item1}{x.Item2}{x.Item3}");

   /* ------------------------------------------------------------ */

   public static Gen<char> InvalidPathComponentCharacter()
      => Gen
        .Elements(Path.GetInvalidFileNameChars());

   /* ------------------------------------------------------------ */

   public static Gen<char> InvalidPathComponentCharacterExcludingDirectorySeparators()
      => Gen
        .Elements(Path
                 .GetInvalidFileNameChars()
                 .Where(x => x != Path.DirectorySeparatorChar
                          && x != Path.AltDirectorySeparatorChar));

   /* ------------------------------------------------------------ */

   public static Gen<string> PathWithInvalidVolumeRoot()
      => Gen
        .OneOf(PathWithInvalidVolumeRootAndTrailingDirectorySeparator(),
               PathWithInvalidVolumeRootButWithoutTrailingDirectorySeparator());

   /* ------------------------------------------------------------ */

   public static Gen<string> PathWithInvalidVolumeRootAndTrailingDirectorySeparator()
      => Gen
        .OneOf(NonAsciiLetter().Select(x => x.ToString()),
               TwoOrMoreAsciiLetters())
        .Combine(ListOf(ValidPathComponent()),
                 (volume,
                  directories) => $"{volume}:{Path.DirectorySeparatorChar}{directories.ToDelimitedStringWithTrailingDelimiter(Path.DirectorySeparatorChar)}");

   /* ------------------------------------------------------------ */

   public static Gen<string> PathWithInvalidVolumeRootButWithoutTrailingDirectorySeparator()
      => Gen
        .OneOf(NonAsciiLetter().Select(x=> x.ToString()),
            TwoOrMoreAsciiLetters())
        .Combine(ValidPathWithoutRootAndTrailingDirectorySeparator(),
                 (volume,
                  directories) => $"{volume}:{Path.DirectorySeparatorChar}{directories}");

   /* ------------------------------------------------------------ */

   public static Gen<string> PathWithAVolumeRootAndAnInvalidComponent()
      => Gen
        .OneOf(PathWithAVolumeRootAndAnInvalidComponentAndTrailingDirectorySeparator(),
               PathWithAVolumeRootAndAnInvalidComponentButWithoutTrailingDirectorySeparator());

   /* ------------------------------------------------------------ */

   public static Gen<string> PathWithAVolumeRootAndAnInvalidComponentAndTrailingDirectorySeparator()
      => AsciiLetter()
        .Combine(ListOf(ValidPathComponent()),
                 InvalidPathComponentExcludingDirectorySeparators(),
                 ListOf(ValidPathComponent()),
                 (volume,
                  prependedComponents,
                  invalidComponent,
                  appendedComponents) =>
                 {
                    var components = prependedComponents
                                    .Append(invalidComponent)
                                    .Concat(appendedComponents)
                                    .ToArray()
                                    .ToDelimitedStringWithTrailingDelimiter(Path.DirectorySeparatorChar);

                    return $"{volume}:{Path.DirectorySeparatorChar}{components}";
                 });

   /* ------------------------------------------------------------ */

   public static Gen<string> PathWithAVolumeRootAndAnInvalidComponentButWithoutTrailingDirectorySeparator()
      => AsciiLetter()
        .Combine(ListOf(ValidPathComponent()),
                 InvalidPathComponentExcludingDirectorySeparators(),
                 ListOf(ValidPathComponent()),
                 (volume,
                  prependedComponents,
                  invalidComponent,
                  appendedComponents) =>
                 {
                    var components = prependedComponents
                                    .Append(invalidComponent)
                                    .Concat(appendedComponents)
                                    .ToArray()
                                    .ToDelimitedString(Path.DirectorySeparatorChar);

                    return $"{volume}:{Path.DirectorySeparatorChar}{components}";
                 });

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
                  directories) => $"{volume}:{Path.DirectorySeparatorChar}{directories.ToDelimitedStringWithTrailingDelimiter(Path.DirectorySeparatorChar)}");

   /* ------------------------------------------------------------ */

   public static Gen<string> ValidPathWithVolumeRootButWithoutTrailingDirectorySeparator()
      => AsciiLetter()
        .Combine(ValidPathWithoutRootAndTrailingDirectorySeparator(),
                 (volume,
                  directories) => $"{volume}:{Path.DirectorySeparatorChar}{directories}");

   /* ------------------------------------------------------------ */
}
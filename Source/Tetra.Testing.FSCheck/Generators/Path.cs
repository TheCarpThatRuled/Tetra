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

   public static Gen<string> PathWithAnInvalidVolumeRoot()
      => Gen
        .OneOf(PathWithAnInvalidVolumeRootAndATrailingDirectorySeparator(),
               PathWithAnInvalidVolumeRootButWithoutATrailingDirectorySeparator());

   /* ------------------------------------------------------------ */

   public static Gen<string> PathWithAnInvalidVolumeRootAndATrailingDirectorySeparator()
      => Gen
        .OneOf(NonAsciiLetter().Select(x => x.ToString()),
               TwoOrMoreAsciiLetters())
        .Combine(ListOf(ValidPathComponent()),
                 (volume,
                  directories) => $"{volume}:{Path.DirectorySeparatorChar}{directories.ToDelimitedStringWithTrailingDelimiter(Path.DirectorySeparatorChar)}");

   /* ------------------------------------------------------------ */

   public static Gen<string> PathWithAnInvalidVolumeRootButWithoutATrailingDirectorySeparator()
      => Gen
        .OneOf(NonAsciiLetter().Select(x=> x.ToString()),
            TwoOrMoreAsciiLetters())
        .Combine(ValidPathWithoutARootOrATrailingDirectorySeparator(),
                 (volume,
                  directories) => $"{volume}:{Path.DirectorySeparatorChar}{directories}");

   /* ------------------------------------------------------------ */

   public static Gen<string> PathWithAVolumeRootAndAnInvalidComponent()
      => Gen
        .OneOf(PathWithAVolumeRootAndAnInvalidComponentAndATrailingDirectorySeparator(),
               PathWithAVolumeRootAndAnInvalidComponentButWithoutATrailingDirectorySeparator());

   /* ------------------------------------------------------------ */

   public static Gen<string> PathWithAVolumeRootAndAnInvalidComponentAndATrailingDirectorySeparator()
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

   public static Gen<string> PathWithAVolumeRootAndAnInvalidComponentButWithoutATrailingDirectorySeparator()
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

   public static Gen<string> PathWithoutARootButWithAnInvalidComponent()
      => Gen
        .OneOf(PathWithoutARootAndATrailingDirectorySeparatorButWithAnInvalidComponent(),
               PathWithoutARootButWithAnInvalidComponentAndATrailingDirectorySeparator());

   /* ------------------------------------------------------------ */

   public static Gen<string> PathWithoutARootAndATrailingDirectorySeparatorButWithAnInvalidComponent()
      => ListOf(ValidPathComponent())
        .Combine(InvalidPathComponentExcludingDirectorySeparators(),
                 ListOf(ValidPathComponent()),
                 (prependedComponents,
                  invalidComponent,
                  appendedComponents) => prependedComponents
                                        .Append(invalidComponent)
                                        .Concat(appendedComponents)
                                        .ToArray()
                                        .ToDelimitedString(Path.DirectorySeparatorChar));

   /* ------------------------------------------------------------ */

   public static Gen<string> PathWithoutARootButWithAnInvalidComponentAndATrailingDirectorySeparator()
      => ListOf(ValidPathComponent())
        .Combine(InvalidPathComponentExcludingDirectorySeparators(),
                 ListOf(ValidPathComponent()),
                 (prependedComponents,
                  invalidComponent,
                  appendedComponents) => prependedComponents
                                        .Append(invalidComponent)
                                        .Concat(appendedComponents)
                                        .ToArray()
                                        .ToDelimitedStringWithTrailingDelimiter(Path.DirectorySeparatorChar));

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
        .Where(path =>
         {
            var all = path.All(character =>
            {
               var invalidFileNameChars = Path
                 .GetInvalidFileNameChars();
               var b = !invalidFileNameChars
                         .Contains(character);
               return b;
            });
            return all;
         });

   /* ------------------------------------------------------------ */

   public static Gen<char> ValidPathComponentCharacter()
      => Char()
        .Where(character => !Path
                            .GetInvalidFileNameChars()
                            .Contains(character));

   /* ------------------------------------------------------------ */

   public static Gen<string> ValidPathWithoutARoot()
      => Gen
        .OneOf(ValidPathWithoutARootOrATrailingDirectorySeparator(),
               ValidPathWithoutARootButWithATrailingDirectorySeparator());

   /* ------------------------------------------------------------ */

   public static Gen<string> ValidPathWithoutARootOrATrailingDirectorySeparator()
      => NonEmptyListOf(ValidPathComponent())
        .Select(directories => 
                   directories.ToDelimitedString(Path.DirectorySeparatorChar.ToString()));

   /* ------------------------------------------------------------ */

   public static Gen<string> ValidPathWithoutARootButWithATrailingDirectorySeparator()
      => NonEmptyListOf(ValidPathComponent())
        .Select(directories => directories.ToDelimitedStringWithTrailingDelimiter(Path.DirectorySeparatorChar.ToString()));

   /* ------------------------------------------------------------ */

   public static Gen<string> ValidPathWithAVolumeRoot()
      => Gen
        .OneOf(ValidPathWithAVolumeRootAndATrailingDirectorySeparator(),
               ValidPathWithAVolumeRootButWithoutATrailingDirectorySeparator());

   /* ------------------------------------------------------------ */

   public static Gen<string> ValidPathWithAVolumeRootAndATrailingDirectorySeparator()
      => AsciiLetter()
        .Combine(ValidPathWithoutARootButWithATrailingDirectorySeparator(),
                 (volume,
                  directories) => $"{volume}:{Path.DirectorySeparatorChar}{directories}");

   /* ------------------------------------------------------------ */

   public static Gen<string> ValidPathWithAVolumeRootButWithoutATrailingDirectorySeparator()
      => AsciiLetter()
        .Combine(ValidPathWithoutARootOrATrailingDirectorySeparator(),
                 (volume,
                  directories) => $"{volume}:{Path.DirectorySeparatorChar}{directories}");

   /* ------------------------------------------------------------ */

   public static Gen<string> ValidVolumeComponent()
      => AsciiLetter()
        .Select(volume => $"{volume}:");

   /* ------------------------------------------------------------ */

   public static Gen<string> VolumeComponentWithInvalidFirstCharacter()
      => NonAsciiLetter()
        .Select(x => $"{x}:");

   /* ------------------------------------------------------------ */

   public static Gen<string> VolumeComponentWithInvalidSecondCharacter()
      => AsciiLetter()
        .Combine(Char().Where(x => x != ':'),
                 (x, y) => $"{x}{y}");

   /* ------------------------------------------------------------ */

   public static Gen<string> VolumeComponentWithTheWrongNumberOfCharacters()
      => NonNullString()
        .Where(x => x.Length != 2);

   /* ------------------------------------------------------------ */
}
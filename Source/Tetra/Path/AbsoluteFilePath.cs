using static Tetra.TetraMessages;

namespace Tetra;

public class AbsoluteFilePath : IComparable<AbsoluteFilePath>,
                                IEquatable<AbsoluteFilePath>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static AbsoluteFilePath Create(string potentialPath)
      => ParseComponents(potentialPath,
                         PathType)
        .Reduce(failure => throw new ArgumentException(failure.Content()
                                                              .Content(),
                                                       nameof(potentialPath)),
                success => new AbsoluteFilePath(success.Content()
                                                       .directories,
                                                success.Content()
                                                       .file,
                                                success.Content()
                                                       .volume));

   /* ------------------------------------------------------------ */

   public static AbsoluteFilePath Create(Volume                                  volume,
                                         IReadOnlyCollection<DirectoryComponent> directories,
                                         FileComponent                           file)
      => new(directories,
             file,
             volume);

   /* ------------------------------------------------------------ */

   public static Result<AbsoluteFilePath> Parse(string potentialPath)
      => ParseComponents(potentialPath,
                         PathType)
        .Map(success => new AbsoluteFilePath(success.Content()
                                                    .directories,
                                             success.Content()
                                                    .file,
                                             success.Content()
                                                    .volume));

   /* ------------------------------------------------------------ */
   // object Overridden Methods
   /* ------------------------------------------------------------ */

   public override bool Equals(object? obj)
      => ReferenceEquals(this,
                         obj)
      || obj is AbsoluteFilePath path
      && Equals(path);

   /* ------------------------------------------------------------ */

   public override int GetHashCode()
      => StringComparer
        .OrdinalIgnoreCase
        .GetHashCode(_value);

   /* ------------------------------------------------------------ */

   public override string ToString()
      => $"<{_value}>";

   /* ------------------------------------------------------------ */
   // IComparable<FileComponent> Methods
   /* ------------------------------------------------------------ */

   public int CompareTo(AbsoluteFilePath? other)
      => StringComparer
        .OrdinalIgnoreCase
        .Compare(_value,
                 other?._value);

   /* ------------------------------------------------------------ */
   // IEquatable<FileComponent> Methods
   /* ------------------------------------------------------------ */

   public bool Equals(AbsoluteFilePath? other)
      => StringComparer
        .OrdinalIgnoreCase
        .Equals(_value,
                other?._value);

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public FileComponent File()
      => _file;

   /* ------------------------------------------------------------ */

   public AbsoluteDirectoryPath Parent()
      => AbsoluteDirectoryPath
        .Create(_volume,
                _directories);

   /* ------------------------------------------------------------ */

   public string Value()
      => _value;

   /* ------------------------------------------------------------ */

   public Volume Volume()
      => _volume;

   /* ------------------------------------------------------------ */
   // Protected Constructors
   /* ------------------------------------------------------------ */

   protected AbsoluteFilePath(IReadOnlyCollection<DirectoryComponent> directories,
                              FileComponent                           file,
                              Volume                                  volume)
   {
      _directories = directories;
      _file        = file;
      _volume      = volume;

      _value = PathBuilder.Combine(volume,
                                   directories,
                                   file);
   }

   /* ------------------------------------------------------------ */
   // Protected Methods
   /* ------------------------------------------------------------ */

   protected static Result<(Volume volume, IReadOnlyCollection<DirectoryComponent> directories, FileComponent file)> ParseComponents(string potentialPath,
      string                                                                                                                                pathType)
   {
      if (string.IsNullOrEmpty(potentialPath))
      {
         return Message.Create(IsNotAValidVolumeRootedPathBecauseMayNotBeEmpty(potentialPath,
                                                                               pathType));
      }

      var components = potentialPath
                      .Split(Path.DirectorySeparatorChar,
                             Path.AltDirectorySeparatorChar)
                      .ToArray();

      var potentialVolume = components[0];

      if (potentialVolume.IsNotAValidVolumeLabel())
      {
         return Message.Create(IsNotAValidVolumeRootedPathBecauseMustStartWithAVolumeLabel(potentialPath,
                                                                                           pathType));
      }

      var potentialComponents = components
                               .Skip(1)
                               .Where(x => !string.IsNullOrEmpty(x)) //Todo: Add test for this behaviour
                               .ToArray();

      if (potentialComponents.Any(x => x.IsNotAValidPathComponent()))
      {
         return Message.Create(IsNotAValidVolumeRootedPathBecauseMayNotContainTheCharacters(potentialPath,
                                                                                            pathType));
      }

      if (string.IsNullOrEmpty(components[^1]))
      {
         return Message.Create(IsNotAValidVolumeRootedPathBecauseMayNotEndWithADirectorySeparator(potentialPath,
                                                                                                  pathType));
      }

      return (Tetra.Volume
                   .Create(potentialVolume[0]),
              potentialComponents.SkipLast(1)
                                 .Select(DirectoryComponent.Create)
                                 .ToArray(),
              FileComponent.Create(components[^1]));
   }

   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string PathType = "volume-rooted file path";

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IReadOnlyCollection<DirectoryComponent> _directories;
   private readonly FileComponent                           _file;
   private readonly string                                  _value;
   private readonly Volume                                  _volume;

   /* ------------------------------------------------------------ */
}
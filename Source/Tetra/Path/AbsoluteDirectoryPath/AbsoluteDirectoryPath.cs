using static Tetra.TetraMessages;

namespace Tetra;

public class AbsoluteDirectoryPath : IComparable<AbsoluteDirectoryPath>,
                                     IEquatable<AbsoluteDirectoryPath>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static AbsoluteDirectoryPath Create(string potentialPath)
      => ParseComponents(potentialPath,
                         PathType)
        .Reduce(Exceptions.ThrowArgumentException<AbsoluteDirectoryPath>(nameof(potentialPath)),
                Create);

   /* ------------------------------------------------------------ */

   public static AbsoluteDirectoryPath Create(VolumeComponent                         volume,
                                              IReadOnlyCollection<DirectoryComponent> directories)
      => new(directories,
             volume);

   /* ------------------------------------------------------------ */

   public static Result<AbsoluteDirectoryPath> Parse(string potentialPath)
      => ParseComponents(potentialPath,
                         PathType)
        .Map(Create);

   /* ------------------------------------------------------------ */
   // object Overridden Methods
   /* ------------------------------------------------------------ */

   public override bool Equals(object? obj)
      => ReferenceEquals(this,
                         obj)
      || obj is AbsoluteDirectoryPath path
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
   // IComparable<AbsoluteDirectoryPath> Methods
   /* ------------------------------------------------------------ */

   public int CompareTo(AbsoluteDirectoryPath? other)
      => StringComparer
        .OrdinalIgnoreCase
        .Compare(_value,
                 other?._value);

   /* ------------------------------------------------------------ */
   // IEquatable<AbsoluteDirectoryPath> Methods
   /* ------------------------------------------------------------ */

   public bool Equals(AbsoluteDirectoryPath? other)
      => StringComparer
        .OrdinalIgnoreCase
        .Equals(_value,
                other?._value);

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public string Value()
      => _value;

   /* ------------------------------------------------------------ */

   public VolumeComponent Volume()
      => _volume;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public AbsoluteDirectoryPath Append(params DirectoryComponent[] directories)
      => Create(_volume,
                _directories.Concat(directories)
                            .ToArray());

   /* ------------------------------------------------------------ */

   public AbsoluteDirectoryPath Append(IEnumerable<DirectoryComponent> directories)
      => Create(_volume,
                _directories.Concat(directories)
                            .ToArray());

   /* ------------------------------------------------------------ */

   public AbsoluteDirectoryPath Append(RelativeDirectoryPath path)
      => Create(_volume,
                _directories.Concat(path._directories)
                            .ToArray());

   /* ------------------------------------------------------------ */

   public AbsoluteFilePath Append(FileComponent file)
      => AbsoluteFilePath
        .Create(_volume,
                _directories,
                file);

   /* ------------------------------------------------------------ */

   public AbsoluteFilePath Append(RelativeFilePath path)
      => AbsoluteFilePath
        .Create(_volume,
                _directories.Concat(path._directories)
                            .ToArray(),
                path._file);

   /* ------------------------------------------------------------ */

   public Option<AbsoluteDirectoryPath> Parent()
      => _directories.Any()
            ? Option.Some(Create(_volume,
                                 _directories.SkipLast(1)
                                             .ToArray()))
            : Option<AbsoluteDirectoryPath>.None();

   /* ------------------------------------------------------------ */
   // Protected Constructors
   /* ------------------------------------------------------------ */

   protected AbsoluteDirectoryPath(IReadOnlyCollection<DirectoryComponent> directories,
                                   VolumeComponent                         volume)
   {
      _directories = directories;
      _volume      = volume;

      _value = PathBuilder.Combine(volume,
                                   directories);
   }

   /* ------------------------------------------------------------ */
   // Protected Methods
   /* ------------------------------------------------------------ */

   protected static Result<(VolumeComponent volume, IReadOnlyCollection<DirectoryComponent> directories)> ParseComponents(
      string potentialPath,
      string pathType)
   {
      if (string.IsNullOrEmpty(potentialPath))
      {
         return Message.Create(IsNotValidBecauseAnAbsolutePathMayNotBeEmpty(potentialPath,
                                                                            pathType));
      }

      var components = potentialPath
                      .Split(Path.DirectorySeparatorChar,
                             Path.AltDirectorySeparatorChar)
                      .ToArray();

      var potentialVolume = components[0];

      if (potentialVolume.IsNotAValidVolumeLabel())
      {
         return Message.Create(IsNotValidBecauseAnAbsolutePathMustStartWithAVolumeLabel(potentialPath,
                                                                                        pathType));
      }

      var directoryComponents = components
                               .Skip(1)
                               .Where(x => !string.IsNullOrEmpty(x)) //Todo: Add test for this behaviour
                               .ToArray();

      if (directoryComponents.Any(x => x.IsNotAValidPathComponent()))
      {
         return Message.Create(IsNotValidBecauseAnAbsolutePathMayNotContainTheCharacters(potentialPath,
                                                                                         pathType));
      }

      return (VolumeComponent.Create(potentialVolume[0]),
              directoryComponents.Select(DirectoryComponent.Create)
                                 .ToArray());
   }

   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string PathType = "absolute directory path";

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   internal readonly IReadOnlyCollection<DirectoryComponent> _directories;
   private readonly string                                  _value;
   private readonly VolumeComponent                         _volume;

   /* ------------------------------------------------------------ */
   // Private Factory Functions
   /* ------------------------------------------------------------ */

   private static AbsoluteDirectoryPath Create(Success<(VolumeComponent volume, IReadOnlyCollection<DirectoryComponent> directories)> success)
      => new(success.Content()
                    .directories,
             success.Content()
                    .volume);

   /* ------------------------------------------------------------ */
}
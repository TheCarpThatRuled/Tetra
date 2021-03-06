using static Tetra.TetraMessages;

namespace Tetra;

public class RelativeFilePath : IComparable<RelativeFilePath>,
                                IEquatable<RelativeFilePath>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static RelativeFilePath Create(string potentialPath)
      => ParseComponents(potentialPath,
                         PathType)
        .Reduce(Exceptions.ThrowArgumentException<RelativeFilePath>(nameof(potentialPath)),
                Create);

   /* ------------------------------------------------------------ */

   public static RelativeFilePath Create(IReadOnlyCollection<DirectoryComponent> directories,
                                         FileComponent                           file)
      => new(directories,
             file);

   /* ------------------------------------------------------------ */

   public static Result<RelativeFilePath> Parse(string potentialPath)
      => ParseComponents(potentialPath,
                         PathType)
        .Map(Create);

   /* ------------------------------------------------------------ */
   // object Overridden Methods
   /* ------------------------------------------------------------ */

   public override bool Equals(object? obj)
      => ReferenceEquals(this,
                         obj)
      || obj is RelativeFilePath path
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
   // IComparable<RelativeFilePath> Methods
   /* ------------------------------------------------------------ */

   public int CompareTo(RelativeFilePath? other)
      => StringComparer
        .OrdinalIgnoreCase
        .Compare(_value,
                 other?._value);

   /* ------------------------------------------------------------ */
   // IEquatable<RelativeFilePath> Methods
   /* ------------------------------------------------------------ */

   public bool Equals(RelativeFilePath? other)
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

   public Option<RelativeDirectoryPath> Parent()
      => _directories.Any()
            ? RelativeDirectoryPath.Create(_directories)
            : Option<RelativeDirectoryPath>.None();

   /* ------------------------------------------------------------ */

   public string Value()
      => _value;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public AbsoluteFilePath Prepend(AbsoluteDirectoryPath path)
      => AbsoluteFilePath.Create(path.Volume(),
                                 path._directories
                                     .Concat(_directories)
                                     .ToArray(),
                                 _file);

   /* ------------------------------------------------------------ */

   public RelativeFilePath Prepend(params DirectoryComponent[] directories)
      => Create(directories.Concat(_directories)
                           .ToArray(),
                _file);

   /* ------------------------------------------------------------ */

   public RelativeFilePath Prepend(IEnumerable<DirectoryComponent> directories)
      => Create(directories.Concat(_directories)
                           .ToArray(),
                _file);

   /* ------------------------------------------------------------ */

   public RelativeFilePath Prepend(RelativeDirectoryPath path)
      => Create(path._directories
                    .Concat(_directories)
                    .ToArray(),
                _file);

   /* ------------------------------------------------------------ */

   public AbsoluteFilePath Prepend(VolumeComponent volume)
      => AbsoluteFilePath
        .Create(volume,
                _directories,
                _file);

   /* ------------------------------------------------------------ */
   // Protected Constructors
   /* ------------------------------------------------------------ */

   public RelativeFilePath() { }

   protected RelativeFilePath(IReadOnlyCollection<DirectoryComponent> directories,
                              FileComponent                           file)
   {
      _directories = directories;
      _file        = file;

      _value = PathBuilder.Combine(directories,
                                   file);
   }

   /* ------------------------------------------------------------ */
   // Protected Methods
   /* ------------------------------------------------------------ */

   protected static Result<(IReadOnlyCollection<DirectoryComponent> directories, FileComponent file)> ParseComponents(string potentialPath,
                                                                                                                      string pathType)
   {
      if (string.IsNullOrEmpty(potentialPath))
      {
         return Message.Create(IsNotValidBecauseARelativePathMayNotBeEmpty(potentialPath,
                                                                           pathType));
      }

      var components = potentialPath
                      .Split(Path.DirectorySeparatorChar,
                             Path.AltDirectorySeparatorChar)
                      .ToArray();

      var potentialComponents = components
                               .Where(x => !string.IsNullOrEmpty(x)) //Todo: Add test for this behaviour
                               .ToArray();

      if (potentialComponents.Any(x => x.IsNotAValidPathComponent()))
      {
         return Message.Create(IsNotValidBecauseARelativePathMayNotContainTheCharacters(potentialPath,
                                                                                        pathType));
      }

      if (string.IsNullOrEmpty(components[^1]))
      {
         return Message.Create(IsNotValidBecauseARelativeFilePathMayNotEndWithADirectorySeparator(potentialPath,
                                                                                                  pathType));
      }

      return (potentialComponents.SkipLast(1)
                                 .Select(DirectoryComponent.Create)
                                 .ToArray(),
              FileComponent.Create(components[^1]));
   }

   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string PathType = "relative file path";

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   internal readonly IReadOnlyCollection<DirectoryComponent> _directories;
   internal readonly FileComponent                           _file;
   private readonly  string                                  _value;

   /* ------------------------------------------------------------ */
   // Private Factory Functions
   /* ------------------------------------------------------------ */

   private static RelativeFilePath Create(Success<(IReadOnlyCollection<DirectoryComponent> directories, FileComponent file)> success)
      => new(success.Content()
                    .directories,
             success.Content()
                    .file);

   /* ------------------------------------------------------------ */
}
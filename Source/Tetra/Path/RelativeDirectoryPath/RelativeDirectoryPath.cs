using static Tetra.TetraMessages;

namespace Tetra;

public class RelativeDirectoryPath : IComparable<RelativeDirectoryPath>,
                                     IEquatable<RelativeDirectoryPath>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static RelativeDirectoryPath Create(string potentialPath)
      => ParseComponents(potentialPath,
                         PathType)
        .Reduce(Exceptions.ThrowArgumentException<RelativeDirectoryPath>(nameof(potentialPath)),
                Create);

   /* ------------------------------------------------------------ */

   public static RelativeDirectoryPath Create(params DirectoryComponent[] directories)
      => new(directories);

   /* ------------------------------------------------------------ */

   public static RelativeDirectoryPath Create(IReadOnlyCollection<DirectoryComponent> directories)
      => new(directories);

   /* ------------------------------------------------------------ */

   public static Result<RelativeDirectoryPath> Parse(string potentialPath)
      => ParseComponents(potentialPath,
                         PathType)
        .Map(Create);

   /* ------------------------------------------------------------ */
   // object Overridden Methods
   /* ------------------------------------------------------------ */

   public override bool Equals(object? obj)
      => ReferenceEquals(this,
                         obj)
      || obj is RelativeDirectoryPath path
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
   // IComparable<RelativeDirectoryPath> Methods
   /* ------------------------------------------------------------ */

   public int CompareTo(RelativeDirectoryPath? other)
      => StringComparer
        .OrdinalIgnoreCase
        .Compare(_value,
                 other?._value);

   /* ------------------------------------------------------------ */
   // IEquatable<RelativeDirectoryPath> Methods
   /* ------------------------------------------------------------ */

   public bool Equals(RelativeDirectoryPath? other)
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
   // Methods
   /* ------------------------------------------------------------ */

   public RelativeDirectoryPath Append(params DirectoryComponent[] directories)
      => new();

   /* ------------------------------------------------------------ */

   public RelativeDirectoryPath Append(IEnumerable<DirectoryComponent> directories)
      => new();

   /* ------------------------------------------------------------ */

   public RelativeDirectoryPath Append(RelativeDirectoryPath path)
      => new();

   /* ------------------------------------------------------------ */

   public RelativeFilePath Append(FileComponent file)
      => new();

   /* ------------------------------------------------------------ */

   public RelativeFilePath Append(RelativeFilePath path)
      => new();

   /* ------------------------------------------------------------ */

   public Option<RelativeDirectoryPath> Parent()
      => _directories.Count > 1
            ? Option.Some(Create(_directories
                                .SkipLast(1)
                                .ToArray()))
            : Option<RelativeDirectoryPath>.None();

   /* ------------------------------------------------------------ */

   public AbsoluteDirectoryPath Prepend(AbsoluteDirectoryPath path)
      => null;

   /* ------------------------------------------------------------ */

   public RelativeDirectoryPath Prepend(params DirectoryComponent[] directories)
      => new();

   /* ------------------------------------------------------------ */

   public RelativeDirectoryPath Prepend(IEnumerable<DirectoryComponent> directories)
      => new();

   /* ------------------------------------------------------------ */

   public RelativeDirectoryPath Prepend(RelativeDirectoryPath path)
      => new();

   /* ------------------------------------------------------------ */

   public RelativeFilePath Prepend(FileComponent file)
      => new();

   /* ------------------------------------------------------------ */

   public RelativeFilePath Prepend(RelativeFilePath path)
      => new();

   /* ------------------------------------------------------------ */

   public AbsoluteDirectoryPath Prepend(VolumeComponent volume)
      => null;

   /* ------------------------------------------------------------ */
   // Protected Constructors
   /* ------------------------------------------------------------ */

   protected RelativeDirectoryPath(IReadOnlyCollection<DirectoryComponent> directories)
   {
      _directories = directories;

      _value = PathBuilder.Combine(directories);
   }

   public RelativeDirectoryPath() { }

   /* ------------------------------------------------------------ */
   // Protected Methods
   /* ------------------------------------------------------------ */

   protected static Result<IReadOnlyCollection<DirectoryComponent>> ParseComponents(string potentialPath,
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

      var directoryComponents = components
                               .Where(x => !string.IsNullOrEmpty(x)) //Todo: Add test for this behaviour
                               .ToArray();

      if (directoryComponents.Any(x => x.IsNotAValidPathComponent()))
      {
         return Message.Create(IsNotValidBecauseARelativePathMayNotContainTheCharacters(potentialPath,
                                                                                         pathType));
      }

      return directoryComponents
            .Select(DirectoryComponent.Create)
            .ToArray();
   }

   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string PathType = "relative directory path";

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   internal readonly IReadOnlyCollection<DirectoryComponent> _directories;
   private readonly string                                  _value;

   /* ------------------------------------------------------------ */
   // Private Factory Functions
   /* ------------------------------------------------------------ */

   private static RelativeDirectoryPath Create(Success<IReadOnlyCollection<DirectoryComponent>> success)
      => new(success.Content());

   /* ------------------------------------------------------------ */
}
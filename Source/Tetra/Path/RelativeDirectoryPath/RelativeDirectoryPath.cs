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
        .Reduce(CreateInternal,
                Exceptions.ThrowArgumentException<RelativeDirectoryPath>(nameof(potentialPath)));

   /* ------------------------------------------------------------ */

   public static RelativeDirectoryPath Create(params DirectoryComponent[] directories)
      => new(directories.Materialise());

   /* ------------------------------------------------------------ */

   public static RelativeDirectoryPath Create(ISequence<DirectoryComponent> directories)
      => new(directories);

   /* ------------------------------------------------------------ */

   public static IEither<RelativeDirectoryPath, Message> Parse(string potentialPath)
      => ParseComponents(potentialPath,
                         PathType)
        .Map(CreateInternal,
             Function.PassThrough);

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

   public RelativeDirectoryPath Append(params DirectoryComponent[] child)
      => Create(_directories
               .Concat(child)
               .ToArray());

   /* ------------------------------------------------------------ */

   public RelativeDirectoryPath Append(IEnumerable<DirectoryComponent> child)
      => Create(_directories
               .Concat(child)
               .ToArray());

   /* ------------------------------------------------------------ */

   public RelativeDirectoryPath Append(RelativeDirectoryPath child)
      => child
        .Prepend(_directories);

   /* ------------------------------------------------------------ */

   public RelativeFilePath Append(FileComponent child)
      => RelativeFilePath
        .Create(_directories,
                child);

   /* ------------------------------------------------------------ */

   public RelativeFilePath Append(RelativeFilePath child)
      => child
        .Prepend(_directories);

   /* ------------------------------------------------------------ */

   public IOption<RelativeDirectoryPath> Parent()
      => _directories.Length() > 1
            ? Option.Some(Create(_directories
                                .SkipLast(1)
                                .ToArray()))
            : Option<RelativeDirectoryPath>.None();

   /* ------------------------------------------------------------ */

   public AbsoluteDirectoryPath Prepend(AbsoluteDirectoryPath parent)
      => parent
        .Append(_directories);

   /* ------------------------------------------------------------ */

   public RelativeDirectoryPath Prepend(params DirectoryComponent[] parent)
      => Create(parent
               .Concat(_directories)
               .ToArray());

   /* ------------------------------------------------------------ */

   public RelativeDirectoryPath Prepend(IEnumerable<DirectoryComponent> parent)
      => Create(parent
               .Concat(_directories)
               .ToArray());

   /* ------------------------------------------------------------ */

   public RelativeDirectoryPath Prepend(RelativeDirectoryPath parent)
      => parent
        .Append(_directories);

   /* ------------------------------------------------------------ */

   public AbsoluteDirectoryPath Prepend(VolumeComponent parent)
      => AbsoluteDirectoryPath
        .Create(parent,
                _directories);

   /* ------------------------------------------------------------ */
   // Protected Constructors
   /* ------------------------------------------------------------ */

   protected RelativeDirectoryPath(ISequence<DirectoryComponent> directories)
   {
      _directories = directories;

      _value = PathBuilder.Combine(directories);
   }

   /* ------------------------------------------------------------ */
   // Protected Methods
   /* ------------------------------------------------------------ */

   protected static IEither<ISequence<DirectoryComponent>, Message> ParseComponents(string potentialPath,
                                                                                    string pathType)
   {
      if (string.IsNullOrEmpty(potentialPath))
      {
         return Either<ISequence<DirectoryComponent>, Message>
           .Right(Message.Create(IsNotValidBecauseARelativePathMayNotBeEmpty(potentialPath,
                                                                               pathType)));
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
         return Either<ISequence<DirectoryComponent>, Message>
           .Right(Message.Create(IsNotValidBecauseARelativePathMayNotContainTheCharacters(potentialPath,
                                                                                            pathType)));
      }

      return Either<ISequence<DirectoryComponent>, Message>
        .Left(directoryComponents
                .Select(DirectoryComponent.Create)
                .Materialise());
   }

   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string PathType = "relative directory path";

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly ISequence<DirectoryComponent> _directories;
   private readonly string                        _value;

   /* ------------------------------------------------------------ */
   // Private Factory Functions
   /* ------------------------------------------------------------ */

   private static RelativeDirectoryPath CreateInternal(ISequence<DirectoryComponent> success)
      => new(success);

   /* ------------------------------------------------------------ */
}
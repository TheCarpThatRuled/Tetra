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
        .Reduce(Create,
                Exceptions.ThrowArgumentException<RelativeFilePath>(nameof(potentialPath)));

   /* ------------------------------------------------------------ */

   public static RelativeFilePath Create(ISequence<DirectoryComponent> directories,
                                         FileComponent                 file)
      => new(directories,
             file);

   /* ------------------------------------------------------------ */

   public static IEither<RelativeFilePath, Message> Parse(string potentialPath)
      => ParseComponents(potentialPath,
                         PathType)
        .Map(Create,
             Function.PassThrough);

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

   public IOption<RelativeDirectoryPath> Parent()
      => _directories.Any()
            ? Option.Some(RelativeDirectoryPath.Create(_directories))
            : Option<RelativeDirectoryPath>.None();

   /* ------------------------------------------------------------ */

   public string Value()
      => _value;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public AbsoluteFilePath Prepend(AbsoluteDirectoryPath parent)
      => parent
        .Append(_directories)
        .Append(_file);

   /* ------------------------------------------------------------ */

   public RelativeFilePath Prepend(params DirectoryComponent[] parent)
      => Create(parent.Concat(_directories)
                      .Materialise(),
                _file);

   /* ------------------------------------------------------------ */

   public RelativeFilePath Prepend(IEnumerable<DirectoryComponent> parent)
      => Create(parent.Concat(_directories)
                      .Materialise(),
                _file);

   /* ------------------------------------------------------------ */

   public RelativeFilePath Prepend(RelativeDirectoryPath parent)
      => parent
        .Append(_directories)
        .Append(_file);

   /* ------------------------------------------------------------ */

   public AbsoluteFilePath Prepend(VolumeComponent parent)
      => AbsoluteFilePath
        .Create(parent,
                _directories,
                _file);

   /* ------------------------------------------------------------ */
   // Protected Constructors
   /* ------------------------------------------------------------ */

   protected RelativeFilePath(ISequence<DirectoryComponent> directories,
                              FileComponent                 file)
   {
      _directories = directories;
      _file        = file;

      _value = PathBuilder.Combine(directories,
                                   file);
   }

   /* ------------------------------------------------------------ */
   // Protected Methods
   /* ------------------------------------------------------------ */

   protected static IEither<(ISequence<DirectoryComponent> directories, FileComponent file), Message> ParseComponents(string potentialPath,
                                                                                                                      string pathType)
   {
      if (string.IsNullOrEmpty(potentialPath))
      {
         return Either<(ISequence<DirectoryComponent> directories, FileComponent file), Message>
           .Right(Message.Create(IsNotValidBecauseARelativePathMayNotBeEmpty(potentialPath,
                                                                               pathType)));
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
         return Either<(ISequence<DirectoryComponent> directories, FileComponent file), Message>
           .Right(Message.Create(IsNotValidBecauseARelativePathMayNotContainTheCharacters(potentialPath,
                                                                                            pathType)));
      }

      if (string.IsNullOrEmpty(components[^1]))
      {
         return Either<(ISequence<DirectoryComponent> directories, FileComponent file), Message>
           .Right(Message.Create(IsNotValidBecauseARelativeFilePathMayNotEndWithADirectorySeparator(potentialPath,
                                                                                                      pathType)));
      }

      return Either<(ISequence<DirectoryComponent> directories, FileComponent file), Message>
        .Left((potentialComponents.SkipLast(1)
                                     .Select(DirectoryComponent.Create)
                                     .Materialise(),
                  FileComponent.Create(components[^1])));
   }

   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string PathType = "relative file path";

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly ISequence<DirectoryComponent> _directories;
   private readonly FileComponent                 _file;
   private readonly string                        _value;

   /* ------------------------------------------------------------ */
   // Private Factory Functions
   /* ------------------------------------------------------------ */

   private static RelativeFilePath Create((ISequence<DirectoryComponent> directories, FileComponent file) success)
      => new(success.directories,
             success.file);

   /* ------------------------------------------------------------ */
}
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
        .Reduce(Create,
                Exceptions.ThrowArgumentException<AbsoluteFilePath>(nameof(potentialPath)));

   /* ------------------------------------------------------------ */

   public static AbsoluteFilePath Create(VolumeComponent               volume,
                                         ISequence<DirectoryComponent> directories,
                                         FileComponent                 file)
      => new(directories,
             file,
             volume);

   /* ------------------------------------------------------------ */

   public static IEither<AbsoluteFilePath, Message> Parse(string potentialPath)
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
   // IComparable<AbsoluteFilePath> Methods
   /* ------------------------------------------------------------ */

   public int CompareTo(AbsoluteFilePath? other)
      => StringComparer
        .OrdinalIgnoreCase
        .Compare(_value,
                 other?._value);

   /* ------------------------------------------------------------ */
   // IEquatable<AbsoluteFilePath> Methods
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

   public VolumeComponent Volume()
      => _volume;

   /* ------------------------------------------------------------ */
   // Protected Constructors
   /* ------------------------------------------------------------ */

   protected AbsoluteFilePath(ISequence<DirectoryComponent> directories,
                              FileComponent                           file,
                              VolumeComponent                         volume)
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

   protected static IEither<(VolumeComponent volume, ISequence<DirectoryComponent> directories, FileComponent file), Message> ParseComponents(string potentialPath,
      string                                                                                                                                         pathType)
   {
      if (string.IsNullOrEmpty(potentialPath))
      {
         return Either<(VolumeComponent volume, ISequence<DirectoryComponent> directories, FileComponent file), Message>
           .Right(Message.Create(IsNotValidBecauseAnAbsolutePathMayNotBeEmpty(potentialPath,
                                                                                pathType)));
      }

      var components = potentialPath
                      .Split(Path.DirectorySeparatorChar,
                             Path.AltDirectorySeparatorChar)
                      .ToArray();

      var potentialVolume = components[0];

      if (potentialVolume.IsNotAValidVolumeLabel())
      {
         return Either<(VolumeComponent volume, ISequence<DirectoryComponent> directories, FileComponent file), Message>
           .Right(Message.Create(IsNotValidBecauseAnAbsolutePathMustStartWithAVolumeLabel(potentialPath,
                                                                                            pathType)));
      }

      var potentialComponents = components
                               .Skip(1)
                               .Where(x => !string.IsNullOrEmpty(x)) //Todo: Add test for this behaviour
                               .ToArray();

      if (potentialComponents.Any(x => x.IsNotAValidPathComponent()))
      {
         return Either<(VolumeComponent volume, ISequence<DirectoryComponent> directories, FileComponent file), Message>
           .Right(Message.Create(IsNotValidBecauseAnAbsolutePathMayNotContainTheCharacters(potentialPath,
                                                                                             pathType)));
      }

      if (string.IsNullOrEmpty(components[^1]))
      {
         return Either<(VolumeComponent volume, ISequence<DirectoryComponent> directories, FileComponent file), Message>
           .Right(Message.Create(IsNotValidBecauseAnAbsoluteFilePathMayNotEndWithADirectorySeparator(potentialPath,
                                                                                                       pathType)));
      }

      return Either<(VolumeComponent volume, ISequence<DirectoryComponent> directories, FileComponent file), Message>
        .Left((VolumeComponent.Create(potentialVolume[0]),
                  potentialComponents.SkipLast(1)
                                     .Select(DirectoryComponent.Create)
                                     .Materialise(),
                  FileComponent.Create(components[^1])));
   }

   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string PathType = "absolute file path";

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly ISequence<DirectoryComponent> _directories;
   private readonly FileComponent                 _file;
   private readonly string                        _value;
   private readonly VolumeComponent               _volume;

   /* ------------------------------------------------------------ */
   // Private Factory Functions
   /* ------------------------------------------------------------ */

   private static AbsoluteFilePath Create((VolumeComponent volume, ISequence<DirectoryComponent> directories, FileComponent file) success)
      => new(success.directories,
             success.file,
             success.volume);

   /* ------------------------------------------------------------ */
}
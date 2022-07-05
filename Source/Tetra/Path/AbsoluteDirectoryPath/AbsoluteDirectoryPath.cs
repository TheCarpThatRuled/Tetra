﻿namespace Tetra;
using static TetraMessages;

public class AbsoluteDirectoryPath : IComparable<AbsoluteDirectoryPath>,
                                     IEquatable<AbsoluteDirectoryPath>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static AbsoluteDirectoryPath Create(string potentialPath)
      => ParseComponents(potentialPath,
                         PathType)
        .Reduce(failure => throw new ArgumentException(failure.Content()
                                                              .Content(),
                                                       nameof(potentialPath)),
                success => new AbsoluteDirectoryPath(success.Content()
                                                            .directories,
                                                     success.Content()
                                                            .volume));

   /* ------------------------------------------------------------ */

   public static AbsoluteDirectoryPath Create(Volume                                  volume,
                                              IReadOnlyCollection<DirectoryComponent> directories)
      => new(directories,
             volume);

   /* ------------------------------------------------------------ */

   public static Result<AbsoluteDirectoryPath> Parse(string potentialPath)
      => ParseComponents(potentialPath,
                         PathType)
        .Map(success => new AbsoluteDirectoryPath(success.Content()
                                                         .directories,
                                                  success.Content()
                                                         .volume));

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
   // IComparable<FileComponent> Methods
   /* ------------------------------------------------------------ */

   public int CompareTo(AbsoluteDirectoryPath? other)
      => StringComparer
        .OrdinalIgnoreCase
        .Compare(_value,
                 other?._value);

   /* ------------------------------------------------------------ */
   // IEquatable<FileComponent> Methods
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
   // Properties
   /* ------------------------------------------------------------ */

   public Volume Volume()
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

   public VolumeRootedFilePath Append(FileComponent file)
      => VolumeRootedFilePath
        .Create(_volume,
                _directories,
                file);

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
                                   Volume                                  volume)
   {
      _directories = directories;
      _volume      = volume;

      _value = PathBuilder.Combine(volume,
                                   directories);
   }

   /* ------------------------------------------------------------ */
   // Protected Methods
   /* ------------------------------------------------------------ */

   protected static Result<(Volume volume, IReadOnlyCollection<DirectoryComponent> directories)> ParseComponents(string potentialPath,
                                                                                                                 string pathType)
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

      var directoryComponents = components
                               .Skip(1)
                               .Where(x => !string.IsNullOrEmpty(x)) //Todo: Add test for this behaviour
                               .ToArray();

      if (directoryComponents.Any(x => x.IsNotAValidPathComponent()))
      {
         return Message.Create(IsNotAValidVolumeRootedPathBecauseMayNotContainTheCharacters(potentialPath,
                                                                                            pathType));
      }

      return (Tetra.Volume
                   .Create(potentialVolume[0]),
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

   private readonly IReadOnlyCollection<DirectoryComponent> _directories;
   private readonly string                                  _value;
   private readonly Volume                                  _volume;

   /* ------------------------------------------------------------ */
}
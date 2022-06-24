namespace Tetra;
using static TetraMessages;

public class VolumeRootedDirectoryPath : AbsoluteDirectoryPath
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static VolumeRootedDirectoryPath Create(string potentialPath)
      => ParseComponents(potentialPath,
                         PathType)
        .Reduce(failure => throw new ArgumentException(failure.Content()
                                                              .Content(),
                                                       nameof(potentialPath)),
                success => new VolumeRootedDirectoryPath(success.Content()
                                                                .directories,
                                                         success.Content()
                                                                .volume));

   /* ------------------------------------------------------------ */

   public static VolumeRootedDirectoryPath Create(Volume                                  volume,
                                                  IReadOnlyCollection<DirectoryComponent> directories)
      => new(directories,
             volume);

   /* ------------------------------------------------------------ */

   public static Result<VolumeRootedDirectoryPath> Parse(string potentialPath)
      => ParseComponents(potentialPath,
                         PathType)
        .Map(success => new VolumeRootedDirectoryPath(success.Content()
                                                             .directories,
                                                      success.Content()
                                                             .volume));

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public VolumeRootedDirectoryPath Append(params DirectoryComponent[] directories)
      => Create(_volume,
                _directories.Concat(directories)
                            .ToArray());

   /* ------------------------------------------------------------ */

   public VolumeRootedDirectoryPath Append(IEnumerable<DirectoryComponent> directories)
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

   public Option<VolumeRootedDirectoryPath> Parent()
      => Option
        .None();

   /* ------------------------------------------------------------ */
   // Protected Constructors
   /* ------------------------------------------------------------ */

   protected VolumeRootedDirectoryPath(IReadOnlyCollection<DirectoryComponent> directories,
                                       Volume                                  volume)
      : base(PathBuilder.Combine(volume,
                                 directories))
   {
      _directories = directories;
      _volume      = volume;
   }

   /* ------------------------------------------------------------ */
   // Protected Methods
   /* ------------------------------------------------------------ */

   protected static Result<(Volume volume, IReadOnlyCollection<DirectoryComponent> directories)> ParseComponents(string potentialPath,
                                                                                                                 string pathType)
   {
      //Todo: Handle the empty string

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

      return (Volume.Create(potentialVolume[0]),
              directoryComponents.Select(DirectoryComponent.Create)
                                 .ToArray());
   }

   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string PathType = "volume-rooted directory path";

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IReadOnlyCollection<DirectoryComponent> _directories;
   private readonly Volume                                  _volume;

   /* ------------------------------------------------------------ */
}
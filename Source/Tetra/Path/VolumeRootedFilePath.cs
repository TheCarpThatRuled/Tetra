namespace Tetra;
using static TetraMessages;

public class VolumeRootedFilePath : AbsoluteFilePath
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static VolumeRootedFilePath Create(string potentialPath)
      => ParseComponents(potentialPath,
                         PathType)
        .Reduce(failure => throw new ArgumentException(failure.Content()
                                                              .Content(),
                                                       nameof(potentialPath)),
                success => new VolumeRootedFilePath(success.Content()
                                                           .directories,
                                                    success.Content()
                                                           .file,
                                                    success.Content()
                                                           .volume));

   /* ------------------------------------------------------------ */

   public static VolumeRootedFilePath Create(Volume                                  volume,
                                             IReadOnlyCollection<DirectoryComponent> directories,
                                             FileComponent                           file)
      => new(directories,
             file,
             volume);

   /* ------------------------------------------------------------ */

   public static Result<VolumeRootedFilePath> Parse(string potentialPath)
      => ParseComponents(potentialPath,
                         PathType)
        .Map(success => new VolumeRootedFilePath(success.Content()
                                                        .directories,
                                                 success.Content()
                                                        .file,
                                                 success.Content()
                                                        .volume));

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public FileComponent File()
      => FileComponent
        .Create("C");

   /* ------------------------------------------------------------ */

   public VolumeRootedDirectoryPath Parent()
      => VolumeRootedDirectoryPath
        .Create("C:\\");

   /* ------------------------------------------------------------ */
   // Protected Constructors
   /* ------------------------------------------------------------ */

   protected VolumeRootedFilePath(IReadOnlyCollection<DirectoryComponent> directories,
                                  FileComponent                           file,
                                  Volume                                  volume)
      : base(PathBuilder.Combine(volume,
                                 directories,
                                 file))
   {
      _directories = directories;
      _file        = file;
      _volume      = volume;
   }

   /* ------------------------------------------------------------ */
   // Protected Methods
   /* ------------------------------------------------------------ */

   protected static Result<(Volume volume, IReadOnlyCollection<DirectoryComponent> directories, FileComponent file)> ParseComponents(string potentialPath,
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

      return (Volume.Create(potentialVolume[0]),
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
   private readonly Volume                                  _volume;

   /* ------------------------------------------------------------ */
}
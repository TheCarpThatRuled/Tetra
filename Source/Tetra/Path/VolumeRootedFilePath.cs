namespace Tetra;

public class VolumeRootedFilePath : AbsoluteFilePath
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static VolumeRootedFilePath Create(string potentialPath)
      => ParseComponents(potentialPath,
                         typeof(VolumeRootedFilePath))
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
                         typeof(VolumeRootedFilePath))
        .Map(success => new VolumeRootedFilePath(success.Content()
                                                        .directories,
                                                 success.Content()
                                                        .file,
                                                 success.Content()
                                                        .volume));

   /* ------------------------------------------------------------ */
   // Methods
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
      Type                                                                                                                                  callerType)
   {
      var components = potentialPath
                      .Split(Path.DirectorySeparatorChar,
                             Path.AltDirectorySeparatorChar)
                      .ToArray();

      var potentialVolume = components[0];

      if (potentialVolume.IsNotAValidVolumeLabel())
      {
         return Message.Create($"A {callerType.Name} must start with a volume label");
      }

      var potentialComponents = components
                               .Skip(1)
                               .Where(x => !string.IsNullOrEmpty(x))
                               .ToArray();

      if (potentialComponents.Any(x => x.IsNotAValidPathComponent()))
      {
         return Message.Create($"A {callerType.Name} may not contain a component with any of the following characters:");
      }

      if (string.IsNullOrEmpty(components[^1]))
      {
         return Message.Create($"A {callerType.Name} may not end with a directory separator");
      }

      return (Volume.Create(potentialVolume[0]),
              potentialComponents.SkipLast(1)
                                 .Select(DirectoryComponent.Create)
                                 .ToArray(),
              FileComponent.Create(components[^1]));
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IReadOnlyCollection<DirectoryComponent> _directories;
   private readonly FileComponent                           _file;
   private readonly Volume                                  _volume;

   /* ------------------------------------------------------------ */
}
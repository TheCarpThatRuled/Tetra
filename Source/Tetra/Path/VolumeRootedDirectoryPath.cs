namespace Tetra;

public class VolumeRootedDirectoryPath : AbsoluteDirectoryPath
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static VolumeRootedDirectoryPath Create(string potentialPath)
   {
      var components = potentialPath
                      .Split(Path.DirectorySeparatorChar,
                             Path.AltDirectorySeparatorChar)
                      .ToArray();

      var potentialVolume = components[0];

      if (string.IsNullOrEmpty(potentialVolume)
       || potentialVolume.Length != 2
       || potentialVolume[0].IsNotAnAsciiLetter()
       || potentialVolume[1] != ':')
      {
         throw new ArgumentException($"A {nameof(VolumeRootedDirectoryPath)} must start with a volume label",
                                     nameof(potentialPath));
      }

      var directoryComponents = components
                               .Skip(1)
                               .Where(x => !string.IsNullOrEmpty(x))
                               .ToArray();

      if (directoryComponents.Any(x => x.IsNotAValidPathComponent()))
      {
         throw new ArgumentException($"A {nameof(VolumeRootedDirectoryPath)} may not contain a component with any of the following characters:",
                                     nameof(potentialPath));
      }

      return Create(Volume.Create(potentialVolume[0]),
                    directoryComponents.Select(DirectoryComponent.Create)
                                       .ToArray());
   }

   /* ------------------------------------------------------------ */

   public static VolumeRootedDirectoryPath Create(Volume                                  volume,
                                                  IReadOnlyCollection<DirectoryComponent> directories)
      => new(directories,
             PathBuilder.Combine(volume,
                                 directories),
             volume);

   /* ------------------------------------------------------------ */

   public static Result<VolumeRootedDirectoryPath> Parse(string potentialPath)
   {
      return new VolumeRootedDirectoryPath(null,
                                           potentialPath,
                                           null);
   }

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
                                       string                                  value,
                                       Volume                                  volume)
      : base(value)
   {
      _directories = directories;
      _volume      = volume;
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IReadOnlyCollection<DirectoryComponent> _directories;
   private readonly Volume                                  _volume;

   /* ------------------------------------------------------------ */
}
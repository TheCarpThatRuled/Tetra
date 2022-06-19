using System.Text;

namespace Tetra;

public class VolumeRootedDirectoryPath : AbsoluteDirectoryPath
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static VolumeRootedDirectoryPath Create(string potentialPath)
   {
      return new(null,
                 null,
                 potentialPath);
   }

   /* ------------------------------------------------------------ */

   public static VolumeRootedDirectoryPath Create(Volume                                  volume,
                                                  IReadOnlyCollection<DirectoryComponent> directories)
   {
      var path = new StringBuilder();

      PathBuilder.Combine(path,
                          volume,
                          directories);

      return new(volume,
                 directories,
                 path.ToString());
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
   // Protected Constructors
   /* ------------------------------------------------------------ */

   protected VolumeRootedDirectoryPath(Volume                                  volume,
                                       IReadOnlyCollection<DirectoryComponent> directories,
                                       string                                  value)
      : base(value)
   {
      _volume      = volume;
      _directories = directories;
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Volume                                  _volume;
   private readonly IReadOnlyCollection<DirectoryComponent> _directories;

   /* ------------------------------------------------------------ */
}
using System.Text;

namespace Tetra;

public class VolumeRootedFilePath : AbsoluteFilePath
{
   /* ------------------------------------------------------------ */
   // Factory Methods
   /* ------------------------------------------------------------ */

   public static VolumeRootedFilePath Create(string potentialPath)
   {
      return new(null,
                 null,
                 null,
                 potentialPath);
   }

   /* ------------------------------------------------------------ */

   public static VolumeRootedFilePath Create(Volume                                  volume,
                                             IReadOnlyCollection<DirectoryComponent> directories,
                                             FileComponent                           file)
   {
      var path = new StringBuilder(volume.Value());
      path.Append(Path.DirectorySeparatorChar);

      foreach (var directory in directories)
      {
         path.Append(directory.Value());
         path.Append(Path.DirectorySeparatorChar);
      }

      path.Append(file.Value());

      return new(null,
                 null,
                 null,
                 path.ToString());
   }

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   /* ------------------------------------------------------------ */
   // Protected Constructors
   /* ------------------------------------------------------------ */

   protected VolumeRootedFilePath(Volume                                  volume,
                                  IReadOnlyCollection<DirectoryComponent> directories,
                                  FileComponent                           file,
                                  string                                  value)
      : base(value) { }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   /* ------------------------------------------------------------ */
}
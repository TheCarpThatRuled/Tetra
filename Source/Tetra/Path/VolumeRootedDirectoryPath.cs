using System.Text;

namespace Tetra;

public class VolumeRootedDirectoryPath : AbsoluteDirectoryPath
{
   /* ------------------------------------------------------------ */
   // Factory Methods
   /* ------------------------------------------------------------ */

   public static VolumeRootedDirectoryPath Create(Volume                                  volume,
                                                  IReadOnlyCollection<DirectoryComponent> directories)
   {
      var path = new StringBuilder(volume.Value());
      path.Append(Path.DirectorySeparatorChar);

      foreach (var directory in directories)
      {
         path.Append(directory.Value());
         path.Append(Path.DirectorySeparatorChar);
      }

      return new(null,
                 null,
                 path.ToString());
   }

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   /* ------------------------------------------------------------ */
   // Protected Constructors
   /* ------------------------------------------------------------ */

   protected VolumeRootedDirectoryPath(Volume                                  volume,
                                       IReadOnlyCollection<DirectoryComponent> directories,
                                       string                                  value)
      : base(value) { }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   /* ------------------------------------------------------------ */
}
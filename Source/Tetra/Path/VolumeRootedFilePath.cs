using System.Text;

namespace Tetra;

public class VolumeRootedFilePath : AbsoluteFilePath
{
   /* ------------------------------------------------------------ */
   // Factory Functions
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
      var path = new StringBuilder();

      PathBuilder.Combine(path,
                          volume,
                          directories,
                          file);

      return new(volume,
                 directories,
                 file,
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
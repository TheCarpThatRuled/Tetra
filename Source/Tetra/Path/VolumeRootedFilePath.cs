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
                 potentialPath,
                 null);
   }

   /* ------------------------------------------------------------ */

   public static VolumeRootedFilePath Create(Volume                                  volume,
                                             IReadOnlyCollection<DirectoryComponent> directories,
                                             FileComponent                           file)
      => new(null,
             null,
             PathBuilder.Combine(volume,
                                 directories,
                                 file),
             null);

   /* ------------------------------------------------------------ */

   public static Result<VolumeRootedFilePath> Parse(string potentialPath)
   {
      return new VolumeRootedFilePath(null,
                                      null,
                                      potentialPath,
                                      null);
   }

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
                                  string                                  value,
                                  Volume                                  volume)
      : base(value)
   {
      _directories = directories;
      _file        = file;
      _volume      = volume;
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IReadOnlyCollection<DirectoryComponent> _directories;
   private readonly FileComponent                           _file;
   private readonly Volume                                  _volume;

   /* ------------------------------------------------------------ */
}
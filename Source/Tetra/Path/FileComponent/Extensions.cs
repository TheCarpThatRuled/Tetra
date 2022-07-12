namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class FileComponent_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static RelativeFilePath Prepend(this   FileComponent        file,
                                          params DirectoryComponent[] directories)
      => null;

   /* ------------------------------------------------------------ */

   public static RelativeFilePath Prepend(this FileComponent              file,
                                          IEnumerable<DirectoryComponent> directories)
      => null;

   /* ------------------------------------------------------------ */

   public static RelativeDirectoryPath Prepend(this FileComponent    file,
                                               RelativeDirectoryPath path)
      => null;

   /* ------------------------------------------------------------ */

   public static AbsoluteFilePath Prepend(this FileComponent file,
                                          VolumeComponent    volume)
      => AbsoluteFilePath
        .Create(volume,
                Array.Empty<DirectoryComponent>(),
                file);

   /* ------------------------------------------------------------ */

   public static RelativeFilePath ToPath(this FileComponent file)
      => null;

   /* ------------------------------------------------------------ */
}
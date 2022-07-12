namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class FileComponent_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static AbsoluteFilePath Prepend(this FileComponent file,
                                          VolumeComponent    volume)
      => AbsoluteFilePath
        .Create(volume,
                Array.Empty<DirectoryComponent>(),
                file);

   /* ------------------------------------------------------------ */
}
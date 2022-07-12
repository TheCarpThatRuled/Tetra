namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class DirectoryComponent_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static AbsoluteDirectoryPath Prepend(this DirectoryComponent directory,
                                               VolumeComponent         volume)
      => AbsoluteDirectoryPath
        .Create(volume,
                new[] {directory});

   /* ------------------------------------------------------------ */
}
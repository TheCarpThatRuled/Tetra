namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class Volume_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static AbsoluteDirectoryPath Append(this   Volume               volume,
                                              params DirectoryComponent[] directories)
      => AbsoluteDirectoryPath
        .Create(volume,
                directories);

   /* ------------------------------------------------------------ */

   public static AbsoluteDirectoryPath Append(this Volume                             volume,
                                              IReadOnlyCollection<DirectoryComponent> directories)
      => AbsoluteDirectoryPath
        .Create(volume,
                directories);

   /* ------------------------------------------------------------ */

   public static VolumeRootedFilePath Append(this Volume   volume,
                                             FileComponent file)
      => VolumeRootedFilePath
        .Create(volume,
                Array.Empty<DirectoryComponent>(),
                file);

   /* ------------------------------------------------------------ */

   public static AbsoluteDirectoryPath ToDirectoryPath(this Volume volume)
      => AbsoluteDirectoryPath
        .Create(volume,
                Array.Empty<DirectoryComponent>());

   /* ------------------------------------------------------------ */
}
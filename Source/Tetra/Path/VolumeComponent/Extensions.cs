namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class Volume_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static AbsoluteDirectoryPath Append(this   VolumeComponent               volume,
                                              params DirectoryComponent[] directories)
      => AbsoluteDirectoryPath
        .Create(volume,
                directories);

   /* ------------------------------------------------------------ */

   public static AbsoluteDirectoryPath Append(this VolumeComponent                             volume,
                                              IReadOnlyCollection<DirectoryComponent> directories)
      => AbsoluteDirectoryPath
        .Create(volume,
                directories);

   /* ------------------------------------------------------------ */

   public static AbsoluteFilePath Append(this VolumeComponent   volume,
                                         FileComponent file)
      => AbsoluteFilePath
        .Create(volume,
                Array.Empty<DirectoryComponent>(),
                file);

   /* ------------------------------------------------------------ */

   public static AbsoluteDirectoryPath ToDirectoryPath(this VolumeComponent volume)
      => AbsoluteDirectoryPath
        .Create(volume,
                Array.Empty<DirectoryComponent>());

   /* ------------------------------------------------------------ */
}
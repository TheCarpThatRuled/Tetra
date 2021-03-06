namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class VolumeComponent_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static AbsoluteDirectoryPath Append(this   VolumeComponent      volume,
                                              params DirectoryComponent[] directories)
      => AbsoluteDirectoryPath
        .Create(volume,
                directories);

   /* ------------------------------------------------------------ */

   public static AbsoluteDirectoryPath Append(this VolumeComponent                    volume,
                                              IReadOnlyCollection<DirectoryComponent> directories)
      => AbsoluteDirectoryPath
        .Create(volume,
                directories);

   /* ------------------------------------------------------------ */

   public static AbsoluteDirectoryPath Append(this VolumeComponent  volume,
                                              RelativeDirectoryPath path)
      => AbsoluteDirectoryPath
        .Create(volume,
                path._directories);

   /* ------------------------------------------------------------ */

   public static AbsoluteFilePath Append(this VolumeComponent volume,
                                         FileComponent        file)
      => AbsoluteFilePath
        .Create(volume,
                Array.Empty<DirectoryComponent>(),
                file);

   /* ------------------------------------------------------------ */

   public static AbsoluteFilePath Append(this VolumeComponent volume,
                                         RelativeFilePath     path)
      => AbsoluteFilePath
        .Create(volume,
                path._directories,
                path._file);

   /* ------------------------------------------------------------ */

   public static AbsoluteDirectoryPath ToDirectoryPath(this VolumeComponent volume)
      => AbsoluteDirectoryPath
        .Create(volume,
                Array.Empty<DirectoryComponent>());

   /* ------------------------------------------------------------ */
}
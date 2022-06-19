﻿namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class Volume_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static VolumeRootedDirectoryPath Append(this   Volume               volume,
                                                  params DirectoryComponent[] directories)
      => VolumeRootedDirectoryPath
        .Create(volume,
                directories);

   /* ------------------------------------------------------------ */

   public static VolumeRootedDirectoryPath Append(this Volume                             volume,
                                                  IReadOnlyCollection<DirectoryComponent> directories)
      => VolumeRootedDirectoryPath
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

   public static VolumeRootedDirectoryPath ToDirectoryPath(this Volume volume)
      => VolumeRootedDirectoryPath
        .Create(volume,
                Array.Empty<DirectoryComponent>());

   /* ------------------------------------------------------------ */
}
﻿using static Tetra.TetraMessages;

namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class Volume_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static VolumeRootedDirectoryPath Append(this Volume                             volume,
                                                  IReadOnlyCollection<DirectoryComponent> directories)
      => VolumeRootedDirectoryPath
        .Create(volume,
                directories);

   /* ------------------------------------------------------------ */
}
namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class VolumeComponent_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static AbsoluteDirectoryPath Append(this   VolumeComponent      parent,
                                              params DirectoryComponent[] child)
      => AbsoluteDirectoryPath
        .Create(parent,
                child);

   /* ------------------------------------------------------------ */

   public static AbsoluteDirectoryPath Append(this VolumeComponent                    parent,
                                              IReadOnlyCollection<DirectoryComponent> child)
      => AbsoluteDirectoryPath
        .Create(parent,
                child);

   /* ------------------------------------------------------------ */

   public static AbsoluteDirectoryPath Append(this VolumeComponent  parent,
                                              RelativeDirectoryPath child)
      => child
        .Prepend(parent);

   /* ------------------------------------------------------------ */

   public static AbsoluteFilePath Append(this VolumeComponent parent,
                                         FileComponent        child)
      => AbsoluteFilePath
        .Create(parent,
                Array.Empty<DirectoryComponent>(),
                child);

   /* ------------------------------------------------------------ */

   public static AbsoluteFilePath Append(this VolumeComponent parent,
                                         RelativeFilePath     child)
      => child
        .Prepend(parent);

   /* ------------------------------------------------------------ */

   public static AbsoluteDirectoryPath ToPath(this VolumeComponent volume)
      => AbsoluteDirectoryPath
        .Create(volume,
                Array.Empty<DirectoryComponent>());

   /* ------------------------------------------------------------ */
}
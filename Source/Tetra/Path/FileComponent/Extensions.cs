namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class FileComponent_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static AbsoluteFilePath Prepend(this FileComponent    child,
                                          AbsoluteDirectoryPath parent)
      => parent
        .Append(child);

   /* ------------------------------------------------------------ */

   public static RelativeFilePath Prepend(this   FileComponent        child,
                                          params DirectoryComponent[] parent)
      => RelativeFilePath
        .Create(parent,
                child);

   /* ------------------------------------------------------------ */

   public static RelativeFilePath Prepend(this FileComponent              child,
                                          IEnumerable<DirectoryComponent> parent)
      => RelativeFilePath
        .Create(parent.ToArray(),
                child);

   /* ------------------------------------------------------------ */

   public static RelativeFilePath Prepend(this FileComponent    child,
                                          RelativeDirectoryPath parent)
      => parent
        .Append(child);

   /* ------------------------------------------------------------ */

   public static AbsoluteFilePath Prepend(this FileComponent child,
                                          VolumeComponent    parent)
      => AbsoluteFilePath
        .Create(parent,
                Array.Empty<DirectoryComponent>(),
                child);

   /* ------------------------------------------------------------ */

   public static RelativeFilePath ToPath(this FileComponent file)
      => RelativeFilePath
        .Create(Array.Empty<DirectoryComponent>(),
                file);

   /* ------------------------------------------------------------ */
}
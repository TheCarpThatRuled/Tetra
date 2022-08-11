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
        .Create(parent.Materialise(),
                child);

   /* ------------------------------------------------------------ */

   public static RelativeFilePath Prepend(this FileComponent              child,
                                          ISequence<DirectoryComponent> parent)
      => RelativeFilePath
        .Create(parent,
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
                Sequence<DirectoryComponent>.Empty(),
                child);

   /* ------------------------------------------------------------ */

   public static RelativeFilePath ToPath(this FileComponent file)
      => RelativeFilePath
        .Create(Sequence<DirectoryComponent>.Empty(),
                file);

   /* ------------------------------------------------------------ */
}
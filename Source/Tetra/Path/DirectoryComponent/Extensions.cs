namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class DirectoryComponent_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static RelativeDirectoryPath Append
   (
      this   DirectoryComponent   parent,
      params DirectoryComponent[] child
   )
      => RelativeDirectoryPath
        .Create(child
               .Prepend(parent)
               .ToArray());

   /* ------------------------------------------------------------ */

   public static RelativeDirectoryPath Append
   (
      this DirectoryComponent         parent,
      IEnumerable<DirectoryComponent> child
   )
      => RelativeDirectoryPath
        .Create(child
               .Prepend(parent)
               .ToArray());

   /* ------------------------------------------------------------ */

   public static RelativeDirectoryPath Append
   (
      this DirectoryComponent parent,
      RelativeDirectoryPath   child
   )
      => child
        .Prepend(parent);

   /* ------------------------------------------------------------ */

   public static RelativeFilePath Append
   (
      this DirectoryComponent parent,
      FileComponent           child
   )
      => RelativeFilePath
        .Create(Sequence.From(parent),
                child);

   /* ------------------------------------------------------------ */

   public static RelativeFilePath Append
   (
      this DirectoryComponent parent,
      RelativeFilePath        child
   )
      => child
        .Prepend(parent);

   /* ------------------------------------------------------------ */

   public static AbsoluteDirectoryPath Prepend
   (
      this DirectoryComponent child,
      AbsoluteDirectoryPath   parent
   )
      => parent
        .Append(child);

   /* ------------------------------------------------------------ */

   public static RelativeDirectoryPath Prepend
   (
      this   DirectoryComponent   child,
      params DirectoryComponent[] parent
   )
      => RelativeDirectoryPath
        .Create(parent
               .Append(child)
               .ToArray());

   /* ------------------------------------------------------------ */

   public static RelativeDirectoryPath Prepend
   (
      this DirectoryComponent         child,
      IEnumerable<DirectoryComponent> parent
   )
      => RelativeDirectoryPath
        .Create(parent
               .Append(child)
               .ToArray());

   /* ------------------------------------------------------------ */

   public static RelativeDirectoryPath Prepend
   (
      this DirectoryComponent child,
      RelativeDirectoryPath   parent
   )
      => parent
        .Append(child);

   /* ------------------------------------------------------------ */

   public static AbsoluteDirectoryPath Prepend
   (
      this DirectoryComponent child,
      VolumeComponent         parent
   )
      => AbsoluteDirectoryPath
        .Create(parent,
                Sequence.From(child));

   /* ------------------------------------------------------------ */

   public static RelativeDirectoryPath ToPath
   (
      this DirectoryComponent directory
   )
      => RelativeDirectoryPath
        .Create(directory);

   /* ------------------------------------------------------------ */
}
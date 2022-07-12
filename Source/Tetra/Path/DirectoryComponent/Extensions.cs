namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class DirectoryComponent_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static RelativeDirectoryPath Append(this DirectoryComponent directory,
                                              RelativeDirectoryPath   path)
      => null;

   /* ------------------------------------------------------------ */

   public static RelativeDirectoryPath Append(this   DirectoryComponent   directory,
                                              params DirectoryComponent[] directories)
      => null;

   /* ------------------------------------------------------------ */

   public static RelativeDirectoryPath Append(this DirectoryComponent         directory,
                                              IEnumerable<DirectoryComponent> directories)
      => null;

   /* ------------------------------------------------------------ */

   public static RelativeDirectoryPath Prepend(this   DirectoryComponent   directory,
                                               params DirectoryComponent[] directories)
      => null;

   /* ------------------------------------------------------------ */

   public static RelativeDirectoryPath Prepend(this DirectoryComponent         directory,
                                               IEnumerable<DirectoryComponent> directories)
      => null;

   /* ------------------------------------------------------------ */

   public static RelativeDirectoryPath Prepend(this DirectoryComponent directory,
                                               RelativeDirectoryPath   path)
      => null;

   /* ------------------------------------------------------------ */

   public static AbsoluteDirectoryPath Prepend(this DirectoryComponent directory,
                                               VolumeComponent         volume)
      => AbsoluteDirectoryPath
        .Create(volume,
                new[] {directory});

   /* ------------------------------------------------------------ */

   public static RelativeDirectoryPath ToPath(this DirectoryComponent directory)
      => null;

   /* ------------------------------------------------------------ */
}
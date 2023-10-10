namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class TestRelativeFilePath_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static TestRelativeDirectoryPath Parent
   (
      this TestRelativeFilePath path
   )
      => TestRelativeDirectoryPath
        .Create(path.Directories());

   /* ------------------------------------------------------------ */

   public static TestRelativeFilePath Prepend
   (
      this TestRelativeFilePath       child,
      IEnumerable<DirectoryComponent> parent
   )
      => TestRelativeFilePath
        .Create(parent.Concat(child.Directories())
                      .Materialise(),
                child.File());

   /* ------------------------------------------------------------ */

   public static TestAbsoluteFilePath Prepend
   (
      this TestRelativeFilePath child,
      TestAbsoluteDirectoryPath parent
   )
      => TestAbsoluteFilePath
        .Create(parent.Volume(),
                parent.Directories()
                      .Concat(child.Directories())
                      .Materialise(),
                child.File());

   /* ------------------------------------------------------------ */

   public static TestRelativeFilePath Prepend
   (
      this TestRelativeFilePath child,
      TestRelativeDirectoryPath parent
   )
      => TestRelativeFilePath
        .Create(parent.Directories()
                      .Concat(child.Directories())
                      .Materialise(),
                child.File());

   /* ------------------------------------------------------------ */

   public static TestAbsoluteFilePath Prepend
   (
      this TestRelativeFilePath child,
      VolumeComponent           parent
   )
      => TestAbsoluteFilePath
        .Create(parent,
                child.Directories(),
                child.File());

   /* ------------------------------------------------------------ */

   public static ISequence<TestRelativeDirectoryPath> ToAncestry
   (
      this TestRelativeFilePath path
   )
      => path
        .Parent()
        .ToAncestry();

   /* ------------------------------------------------------------ */

   public static RelativeFilePath ToTetra
   (
      this TestRelativeFilePath path
   )
      => RelativeFilePath
        .Create(path.Directories(),
                path.File());

   /* ------------------------------------------------------------ */
}
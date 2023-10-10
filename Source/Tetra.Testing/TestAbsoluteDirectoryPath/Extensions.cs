namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class TestAbsoluteDirectoryPath_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static TestAbsoluteDirectoryPath Append
   (
      this   TestAbsoluteDirectoryPath path,
      params DirectoryComponent[]      directories
   )
      => TestAbsoluteDirectoryPath
        .Create(path.Volume(),
                path.Directories()
                    .Concat(directories)
                    .Materialise());

   /* ------------------------------------------------------------ */

   public static TestAbsoluteDirectoryPath Append
   (
      this TestAbsoluteDirectoryPath  path,
      IEnumerable<DirectoryComponent> directories
   )
      => TestAbsoluteDirectoryPath
        .Create(path.Volume(),
                path.Directories()
                    .Concat(directories)
                    .Materialise());

   /* ------------------------------------------------------------ */

   public static TestAbsoluteDirectoryPath Append
   (
      this TestAbsoluteDirectoryPath parent,
      TestRelativeDirectoryPath      child
   )
      => TestAbsoluteDirectoryPath
        .Create(parent.Volume(),
                parent.Directories()
                      .Concat(child.Directories())
                      .Materialise());

   /* ------------------------------------------------------------ */

   public static TestAbsoluteFilePath Append
   (
      this TestAbsoluteDirectoryPath parent,
      TestRelativeFilePath           child
   )
      => parent
        .Append(child.Directories())
        .Append(child.File());

   /* ------------------------------------------------------------ */

   public static TestAbsoluteFilePath Append
   (
      this TestAbsoluteDirectoryPath path,
      FileComponent                  file
   )
      => TestAbsoluteFilePath
        .Create(path.Volume(),
                path.Directories(),
                file);

   /* ------------------------------------------------------------ */

   public static ISequence<TestAbsoluteDirectoryPath> ToAncestry
   (
      this TestAbsoluteDirectoryPath path
   )
   {
      var directoryChains = new List<IEnumerable<DirectoryComponent>> {Array.Empty<DirectoryComponent>(),};

      foreach (var directory in path.Directories())
      {
         directoryChains.Add(directoryChains[^1]
                               .Append(directory));
      }

      return directoryChains
            .Select(x => TestAbsoluteDirectoryPath.Create(path.Volume(),
                                                          x.ToArray()))
            .Materialise();
   }

   /* ------------------------------------------------------------ */

   public static AbsoluteDirectoryPath ToTetra
   (
      this TestAbsoluteDirectoryPath path
   )
      => AbsoluteDirectoryPath
        .Create(path.Volume(),
                path.Directories());

   /* ------------------------------------------------------------ */
}
namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class TestAbsoluteDirectoryPath_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static TestAbsoluteDirectoryPath Append(this TestAbsoluteDirectoryPath  path,
                                                  IEnumerable<DirectoryComponent> directories)
      => TestAbsoluteDirectoryPath
        .Create(path.Volume(),
                path.Directories()
                    .Concat(directories)
                    .ToArray());

   /* ------------------------------------------------------------ */

   public static IReadOnlyList<TestAbsoluteDirectoryPath> ToAncestry(this TestAbsoluteDirectoryPath path)
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
            .ToArray();
   }

   /* ------------------------------------------------------------ */

   public static AbsoluteDirectoryPath ToTetra(this TestAbsoluteDirectoryPath path)
      => AbsoluteDirectoryPath
        .Create(path.Volume(),
                path.Directories());

   /* ------------------------------------------------------------ */
}
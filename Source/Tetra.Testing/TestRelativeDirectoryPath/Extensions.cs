namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class TestRelativeDirectoryPath_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static TestRelativeDirectoryPath Append(this TestRelativeDirectoryPath  path,
                                                  IEnumerable<DirectoryComponent> directories)
      => TestRelativeDirectoryPath
        .Create(path.Directories()
                    .Concat(directories)
                    .ToArray());

   /* ------------------------------------------------------------ * /

   public static TestRelativeFilePath Append(this TestRelativeDirectoryPath path,
                                             FileComponent                  file)
      => TestRelativeFilePath
        .Create(path.Volume(),
                path.Directories(),
                file);

   /* ------------------------------------------------------------ */

   public static IReadOnlyList<TestRelativeDirectoryPath> ToAncestry(this TestRelativeDirectoryPath path)
   {
      var directoryChains = new List<IEnumerable<DirectoryComponent>> { Array.Empty<DirectoryComponent>(), };

      foreach (var directory in path.Directories())
      {
         directoryChains.Add(directoryChains[^1].Append(directory));
      }

      return directoryChains
            .Skip(1)
            .Select(x => TestRelativeDirectoryPath.Create(x.ToArray()))
            .ToArray();
   }

   /* ------------------------------------------------------------ */

   public static RelativeDirectoryPath ToTetra(this TestRelativeDirectoryPath path)
      => RelativeDirectoryPath
        .Create(path.Directories());

   /* ------------------------------------------------------------ */
}
namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class TestRelativeDirectoryPath_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static TestRelativeDirectoryPath Append(this TestRelativeDirectoryPath  parent,
                                                  IEnumerable<DirectoryComponent> child)
      => TestRelativeDirectoryPath
        .Create(parent
               .Directories()
               .Concat(child)
               .ToArray());

   /* ------------------------------------------------------------ */

   public static TestRelativeDirectoryPath Append(this TestRelativeDirectoryPath parent,
                                                  TestRelativeDirectoryPath      child)
      => TestRelativeDirectoryPath
        .Create(parent
               .Directories()
               .Concat(child.Directories())
               .ToArray());

   /* ------------------------------------------------------------ */

   public static TestRelativeFilePath Append(this TestRelativeDirectoryPath parent,
                                             FileComponent                  child)
      => TestRelativeFilePath
        .Create(parent.Directories(),
                child);

   /* ------------------------------------------------------------ */

   public static TestRelativeFilePath Append(this TestRelativeDirectoryPath parent,
                                             TestRelativeFilePath           child)
      => TestRelativeFilePath
        .Create(parent.Directories()
                      .Concat(child.Directories())
                      .ToArray(),
                child.File());

   /* ------------------------------------------------------------ */

   public static TestAbsoluteDirectoryPath Prepend(this TestRelativeDirectoryPath child,
                                                   TestAbsoluteDirectoryPath      parent)
      => TestAbsoluteDirectoryPath
        .Create(parent.Volume(),
                parent.Directories()
                      .Concat(child.Directories())
                      .ToArray());

   /* ------------------------------------------------------------ */

   public static TestRelativeDirectoryPath Prepend(this TestRelativeDirectoryPath child,
                                                   DirectoryComponent             parent)
      => TestRelativeDirectoryPath
        .Create(child
               .Directories()
               .Prepend(parent)
               .ToArray());

   /* ------------------------------------------------------------ */

   public static TestRelativeDirectoryPath Prepend(this TestRelativeDirectoryPath  child,
                                                   IEnumerable<DirectoryComponent> parent)
      => TestRelativeDirectoryPath
        .Create(parent
               .Concat(child.Directories())
               .ToArray());

   /* ------------------------------------------------------------ */

   public static TestRelativeDirectoryPath Prepend(this TestRelativeDirectoryPath child,
                                                   TestRelativeDirectoryPath      parent)
      => TestRelativeDirectoryPath
        .Create(parent
               .Directories()
               .Concat(child.Directories())
               .ToArray());

   /* ------------------------------------------------------------ */

   public static TestAbsoluteDirectoryPath Prepend(this TestRelativeDirectoryPath child,
                                                   VolumeComponent                parent)
      => TestAbsoluteDirectoryPath
        .Create(parent,
                child.Directories());

   /* ------------------------------------------------------------ */

   public static IReadOnlyList<TestRelativeDirectoryPath> ToAncestry(this TestRelativeDirectoryPath path)
   {
      var directoryChains = new List<IEnumerable<DirectoryComponent>> {Array.Empty<DirectoryComponent>(),};

      foreach (var directory in path.Directories())
      {
         directoryChains.Add(directoryChains[^1]
                               .Append(directory));
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
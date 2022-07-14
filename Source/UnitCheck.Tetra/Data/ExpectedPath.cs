using Tetra;

namespace Check;

internal static class ExpectedPath
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static IReadOnlyList<RelativeDirectoryPath> BuildAncestry(IEnumerable<DirectoryComponent> directories)
   {
      var directoryChains = new List<IEnumerable<DirectoryComponent>> {Array.Empty<DirectoryComponent>(),};

      foreach (var directory in directories)
      {
         directoryChains.Add(directoryChains[^1].Append(directory));
      }

      return directoryChains
            .Skip(1)
            .Select(x => RelativeDirectoryPath.Create(x.ToArray()))
            .ToArray();
   }

   /* ------------------------------------------------------------ */

   public static IReadOnlyList<AbsoluteDirectoryPath> BuildAncestry(VolumeComponent                 volume,
                                                                    IEnumerable<DirectoryComponent> directories)
   {
      var directoryChains = new List<IEnumerable<DirectoryComponent>> {Array.Empty<DirectoryComponent>(),};

      foreach (var directory in directories)
      {
         directoryChains.Add(directoryChains[^1].Append(directory));
      }

      return directoryChains
            .Select(x => AbsoluteDirectoryPath.Create(volume,
                                                      x.ToArray()))
            .ToArray();
   }

   /* ------------------------------------------------------------ */

   public static string Combine(IEnumerable<DirectoryComponent> directories)
      => directories
        .Select(directory => directory.Value())
        .ToArray()
        .ToDelimitedStringWithTrailingDelimiter(Path.DirectorySeparatorChar);

   /* ------------------------------------------------------------ */

   public static string Combine(IEnumerable<DirectoryComponent> directories,
                                FileComponent                   file)
      => Combine(directories)
       + file.Value();

   /* ------------------------------------------------------------ */

   public static string Combine(VolumeComponent                 volume,
                                IEnumerable<DirectoryComponent> directories)
      => directories
        .Select(directory => directory.Value())
        .Prepend(volume.Value())
        .ToArray()
        .ToDelimitedStringWithTrailingDelimiter(Path.DirectorySeparatorChar);

   /* ------------------------------------------------------------ */

   public static string Combine(VolumeComponent                 volume,
                                IEnumerable<DirectoryComponent> directories,
                                FileComponent                   file)
      => Combine(volume,
                 directories)
       + file.Value();

   /* ------------------------------------------------------------ */

   public static string CombineWithoutTrailingDirectorySeparator(IEnumerable<DirectoryComponent> directories)
      => directories
        .Select(directory => directory.Value())
        .ToArray()
        .ToDelimitedString(Path.DirectorySeparatorChar);

   /* ------------------------------------------------------------ */

   public static string CombineWithoutTrailingDirectorySeparator(VolumeComponent                 volume,
                                                                 IEnumerable<DirectoryComponent> directories)
      => directories
        .Select(directory => directory.Value())
        .Prepend(volume.Value())
        .ToArray()
        .ToDelimitedString(Path.DirectorySeparatorChar);

   /* ------------------------------------------------------------ */
}
using Tetra;

namespace Check;

internal static class ExpectedPath
{
   /* ------------------------------------------------------------ */
   // Functions
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

   public static string CombineWithoutTrailingDirectorySeparator(VolumeComponent                 volume,
                                                                 IEnumerable<DirectoryComponent> directories)
      => directories
        .Select(directory => directory.Value())
        .Prepend(volume.Value())
        .ToArray()
        .ToDelimitedString(Path.DirectorySeparatorChar);

   /* ------------------------------------------------------------ */
}
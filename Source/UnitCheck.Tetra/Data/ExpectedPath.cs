using Tetra;

namespace Check;

internal static class ExpectedPath
{
   /* ------------------------------------------------------------ */
   // Functions
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
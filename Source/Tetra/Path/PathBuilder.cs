using System.Text;

namespace Tetra;

internal static class PathBuilder
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static void Add(StringBuilder path,
                          FileComponent file)
      => path
        .Append(file.Value());

   /* ------------------------------------------------------------ */

   public static void Add(StringBuilder path,
                          Volume        volume)
   {
      path.Append(volume.Value());
      path.Append(Path.DirectorySeparatorChar);
   }

   /* ------------------------------------------------------------ */

   public static void Combine(StringBuilder                   path,
                              IEnumerable<DirectoryComponent> directories)
   {
      foreach (var directory in directories)
      {
         path.Append(directory.Value());
         path.Append(Path.DirectorySeparatorChar);
      }
   }

   /* ------------------------------------------------------------ */

   public static void Combine(StringBuilder                   path,
                              Volume                          volume,
                              IEnumerable<DirectoryComponent> directories)
   {
      Add(path,
          volume);

      Combine(path,
              directories);
   }

   /* ------------------------------------------------------------ */

   public static void Combine(StringBuilder                   path,
                              Volume                          volume,
                              IEnumerable<DirectoryComponent> directories,
                              FileComponent                   file)
   {
      Combine(path,
              volume,
              directories);

      Add(path,
          file);
   }

   /* ------------------------------------------------------------ */
}
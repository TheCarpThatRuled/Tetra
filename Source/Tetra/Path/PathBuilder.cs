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

   public static void Add(StringBuilder   path,
                          VolumeComponent volume)
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

   public static string Combine(IEnumerable<DirectoryComponent> directories)
   {
      var path = new StringBuilder();

      Combine(path,
              directories);

      return path.ToString();
   }

   /* ------------------------------------------------------------ */

   public static void Combine(StringBuilder                   path,
                              VolumeComponent                 volume,
                              IEnumerable<DirectoryComponent> directories)
   {
      Add(path,
          volume);

      Combine(path,
              directories);
   }

   /* ------------------------------------------------------------ */

   public static string Combine(VolumeComponent                 volume,
                                IEnumerable<DirectoryComponent> directories)
   {
      var path = new StringBuilder();

      Combine(path,
              volume,
              directories);

      return path.ToString();
   }

   /* ------------------------------------------------------------ */

   public static void Combine(StringBuilder                   path,
                              VolumeComponent                 volume,
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

   public static string Combine(VolumeComponent                 volume,
                                IEnumerable<DirectoryComponent> directories,
                                FileComponent                   file)
   {
      var path = new StringBuilder();

      Combine(path,
              volume,
              directories,
              file);

      return path.ToString();
   }

   /* ------------------------------------------------------------ */

   public static void Combine(StringBuilder                   path,
                              IEnumerable<DirectoryComponent> directories,
                              FileComponent                   file)
   {
      Combine(path,
              directories);

      Add(path,
          file);
   }

   /* ------------------------------------------------------------ */

   public static string Combine(IEnumerable<DirectoryComponent> directories,
                                FileComponent                   file)
   {
      var path = new StringBuilder();

      Combine(path,
              directories,
              file);

      return path.ToString();
   }

   /* ------------------------------------------------------------ */
}
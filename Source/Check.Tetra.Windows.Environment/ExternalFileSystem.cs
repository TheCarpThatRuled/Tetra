namespace Check;

internal static class ExternalFileSystem
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static void EnsureADirectoryDoesNotExists(string directory)
   {
      if (!Directory.Exists(directory))
      {
         return;
      }

      EnsureADirectoryIsEmpty(directory);

      Directory.Delete(directory);
   }

   /* ------------------------------------------------------------ */

   public static void EnsureADirectoryExists(string directory)
   {
      if (Directory.Exists(directory))
      {
         return;
      }

      var parent = Directory
                  .GetParent(directory)
                 ?.ToString();

      if (!string.IsNullOrEmpty(parent))
      {
         EnsureADirectoryExists(parent);
      }

      Directory.CreateDirectory(directory);
   }

   /* ------------------------------------------------------------ */

   public static void EnsureAnEmptyDirectoryExists(string directory)
   {
      EnsureADirectoryExists(directory);
      EnsureADirectoryIsEmpty(directory);
   }

   /* ------------------------------------------------------------ */

   public static void EnsureADirectoryIsEmpty(string directory)
   {
      if (!Directory.Exists(directory))
      {
         return;
      }

      foreach (var subDirectory in Directory.GetDirectories(directory))
      {
         EnsureADirectoryDoesNotExists(subDirectory);
      }

      foreach (var subFile in Directory.GetFiles(directory))
      {
         EnsureAFileDoesNotExists(subFile);
      }
   }

   /* ------------------------------------------------------------ */

   public static void EnsureAFileDoesNotExists(string file)
   {
      if (File.Exists(file))
      {
         File.Delete(file);
      }
   }

   /* ------------------------------------------------------------ */

   public static void EnsureAFileExists(string file)
   {
      // ReSharper disable once InvertIf
      if (!File.Exists(file))
      {
         // ReSharper disable once EmptyEmbeddedStatement
         using (File.Create(file));
      }
   }

   /* ------------------------------------------------------------ */

   public static string GetTheCurrentDirectory()
      => Directory
        .GetCurrentDirectory();

   /* ------------------------------------------------------------ */

   public static void SetCurrentDirectory(string directory)
      => Directory
        .SetCurrentDirectory(directory);

   /* ------------------------------------------------------------ */
}
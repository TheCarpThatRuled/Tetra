namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class AbsoluteFilePath_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static (IReadOnlyList<AbsoluteDirectoryPath> ancestors, AbsoluteFilePath file) Ancestry(this AbsoluteFilePath path)
      => (Array.Empty<AbsoluteDirectoryPath>(), path);

   /* ------------------------------------------------------------ */
}
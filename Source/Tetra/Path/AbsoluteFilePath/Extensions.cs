namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class AbsoluteFilePath_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static (IReadOnlyList<AbsoluteDirectoryPath> ancestors, AbsoluteFilePath leaf) Ancestry(this AbsoluteFilePath path)
      => (path.Parent()
              .Ancestry(),
          path);

   /* ------------------------------------------------------------ */
}
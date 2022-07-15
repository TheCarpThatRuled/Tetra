namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class RelativeFilePath_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static (IReadOnlyList<RelativeDirectoryPath> ancestors, RelativeFilePath file) Ancestry(this RelativeFilePath path)
      => (path.Parent()
              .Reduce(Array.Empty<RelativeDirectoryPath>(),
                      x => x.Ancestry()),
          path);

   /* ------------------------------------------------------------ */
}
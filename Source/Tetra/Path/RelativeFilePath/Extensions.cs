namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class RelativeFilePath_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static (ISequence<RelativeDirectoryPath> ancestors, RelativeFilePath file) Ancestry(this RelativeFilePath path)
      => (path.Parent()
              .Reduce(x => x.Ancestry(),
                      Sequence<RelativeDirectoryPath>.Empty),
          path);

   /* ------------------------------------------------------------ */
}
namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class RelativeDirectoryPath_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static IReadOnlyList<RelativeDirectoryPath> Ancestry(this RelativeDirectoryPath path)
   {
      var ancestry = new List<RelativeDirectoryPath> { path, };

      bool hadParent;
      do
      {
         hadParent = path
                    .Parent()
                    .Reduce(Function.False,
                            parent =>
                            {
                               ancestry.Add(parent);
                               path = parent;

                               return true;
                            });
      } while (hadParent);

      ancestry.Reverse();

      return ancestry;
   }

   /* ------------------------------------------------------------ */
}
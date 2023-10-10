namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class RelativeDirectoryPath_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static ISequence<RelativeDirectoryPath> Ancestry
   (
      this RelativeDirectoryPath path
   )
   {
      var ancestry = new List<RelativeDirectoryPath> {path,};

      bool hadParent;
      do
      {
         hadParent = path
                    .Parent()
                    .Unify(parent =>
                           {
                              ancestry.Add(parent);
                              path = parent;

                              return true;
                           },
                           Function.False);
      } while (hadParent);

      ancestry.Reverse();

      return ancestry.Materialise();
   }

   /* ------------------------------------------------------------ */
}
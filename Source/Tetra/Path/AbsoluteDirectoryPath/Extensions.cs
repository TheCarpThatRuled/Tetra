namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class AbsoluteDirectoryPath_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static ISequence<AbsoluteDirectoryPath> Ancestry(this AbsoluteDirectoryPath path)
   {
      var ancestry = new List<AbsoluteDirectoryPath> {path,};

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

      return ancestry.Materialise();
   }

   /* ------------------------------------------------------------ */
}
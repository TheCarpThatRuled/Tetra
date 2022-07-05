namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class VolumeRootedDirectoryPath_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static IReadOnlyList<VolumeRootedDirectoryPath> Ancestry(this VolumeRootedDirectoryPath path)
   {
      var  ancestry = new List<VolumeRootedDirectoryPath> {path,};

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
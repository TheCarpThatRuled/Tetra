using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<DirectoryComponent> DirectoryComponent()
      => ValidPathComponent()
        .Select(Tetra
               .DirectoryComponent
               .Create);

   /* ------------------------------------------------------------ */

   public static Gen<(DirectoryComponent, DirectoryComponent, DirectoryComponent)> ThreeUniqueDirectoryComponents()
      => DirectoryComponent()
        .ThreeValueTuples()
        .Where(tuple => !StringComparer.OrdinalIgnoreCase.Equals(tuple.first.Value(),
                                                                 tuple.second.Value())
                     && !StringComparer.OrdinalIgnoreCase.Equals(tuple.first.Value(),
                                                                 tuple.third.Value())
                     && !StringComparer.OrdinalIgnoreCase.Equals(tuple.second.Value(),
                                                                 tuple.third.Value()));

   /* ------------------------------------------------------------ */

   public static Gen<(DirectoryComponent, DirectoryComponent)> TwoUniqueDirectoryComponents()
      => DirectoryComponent()
        .TwoValueTuples()
        .Where(tuple => !StringComparer.OrdinalIgnoreCase.Equals(tuple.first.Value(),
                                                                 tuple.second.Value()));

   /* ------------------------------------------------------------ */
}
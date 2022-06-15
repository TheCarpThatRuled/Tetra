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
      => ValidPathComponent()
        .Three()
        .Where(tuple => !StringComparer.OrdinalIgnoreCase.Equals(tuple.Item1,
                                                                 tuple.Item2)
                     && !StringComparer.OrdinalIgnoreCase.Equals(tuple.Item1,
                                                                 tuple.Item3)
                     && !StringComparer.OrdinalIgnoreCase.Equals(tuple.Item2,
                                                                 tuple.Item3))
        .Select(tuple => (Tetra.DirectoryComponent.Create(tuple.Item1),
                          Tetra.DirectoryComponent.Create(tuple.Item2),
                          Tetra.DirectoryComponent.Create(tuple.Item3)));

   /* ------------------------------------------------------------ */

   public static Gen<(DirectoryComponent, DirectoryComponent)> TwoUniqueDirectoryComponents()
      => ValidPathComponent()
        .Two()
        .Where(tuple => !StringComparer.OrdinalIgnoreCase.Equals(tuple.Item1,
                                                                 tuple.Item2))
        .Select(tuple => (Tetra.DirectoryComponent.Create(tuple.Item1),
                          Tetra.DirectoryComponent.Create(tuple.Item2)));

   /* ------------------------------------------------------------ */
}
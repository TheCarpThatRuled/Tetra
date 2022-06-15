using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<FileComponent> FileComponent()
      => ValidPathComponent()
        .Select(Tetra
               .FileComponent
               .Create);

   /* ------------------------------------------------------------ */

   public static Gen<(FileComponent, FileComponent, FileComponent)> ThreeUniqueFileComponents()
      => ValidPathComponent()
        .Three()
        .Where(tuple => !StringComparer.OrdinalIgnoreCase.Equals(tuple.Item1,
                                                                 tuple.Item2)
                     && !StringComparer.OrdinalIgnoreCase.Equals(tuple.Item1,
                                                                 tuple.Item3)
                     && !StringComparer.OrdinalIgnoreCase.Equals(tuple.Item2,
                                                                 tuple.Item3))
        .Select(tuple => (Tetra.FileComponent.Create(tuple.Item1),
                          Tetra.FileComponent.Create(tuple.Item2),
                          Tetra.FileComponent.Create(tuple.Item3)));

   /* ------------------------------------------------------------ */

   public static Gen<(FileComponent, FileComponent)> TwoUniqueFileComponents()
      => ValidPathComponent()
        .Two()
        .Where(tuple => !StringComparer.OrdinalIgnoreCase.Equals(tuple.Item1,
                                                                 tuple.Item2))
        .Select(tuple => (Tetra.FileComponent.Create(tuple.Item1),
                          Tetra.FileComponent.Create(tuple.Item2)));

   /* ------------------------------------------------------------ */
}
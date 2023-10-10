using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<FileComponent> FileComponent()
      => ValidPathComponent()
        .Select(Tetra.FileComponent
                     .Create);

   /* ------------------------------------------------------------ */

   public static Gen<(FileComponent, FileComponent, FileComponent)> ThreeUniqueFileComponents()
      => FileComponent()
        .ThreeValueTuples()
        .Where(tuple => !StringComparer.OrdinalIgnoreCase.Equals(tuple.first.Value(),
                                                                 tuple.second.Value())
                     && !StringComparer.OrdinalIgnoreCase.Equals(tuple.first.Value(),
                                                                 tuple.third.Value())
                     && !StringComparer.OrdinalIgnoreCase.Equals(tuple.second.Value(),
                                                                 tuple.third.Value()));

   /* ------------------------------------------------------------ */

   public static Gen<(FileComponent, FileComponent)> TwoUniqueFileComponents()
      => FileComponent()
        .TwoValueTuples()
        .Where(tuple => !StringComparer.OrdinalIgnoreCase.Equals(tuple.first.Value(),
                                                                 tuple.second.Value()));

   /* ------------------------------------------------------------ */
}
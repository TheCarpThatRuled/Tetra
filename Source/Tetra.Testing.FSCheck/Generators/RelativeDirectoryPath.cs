using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<RelativeDirectoryPath> RelativeDirectoryPath()
      => ValidPathWithoutARootButWithATrailingDirectorySeparator()
        .Select(Tetra.RelativeDirectoryPath
                     .Create);

   /* ------------------------------------------------------------ */

   public static Gen<(RelativeDirectoryPath, RelativeDirectoryPath, RelativeDirectoryPath)> ThreeUniqueRelativeDirectoryPaths()
      => RelativeDirectoryPath()
        .ThreeValueTuples()
        .Where(tuple => !StringComparer.OrdinalIgnoreCase.Equals(tuple.first.Value(),
                                                                 tuple.second.Value())
                     && !StringComparer.OrdinalIgnoreCase.Equals(tuple.first.Value(),
                                                                 tuple.third.Value())
                     && !StringComparer.OrdinalIgnoreCase.Equals(tuple.second.Value(),
                                                                 tuple.third.Value()));

   /* ------------------------------------------------------------ */

   public static Gen<(RelativeDirectoryPath, RelativeDirectoryPath)> TwoIdenticalRelativeDirectoryPaths()
      => ValidPathWithoutARootButWithATrailingDirectorySeparator()
        .Select(path => (Tetra.RelativeDirectoryPath
                              .Create(path),
                         Tetra.RelativeDirectoryPath
                              .Create(path)));

   /* ------------------------------------------------------------ */

   public static Gen<(RelativeDirectoryPath, RelativeDirectoryPath)> TwoUniqueRelativeDirectoryPaths()
      => RelativeDirectoryPath()
        .TwoValueTuples()
        .Where(tuple => !StringComparer.OrdinalIgnoreCase.Equals(tuple.first.Value(),
                                                                 tuple.second.Value()));

   /* ------------------------------------------------------------ */
}
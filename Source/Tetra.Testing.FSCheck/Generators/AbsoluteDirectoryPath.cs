using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<AbsoluteDirectoryPath> AbsoluteDirectoryPath()
      => ValidPathWithVolumeRootAndTrailingDirectorySeparator()
        .Select(Tetra
               .AbsoluteDirectoryPath
               .Create);

   /* ------------------------------------------------------------ */

   public static Gen<(AbsoluteDirectoryPath, AbsoluteDirectoryPath, AbsoluteDirectoryPath)> ThreeUniqueAbsoluteDirectoryPaths()
      => AbsoluteDirectoryPath()
        .ThreeValueTuples()
        .Where(tuple => !StringComparer.OrdinalIgnoreCase.Equals(tuple.Item1.Value(),
                                                                 tuple.Item2.Value())
                     && !StringComparer.OrdinalIgnoreCase.Equals(tuple.Item1.Value(),
                                                                 tuple.Item3.Value())
                     && !StringComparer.OrdinalIgnoreCase.Equals(tuple.Item2.Value(),
                                                                 tuple.Item3.Value()));

   /* ------------------------------------------------------------ */

   public static Gen<(AbsoluteDirectoryPath, AbsoluteDirectoryPath)> TwoIdenticalAbsoluteDirectoryPaths()
      => ValidPathWithVolumeRootAndTrailingDirectorySeparator()
        .Select(path => (Tetra.AbsoluteDirectoryPath
                                       .Create(path),
                                  Tetra.AbsoluteDirectoryPath
                                       .Create(path)));

   /* ------------------------------------------------------------ */

   public static Gen<(AbsoluteDirectoryPath, AbsoluteDirectoryPath)> TwoUniqueAbsoluteDirectoryPaths()
      => AbsoluteDirectoryPath()
        .TwoValueTuples()
        .Where(tuple => !StringComparer.OrdinalIgnoreCase.Equals(tuple.Item1.Value(),
                                                                 tuple.Item2.Value()));

   /* ------------------------------------------------------------ */
}
namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<AbsoluteDirectoryPath> AbsoluteDirectoryPath()
      => ValidPathWithAVolumeRootAndATrailingDirectorySeparator()
        .Select(Tetra.AbsoluteDirectoryPath
                     .Create);

   /* ------------------------------------------------------------ */

   public static Gen<AbsoluteDirectoryPath> AbsoluteDirectoryPathWithAParent()
      => ValidPathWithAVolumeRootAndATrailingDirectorySeparator()
        .Select(Tetra.AbsoluteDirectoryPath
                     .Create);

   /* ------------------------------------------------------------ */

   public static Gen<(AbsoluteDirectoryPath, AbsoluteDirectoryPath, AbsoluteDirectoryPath)> ThreeUniqueAbsoluteDirectoryPaths()
      => AbsoluteDirectoryPath()
        .ThreeValueTuples()
        .Where(tuple => !StringComparer.OrdinalIgnoreCase.Equals(tuple.first.Value(),
                                                                 tuple.second.Value())
                     && !StringComparer.OrdinalIgnoreCase.Equals(tuple.first.Value(),
                                                                 tuple.third.Value())
                     && !StringComparer.OrdinalIgnoreCase.Equals(tuple.second.Value(),
                                                                 tuple.third.Value()));

   /* ------------------------------------------------------------ */

   public static Gen<(AbsoluteDirectoryPath, AbsoluteDirectoryPath)> TwoIdenticalAbsoluteDirectoryPaths()
      => ValidPathWithAVolumeRootAndATrailingDirectorySeparator()
        .Select(path => (Tetra.AbsoluteDirectoryPath
                              .Create(path),
                         Tetra.AbsoluteDirectoryPath
                              .Create(path)));

   /* ------------------------------------------------------------ */

   public static Gen<(AbsoluteDirectoryPath, AbsoluteDirectoryPath)> TwoUniqueAbsoluteDirectoryPaths()
      => AbsoluteDirectoryPath()
        .TwoValueTuples()
        .Where(tuple => !StringComparer.OrdinalIgnoreCase.Equals(tuple.first.Value(),
                                                                 tuple.second.Value()));

   /* ------------------------------------------------------------ */
}
using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<AbsoluteFilePath> AbsoluteFilePath()
      => ValidPathWithVolumeRootButWithoutTrailingDirectorySeparator()
        .Select(Tetra
               .AbsoluteFilePath
               .Create);

   /* ------------------------------------------------------------ */

   public static Gen<(AbsoluteFilePath, AbsoluteFilePath, AbsoluteFilePath)> ThreeUniqueAbsoluteFilePaths()
      => AbsoluteFilePath()
        .ThreeValueTuples()
        .Where(tuple => !StringComparer.OrdinalIgnoreCase.Equals(tuple.Item1.Value(),
                                                                 tuple.Item2.Value())
                     && !StringComparer.OrdinalIgnoreCase.Equals(tuple.Item1.Value(),
                                                                 tuple.Item3.Value())
                     && !StringComparer.OrdinalIgnoreCase.Equals(tuple.Item2.Value(),
                                                                 tuple.Item3.Value()));

   /* ------------------------------------------------------------ */

   public static Gen<(AbsoluteFilePath, AbsoluteFilePath)> TwoIdenticalAbsoluteFilePaths()
      => ValidPathWithVolumeRootButWithoutTrailingDirectorySeparator()
        .Select(path => (Tetra.AbsoluteFilePath
                                       .Create(path),
                                  Tetra.AbsoluteFilePath
                                       .Create(path)));

   /* ------------------------------------------------------------ */

   public static Gen<(AbsoluteFilePath, AbsoluteFilePath)> TwoUniqueAbsoluteFilePaths()
      => AbsoluteFilePath()
        .TwoValueTuples()
        .Where(tuple => !StringComparer.OrdinalIgnoreCase.Equals(tuple.Item1.Value(),
                                                                 tuple.Item2.Value()));

   /* ------------------------------------------------------------ */
}
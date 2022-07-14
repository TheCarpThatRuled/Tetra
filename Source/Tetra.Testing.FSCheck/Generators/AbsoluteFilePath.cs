using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<AbsoluteFilePath> AbsoluteFilePath()
      => ValidPathWithAVolumeRootButWithoutATrailingDirectorySeparator()
        .Select(Tetra
               .AbsoluteFilePath
               .Create);

   /* ------------------------------------------------------------ */

   public static Gen<(AbsoluteFilePath, AbsoluteFilePath, AbsoluteFilePath)> ThreeUniqueAbsoluteFilePaths()
      => AbsoluteFilePath()
        .ThreeValueTuples()
        .Where(tuple => !StringComparer.OrdinalIgnoreCase.Equals(tuple.first.Value(),
                                                                 tuple.second.Value())
                     && !StringComparer.OrdinalIgnoreCase.Equals(tuple.first.Value(),
                                                                 tuple.third.Value())
                     && !StringComparer.OrdinalIgnoreCase.Equals(tuple.second.Value(),
                                                                 tuple.third.Value()));

   /* ------------------------------------------------------------ */

   public static Gen<(AbsoluteFilePath, AbsoluteFilePath)> TwoIdenticalAbsoluteFilePaths()
      => ValidPathWithAVolumeRootButWithoutATrailingDirectorySeparator()
        .Select(path => (Tetra.AbsoluteFilePath
                                       .Create(path),
                                  Tetra.AbsoluteFilePath
                                       .Create(path)));

   /* ------------------------------------------------------------ */

   public static Gen<(AbsoluteFilePath, AbsoluteFilePath)> TwoUniqueAbsoluteFilePaths()
      => AbsoluteFilePath()
        .TwoValueTuples()
        .Where(tuple => !StringComparer.OrdinalIgnoreCase.Equals(tuple.first.Value(),
                                                                 tuple.second.Value()));

   /* ------------------------------------------------------------ */
}
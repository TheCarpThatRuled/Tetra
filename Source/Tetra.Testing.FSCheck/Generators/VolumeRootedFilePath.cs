using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<VolumeRootedFilePath> VolumeRootedFilePath()
      => ValidVolumeRootedPath()
        .Select(Tetra
               .VolumeRootedFilePath
               .Create);

   /* ------------------------------------------------------------ */

   public static Gen<(VolumeRootedFilePath, VolumeRootedFilePath, VolumeRootedFilePath)> ThreeUniqueVolumeRootedFilePaths()
      => VolumeRootedFilePath()
        .ThreeValueTuples()
        .Where(tuple => !StringComparer.OrdinalIgnoreCase.Equals(tuple.Item1.Value(),
                                                                 tuple.Item2.Value())
                     && !StringComparer.OrdinalIgnoreCase.Equals(tuple.Item1.Value(),
                                                                 tuple.Item3.Value())
                     && !StringComparer.OrdinalIgnoreCase.Equals(tuple.Item2.Value(),
                                                                 tuple.Item3.Value()));

   /* ------------------------------------------------------------ */

   public static Gen<(VolumeRootedFilePath, VolumeRootedFilePath)> TwoIdenticalVolumeRootedFilePaths()
      => ValidVolumeRootedPath()
        .Select(path => (Tetra.VolumeRootedFilePath
                                       .Create(path),
                                  Tetra.VolumeRootedFilePath
                                       .Create(path)));

   /* ------------------------------------------------------------ */

   public static Gen<(VolumeRootedFilePath, VolumeRootedFilePath)> TwoUniqueVolumeRootedFilePaths()
      => VolumeRootedFilePath()
        .TwoValueTuples()
        .Where(tuple => !StringComparer.OrdinalIgnoreCase.Equals(tuple.Item1.Value(),
                                                                 tuple.Item2.Value()));

   /* ------------------------------------------------------------ */
}
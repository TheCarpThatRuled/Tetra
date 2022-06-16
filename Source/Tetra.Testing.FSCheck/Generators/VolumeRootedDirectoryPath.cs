using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<VolumeRootedDirectoryPath> VolumeRootedDirectoryPath()
      => Volume()
        .Combine(ListOf(DirectoryComponent()),
                 Tetra.VolumeRootedDirectoryPath
                      .Create);

   /* ------------------------------------------------------------ */

   public static Gen<(VolumeRootedDirectoryPath, VolumeRootedDirectoryPath, VolumeRootedDirectoryPath)> ThreeUniqueVolumeRootedDirectoryPaths()
      => VolumeRootedDirectoryPath()
        .ThreeValueTuples()
        .Where(tuple => !StringComparer.OrdinalIgnoreCase.Equals(tuple.Item1.Value(),
                                                                 tuple.Item2.Value())
                     && !StringComparer.OrdinalIgnoreCase.Equals(tuple.Item1.Value(),
                                                                 tuple.Item3.Value())
                     && !StringComparer.OrdinalIgnoreCase.Equals(tuple.Item2.Value(),
                                                                 tuple.Item3.Value()));

   /* ------------------------------------------------------------ */

   public static Gen<(VolumeRootedDirectoryPath, VolumeRootedDirectoryPath)> TwoUniqueVolumeRootedDirectoryPaths()
      => VolumeRootedDirectoryPath()
        .TwoValueTuples()
        .Where(tuple => !StringComparer.OrdinalIgnoreCase.Equals(tuple.Item1.Value(),
                                                                 tuple.Item2.Value()));

   /* ------------------------------------------------------------ */
}
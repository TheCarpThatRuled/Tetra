using FsCheck;

namespace Tetra.Testing;

public static partial class Libraries
{
   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class VolumeRootedDirectoryPath
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<Tetra.VolumeRootedDirectoryPath> Type()
         => Generators
           .VolumeRootedDirectoryPath()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class ThreeUniqueVolumeRootedDirectoryPaths
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Tetra.VolumeRootedDirectoryPath, Tetra.VolumeRootedDirectoryPath, Tetra.VolumeRootedDirectoryPath)> Type()
         => Generators
           .ThreeUniqueVolumeRootedDirectoryPaths()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TransitiveVolumeRootedDirectoryPaths
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Tetra.VolumeRootedDirectoryPath, Tetra.VolumeRootedDirectoryPath, Tetra.VolumeRootedDirectoryPath)> Type()
         => Generators
           .Transitive(Generators.TwoUniqueVolumeRootedDirectoryPaths())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TwoIdenticalVolumeRootedDirectoryPaths
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Tetra.VolumeRootedDirectoryPath, Tetra.VolumeRootedDirectoryPath)> Type()
         => Generators
           .TwoIdenticalVolumeRootedDirectoryPaths()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TwoUniqueVolumeRootedDirectoryPaths
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Tetra.VolumeRootedDirectoryPath, Tetra.VolumeRootedDirectoryPath)> Type()
         => Generators
           .TwoUniqueVolumeRootedDirectoryPaths()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}
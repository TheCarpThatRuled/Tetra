using FsCheck;

namespace Tetra.Testing;

public static partial class Libraries
{
   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class VolumeRootedFilePath
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<Tetra.VolumeRootedFilePath> Type()
         => Generators
           .VolumeRootedFilePath()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class ThreeUniqueVolumeRootedFilePaths
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Tetra.VolumeRootedFilePath, Tetra.VolumeRootedFilePath, Tetra.VolumeRootedFilePath)> Type()
         => Generators
           .ThreeUniqueVolumeRootedFilePaths()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TransitiveVolumeRootedFilePaths
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Tetra.VolumeRootedFilePath, Tetra.VolumeRootedFilePath, Tetra.VolumeRootedFilePath)> Type()
         => Generators
           .Transitive(Generators.TwoUniqueVolumeRootedFilePaths())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TwoIdenticalVolumeRootedFilePaths
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Tetra.VolumeRootedFilePath, Tetra.VolumeRootedFilePath)> Type()
         => Generators
           .TwoIdenticalVolumeRootedFilePaths()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TwoUniqueVolumeRootedFilePaths
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Tetra.VolumeRootedFilePath, Tetra.VolumeRootedFilePath)> Type()
         => Generators
           .TwoUniqueVolumeRootedFilePaths()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}
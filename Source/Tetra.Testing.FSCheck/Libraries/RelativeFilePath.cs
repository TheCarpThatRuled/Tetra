using FsCheck;

namespace Tetra.Testing;

public static partial class Libraries
{
   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class RelativeFilePath
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<Tetra.RelativeFilePath> Type()
         => Generators
           .RelativeFilePath()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class RelativeFilePathAsComponents
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Tetra.DirectoryComponent[], Tetra.FileComponent)> Type()
         => Generators
           .ArrayOf(Generators.DirectoryComponent())
           .ZipValueTuples(Generators.FileComponent())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class ThreeUniqueRelativeFilePaths
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Tetra.RelativeFilePath, Tetra.RelativeFilePath, Tetra.RelativeFilePath)> Type()
         => Generators
           .ThreeUniqueRelativeFilePaths()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TransitiveRelativeFilePaths
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Tetra.RelativeFilePath, Tetra.RelativeFilePath, Tetra.RelativeFilePath)> Type()
         => Generators
           .Transitive(Generators.TwoUniqueRelativeFilePaths())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TwoIdenticalRelativeFilePaths
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Tetra.RelativeFilePath, Tetra.RelativeFilePath)> Type()
         => Generators
           .TwoIdenticalRelativeFilePaths()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TwoUniqueRelativeFilePaths
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Tetra.RelativeFilePath, Tetra.RelativeFilePath)> Type()
         => Generators
           .TwoUniqueRelativeFilePaths()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}
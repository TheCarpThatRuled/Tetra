namespace Tetra.Testing;

public static partial class Libraries
{
   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class RelativeDirectoryPath
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<Tetra.RelativeDirectoryPath> Type()
         => Generators
           .RelativeDirectoryPath()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class ThreeUniqueRelativeDirectoryPaths
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Tetra.RelativeDirectoryPath, Tetra.RelativeDirectoryPath, Tetra.RelativeDirectoryPath)> Type()
         => Generators
           .ThreeUniqueRelativeDirectoryPaths()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TransitiveRelativeDirectoryPaths
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Tetra.RelativeDirectoryPath, Tetra.RelativeDirectoryPath, Tetra.RelativeDirectoryPath)> Type()
         => Generators
           .Transitive(Generators.TwoUniqueRelativeDirectoryPaths())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TwoIdenticalRelativeDirectoryPaths
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Tetra.RelativeDirectoryPath, Tetra.RelativeDirectoryPath)> Type()
         => Generators
           .TwoIdenticalRelativeDirectoryPaths()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TwoUniqueRelativeDirectoryPaths
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Tetra.RelativeDirectoryPath, Tetra.RelativeDirectoryPath)> Type()
         => Generators
           .TwoUniqueRelativeDirectoryPaths()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}
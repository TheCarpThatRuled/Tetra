namespace Tetra.Testing;

public static partial class Libraries
{
   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class AbsoluteDirectoryPath
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<Tetra.AbsoluteDirectoryPath> Type()
         => Generators
           .AbsoluteDirectoryPath()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class ThreeUniqueAbsoluteDirectoryPaths
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Tetra.AbsoluteDirectoryPath, Tetra.AbsoluteDirectoryPath, Tetra.AbsoluteDirectoryPath)> Type()
         => Generators
           .ThreeUniqueAbsoluteDirectoryPaths()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TransitiveAbsoluteDirectoryPaths
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Tetra.AbsoluteDirectoryPath, Tetra.AbsoluteDirectoryPath, Tetra.AbsoluteDirectoryPath)> Type()
         => Generators
           .Transitive(Generators.TwoUniqueAbsoluteDirectoryPaths())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TwoIdenticalAbsoluteDirectoryPaths
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Tetra.AbsoluteDirectoryPath, Tetra.AbsoluteDirectoryPath)> Type()
         => Generators
           .TwoIdenticalAbsoluteDirectoryPaths()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TwoUniqueAbsoluteDirectoryPaths
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Tetra.AbsoluteDirectoryPath, Tetra.AbsoluteDirectoryPath)> Type()
         => Generators
           .TwoUniqueAbsoluteDirectoryPaths()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}
using FsCheck;

namespace Tetra.Testing;

public static partial class Libraries
{
   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class ArrayOfDirectoryComponents
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<Tetra.DirectoryComponent[]> Type()
         => Generators
           .ArrayOf(Generators.DirectoryComponent())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }
   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class ArrayOfAtLeastTwoDirectoryComponents
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<Tetra.DirectoryComponent[]> Type()
         => Generators
           .ArrayOf(Generators.DirectoryComponent())
           .Where(x=> x.Length > 1)
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class NonEmptyArrayOfDirectoryComponents
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<Tetra.DirectoryComponent[]> Type()
         => Generators
           .NonEmptyArrayOf(Generators.DirectoryComponent())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class DirectoryComponent
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<Tetra.DirectoryComponent> Type()
         => Generators
           .DirectoryComponent()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class ListOfDirectoryComponents
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<List<Tetra.DirectoryComponent>> Type()
         => Generators
           .ListOf(Generators.DirectoryComponent())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class ThreeUniqueDirectoryComponents
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Tetra.DirectoryComponent, Tetra.DirectoryComponent, Tetra.DirectoryComponent)> Type()
         => Generators
           .ThreeUniqueDirectoryComponents()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TransitiveDirectoryComponents
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Tetra.DirectoryComponent, Tetra.DirectoryComponent, Tetra.DirectoryComponent)> Type()
         => Generators
           .Transitive(Generators.TwoUniqueDirectoryComponents())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TwoListsOfDirectoryComponents
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(List<Tetra.DirectoryComponent>, List<Tetra.DirectoryComponent>)> Type()
         => Generators
           .ListOf(Generators.DirectoryComponent())
           .TwoValueTuples()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TwoUniqueDirectoryComponents
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Tetra.DirectoryComponent, Tetra.DirectoryComponent)> Type()
         => Generators
           .TwoUniqueDirectoryComponents()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}
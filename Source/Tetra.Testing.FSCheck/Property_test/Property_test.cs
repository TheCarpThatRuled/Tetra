namespace Tetra.Testing;
// ReSharper disable once InconsistentNaming

public static class Property_test<T>
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static RunTest Register
   (
      Arbitrary<T> arbitrary
   )
   {
      Library.Arbitrary = arbitrary;
      Arb.Register<Library>();

      return new();
   }

   /* ------------------------------------------------------------ */
   // Classes
   /* ------------------------------------------------------------ */

   public sealed class RunTest
   {
      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal RunTest() { }

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public void Run
      (
         Func<T, Property> test
      )
         => Prop
           .ForAll(test)
           .QuickCheckThrowOnFailure();

      /* ------------------------------------------------------------ */
   }

   private sealed class Library
   {
      /* ------------------------------------------------------------ */
      // Static Fields
      /* ------------------------------------------------------------ */

      public static Arbitrary<T> Arbitrary = null!;

      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<T> Type()
         => Arbitrary;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}
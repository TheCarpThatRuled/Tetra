using FsCheck;

namespace Tetra.Testing;
// ReSharper disable once InconsistentNaming

public static class Property_test<T>
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static RunTest Register
   (
      Type library
   )
   {
      Arb.Register(library);

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

   /* ------------------------------------------------------------ */
}
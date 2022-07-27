using FsCheck;

namespace Tetra.Testing;

public static partial class Libraries
{
   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TestRelativeFilePath
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<Testing.TestRelativeFilePath> Type()
         => Generators
           .TestRelativeFilePath()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}
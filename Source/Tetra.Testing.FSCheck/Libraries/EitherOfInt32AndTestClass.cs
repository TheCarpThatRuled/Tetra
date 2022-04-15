using FsCheck;

namespace Tetra.Testing;

public static partial class Libraries
{
   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class LeftEitherOfInt32AndTestClass
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<Either<int, Testing.TestClass>> Type()
         => Generators
           .LeftEither<int, Testing.TestClass>(Generators.Int32())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class EitherOfInt32AndTestClass
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<Either<int, Testing.TestClass>> Type()
         => Generators
           .Either(Generators.Int32(),
                   Generators.TestClass())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class RightEitherOfInt32AndTestClass
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<Either<int, Testing.TestClass>> Type()
         => Generators
           .RightEither<int, Testing.TestClass>(Generators.TestClass())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TransitiveEithersOfInt32AndTestClass
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Either<int, Testing.TestClass>, Either<int, Testing.TestClass>, Either<int, Testing.TestClass>)> Type()
         => Generators
           .Transitive(Generators.TwoUniqueEithers(Generators.Int32(),
                                                   Generators.TestClass()))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}
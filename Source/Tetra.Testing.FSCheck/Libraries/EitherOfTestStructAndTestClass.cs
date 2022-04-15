using FsCheck;

namespace Tetra.Testing;

public static partial class Libraries
{
   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class LeftEitherOfTestStructAndTestClass
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<Either<Testing.TestStruct, Testing.TestClass>> Type()
         => Generators
           .LeftEither<Testing.TestStruct, Testing.TestClass>(Generators.TestStruct())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class EitherOfTestStructAndTestClass
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<Either<Testing.TestStruct, Testing.TestClass>> Type()
         => Generators
           .Either(Generators.TestStruct(),
                   Generators.TestClass())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class RightEitherOfTestStructAndTestClass
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<Either<Testing.TestStruct, Testing.TestClass>> Type()
         => Generators
           .RightEither<Testing.TestStruct, Testing.TestClass>(Generators.TestClass())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TransitiveEithersOfTestStructAndTestClass
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Either<Testing.TestStruct, Testing.TestClass>, Either<Testing.TestStruct, Testing.TestClass>, Either<Testing.TestStruct, Testing.TestClass>)> Type()
         => Generators
           .Transitive(Generators.TwoUniqueEithers(Generators.TestStruct(),
                                                   Generators.TestClass()))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}
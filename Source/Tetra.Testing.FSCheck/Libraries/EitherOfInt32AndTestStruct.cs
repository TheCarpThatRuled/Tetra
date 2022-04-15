using FsCheck;

namespace Tetra.Testing;

public static partial class Libraries
{
   /* ------------------------------------------------------------ */

   // ReSharper disable once StructNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class LeftEitherOfInt32AndTestStruct
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<Either<int, Testing.TestStruct>> Type()
         => Generators
           .LeftEither<int, Testing.TestStruct>(Generators.Int32())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once StructNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class EitherOfInt32AndTestStruct
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<Either<int, Testing.TestStruct>> Type()
         => Generators
           .Either(Generators.Int32(),
                   Generators.TestStruct())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once StructNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class RightEitherOfInt32AndTestStruct
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<Either<int, Testing.TestStruct>> Type()
         => Generators
           .RightEither<int, Testing.TestStruct>(Generators.TestStruct())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once StructNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TransitiveEithersOfInt32AndTestStruct
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Either<int, Testing.TestStruct>, Either<int, Testing.TestStruct>, Either<int, Testing.TestStruct>)> Type()
         => Generators
           .Transitive(Generators.TwoUniqueEithers(Generators.Int32(),
                                                   Generators.TestStruct()))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}
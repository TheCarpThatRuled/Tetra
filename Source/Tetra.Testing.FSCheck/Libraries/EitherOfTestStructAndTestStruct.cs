using FsCheck;

namespace Tetra.Testing;

public static partial class Libraries
{
   /* ------------------------------------------------------------ */

   // ReSharper disable once StructNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class LeftEitherOfTestStructAndTestStruct
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<Either<Testing.TestStruct, Testing.TestStruct>> Type()
         => Generators
           .LeftEither<Testing.TestStruct, Testing.TestStruct>(Generators.TestStruct())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once StructNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class EitherOfTestStructAndTestStruct
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<Either<Testing.TestStruct, Testing.TestStruct>> Type()
         => Generators
           .Either(Generators.TestStruct(),
                   Generators.TestStruct())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once StructNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class RightEitherOfTestStructAndTestStruct
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<Either<Testing.TestStruct, Testing.TestStruct>> Type()
         => Generators
           .RightEither<Testing.TestStruct, Testing.TestStruct>(Generators.TestStruct())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once StructNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TransitiveEithersOfTestStructAndTestStruct
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Either<Testing.TestStruct, Testing.TestStruct>, Either<Testing.TestStruct, Testing.TestStruct>, Either<Testing.TestStruct, Testing.TestStruct>)> Type()
         => Generators
           .Transitive(Generators.TwoUniqueEithers(Generators.TestStruct(),
                                                   Generators.TestStruct()))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}
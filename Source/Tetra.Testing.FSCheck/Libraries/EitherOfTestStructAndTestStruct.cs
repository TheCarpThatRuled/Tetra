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
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<IEither<Testing.TestStruct, Testing.TestStruct>> Type()
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
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<IEither<Testing.TestStruct, Testing.TestStruct>> Type()
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
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<IEither<Testing.TestStruct, Testing.TestStruct>> Type()
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
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(IEither<Testing.TestStruct, Testing.TestStruct>, IEither<Testing.TestStruct, Testing.TestStruct>, IEither<Testing.TestStruct, Testing.TestStruct>)>
         Type()
         => Generators
           .Transitive(Generators.TwoUniqueEithers(Generators.TestStruct(),
                                                   Generators.TestStruct()))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}
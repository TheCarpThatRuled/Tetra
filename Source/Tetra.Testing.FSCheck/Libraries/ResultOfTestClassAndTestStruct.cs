using FsCheck;

namespace Tetra.Testing;

public static partial class Libraries
{
   /* ------------------------------------------------------------ */

   // ReSharper disable once StructNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class FailureResultOfTestClassAndTestStruct
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<IResult<Testing.TestClass, Testing.TestStruct>> Type()
         => Generators
           .FailureResult<Testing.TestClass, Testing.TestStruct>(Generators.TestStruct())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once StructNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class ResultOfTestClassAndTestStruct
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<IResult<Testing.TestClass, Testing.TestStruct>> Type()
         => Generators
           .Result(Generators.TestClass(),
                   Generators.TestStruct())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once StructNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class SuccessResultOfTestClassAndTestStruct
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<IResult<Testing.TestClass, Testing.TestStruct>> Type()
         => Generators
           .SuccessResult<Testing.TestClass, Testing.TestStruct>(Generators.TestClass())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once StructNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TransitiveResultsOfTestClassAndTestStruct
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(IResult<Testing.TestClass, Testing.TestStruct>, IResult<Testing.TestClass, Testing.TestStruct>, IResult<Testing.TestClass, Testing.TestStruct>)> Type()
         => Generators
           .Transitive(Generators.TwoUniqueResults(Generators.TestClass(),
                                                   Generators.TestStruct()))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}
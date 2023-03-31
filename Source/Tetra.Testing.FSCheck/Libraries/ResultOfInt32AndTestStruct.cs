using FsCheck;

namespace Tetra.Testing;

public static partial class Libraries
{
   /* ------------------------------------------------------------ */

   // ReSharper disable once StructNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class FailureResultOfInt32AndTestStruct
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<IResult<int, Testing.TestStruct>> Type()
         => Generators
           .FailureResult<int, Testing.TestStruct>(Generators.TestStruct())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once StructNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class ResultOfInt32AndTestStruct
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<IResult<int, Testing.TestStruct>> Type()
         => Generators
           .Result(Generators.Int32(),
                   Generators.TestStruct())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once StructNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class SuccessResultOfInt32AndTestStruct
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<IResult<int, Testing.TestStruct>> Type()
         => Generators
           .SuccessResult<int, Testing.TestStruct>(Generators.Int32())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once StructNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TransitiveResultsOfInt32AndTestStruct
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(IResult<int, Testing.TestStruct>, IResult<int, Testing.TestStruct>, IResult<int, Testing.TestStruct>)> Type()
         => Generators
           .Transitive(Generators.TwoUniqueResults(Generators.Int32(),
                                                   Generators.TestStruct()))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}
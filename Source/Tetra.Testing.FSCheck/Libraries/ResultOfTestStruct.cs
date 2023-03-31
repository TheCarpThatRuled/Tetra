using FsCheck;

namespace Tetra.Testing;

public static partial class Libraries
{
   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class ResultOfTestStruct
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<IResult<Testing.TestStruct>> Type()
         => Generators
           .Result(Generators.TestStruct())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class FailureResultOfTestStruct
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<IResult<Testing.TestStruct>> Type()
         => Generators
           .FailureResult(Generators.TestStruct())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TransitiveResultsOfTestStruct
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(IResult<Testing.TestStruct>, IResult<Testing.TestStruct>, IResult<Testing.TestStruct>)> Type()
         => Generators
           .Transitive(Generators.TwoUniqueResults(Generators.TestStruct()))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}
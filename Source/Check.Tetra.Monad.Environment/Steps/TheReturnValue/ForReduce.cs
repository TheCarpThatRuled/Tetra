using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheReturnValue
   {
      public sealed class ForReduce
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<ReduceWasCalled.Asserts, ReduceWasCalled.Asserts> is_equal_to(FakeNewType expected)
            => the_return_value.is_equal_to<FakeNewType, ReduceWasCalled.Asserts>(expected);

         /* ------------------------------------------------------------ */
      }
   }
}
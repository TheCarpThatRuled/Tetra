using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheReturnValue
   {
      public sealed class ForReduceWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<ReduceWasCalledWithExternalState.Asserts, ReduceWasCalledWithExternalState.Asserts> is_equal_to(FakeNewType expected)
            => the_return_value.is_equal_to<FakeNewType, ReduceWasCalledWithExternalState.Asserts>(expected);

         /* ------------------------------------------------------------ */
      }
   }
}
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheReturnValue
   {
      public sealed class ForExpandSomeToRightWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<ExpandSomeToRightWasCalledWithExternalState.Asserts, ExpandSomeToRightWasCalledWithExternalState.Asserts> is_a_left_containing(FakeLeft expected)
            => the_return_value.is_a_left_containing<FakeLeft, FakeType, ExpandSomeToRightWasCalledWithExternalState.Asserts>(expected);

         /* ------------------------------------------------------------ */

         public IAssert<ExpandSomeToRightWasCalledWithExternalState.Asserts, ExpandSomeToRightWasCalledWithExternalState.Asserts> is_a_right_containing(FakeType expected)
            => the_return_value.is_a_right_containing<FakeLeft, FakeType, ExpandSomeToRightWasCalledWithExternalState.Asserts>(expected);

         /* ------------------------------------------------------------ */
      }
   }
}
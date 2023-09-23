using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheReturnValue
   {
      public sealed class ForExpandSomeToLeftWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<ExpandSomeToLeftWasCalledWithExternalState.Asserts, ExpandSomeToLeftWasCalledWithExternalState.Asserts> is_a_left_containing(FakeType expected)
            => the_return_value.is_a_left_containing<FakeType, FakeRight, ExpandSomeToLeftWasCalledWithExternalState.Asserts>(expected);

         /* ------------------------------------------------------------ */

         public IAssert<ExpandSomeToLeftWasCalledWithExternalState.Asserts, ExpandSomeToLeftWasCalledWithExternalState.Asserts> is_a_right_containing(FakeRight expected)
            => the_return_value.is_a_right_containing<FakeType, FakeRight, ExpandSomeToLeftWasCalledWithExternalState.Asserts>(expected);

         /* ------------------------------------------------------------ */
      }
   }
}
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenNone
   {
      public sealed class ForExpandSomeToRightWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<ExpandSomeToRightWasCalledWithExternalState.Asserts, ExpandSomeToRightWasCalledWithExternalState.Asserts> was_invoked_once_with(FakeExternalState externalState)
            => the_whenNone.function.was_invoked_once_with<FakeExternalState, FakeLeft, ExpandSomeToRightWasCalledWithExternalState.Asserts>(externalState);

         /* ------------------------------------------------------------ */

         public IAssert<ExpandSomeToRightWasCalledWithExternalState.Asserts, ExpandSomeToRightWasCalledWithExternalState.Asserts> was_not_invoked()
            => the_whenNone.function.was_not_invoked<FakeExternalState, FakeLeft, ExpandSomeToRightWasCalledWithExternalState.Asserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
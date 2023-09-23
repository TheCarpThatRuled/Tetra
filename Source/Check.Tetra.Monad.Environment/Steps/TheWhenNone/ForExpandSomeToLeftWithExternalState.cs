using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenNone
   {
      public sealed class ForExpandSomeToLeftWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<ExpandSomeToLeftWasCalledWithExternalState.Asserts, ExpandSomeToLeftWasCalledWithExternalState.Asserts> was_invoked_once_with(FakeExternalState externalState)
            => the_whenNone.function.was_invoked_once_with<FakeExternalState, FakeRight, ExpandSomeToLeftWasCalledWithExternalState.Asserts>(externalState);

         /* ------------------------------------------------------------ */

         public IAssert<ExpandSomeToLeftWasCalledWithExternalState.Asserts, ExpandSomeToLeftWasCalledWithExternalState.Asserts> was_not_invoked()
            => the_whenNone.function.was_not_invoked<FakeExternalState, FakeRight, ExpandSomeToLeftWasCalledWithExternalState.Asserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
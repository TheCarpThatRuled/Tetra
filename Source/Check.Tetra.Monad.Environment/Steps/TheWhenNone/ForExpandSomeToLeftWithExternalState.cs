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

         public IAssert<TheOptionHasBeenCreated.AndExpandSomeToLeftWasCalledWithExternalStateAsserts,
            TheOptionHasBeenCreated.AndExpandSomeToLeftWasCalledWithExternalStateAsserts> was_invoked_once_with(FakeExternalState externalState)
            => the_whenNone.function
                           .was_invoked_once_with<FakeExternalState, FakeRight, TheOptionHasBeenCreated.AndExpandSomeToLeftWasCalledWithExternalStateAsserts>(externalState);

         /* ------------------------------------------------------------ */

         public IAssert<TheOptionHasBeenCreated.AndExpandSomeToLeftWasCalledWithExternalStateAsserts,
            TheOptionHasBeenCreated.AndExpandSomeToLeftWasCalledWithExternalStateAsserts> was_not_invoked()
            => the_whenNone.function.was_not_invoked<FakeExternalState, FakeRight, TheOptionHasBeenCreated.AndExpandSomeToLeftWasCalledWithExternalStateAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
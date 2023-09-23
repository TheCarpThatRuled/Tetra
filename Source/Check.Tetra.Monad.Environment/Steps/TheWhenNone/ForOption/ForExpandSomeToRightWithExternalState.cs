using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenNone
   {
      partial class ForOption
      {
         public sealed class ForExpandSomeToRightWithExternalState
         {
            /* ------------------------------------------------------------ */
            // Assert
            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndExpandSomeToRightWasCalledWithExternalStateAsserts,
               TheOptionHasBeenCreated.AndExpandSomeToRightWasCalledWithExternalStateAsserts> was_invoked_once_with(FakeExternalState externalState)
               => the_whenNone.function
                              .was_invoked_once_with<FakeExternalState, FakeLeft, TheOptionHasBeenCreated.AndExpandSomeToRightWasCalledWithExternalStateAsserts>(externalState);

            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndExpandSomeToRightWasCalledWithExternalStateAsserts,
               TheOptionHasBeenCreated.AndExpandSomeToRightWasCalledWithExternalStateAsserts> was_not_invoked()
               => the_whenNone.function.was_not_invoked<FakeExternalState, FakeLeft, TheOptionHasBeenCreated.AndExpandSomeToRightWasCalledWithExternalStateAsserts>();

            /* ------------------------------------------------------------ */
         }
      }
   }
}
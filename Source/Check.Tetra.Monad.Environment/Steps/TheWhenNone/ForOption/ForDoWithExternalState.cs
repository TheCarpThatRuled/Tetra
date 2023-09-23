using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenNone
   {
      partial class ForOption
      {
         public sealed class ForDoWithExternalState
         {
            /* ------------------------------------------------------------ */
            // Assert
            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndDoWasCalledWithExternalStateAsserts, TheOptionHasBeenCreated.AndDoWasCalledWithExternalStateAsserts> was_invoked_once_with(
               FakeExternalState externalState)
               => the_whenNone.action.was_invoked_once_with<FakeExternalState, TheOptionHasBeenCreated.AndDoWasCalledWithExternalStateAsserts>(externalState);

            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndDoWasCalledWithExternalStateAsserts, TheOptionHasBeenCreated.AndDoWasCalledWithExternalStateAsserts> was_not_invoked()
               => the_whenNone.action.was_not_invoked<FakeExternalState, TheOptionHasBeenCreated.AndDoWasCalledWithExternalStateAsserts>();

            /* ------------------------------------------------------------ */
         }
      }
   }
}
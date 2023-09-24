using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenLeft
   {
      public sealed class ForDoWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndDoWasCalledWithExternalStateAsserts, TheEitherHasBeenCreated.AndDoWasCalledWithExternalStateAsserts> was_invoked_once_with(
            FakeExternalState externalState,
            FakeLeft          expected)
            => the_whenLeft.action.was_invoked_once_with<FakeExternalState, FakeLeft, TheEitherHasBeenCreated.AndDoWasCalledWithExternalStateAsserts>(externalState,
               expected);

         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndDoWasCalledWithExternalStateAsserts, TheEitherHasBeenCreated.AndDoWasCalledWithExternalStateAsserts> was_not_invoked()
            => the_whenLeft.action.was_not_invoked<FakeExternalState, FakeLeft, TheEitherHasBeenCreated.AndDoWasCalledWithExternalStateAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
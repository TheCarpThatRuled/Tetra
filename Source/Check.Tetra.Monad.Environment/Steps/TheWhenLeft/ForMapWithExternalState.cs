using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenLeft
   {
      public sealed class ForMapWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndMapWasCalledWithExternalStateAsserts, TheEitherHasBeenCreated.AndMapWasCalledWithExternalStateAsserts> was_invoked_once_with
         (
            FakeExternalState expectedExternalState,
            FakeLeft          expectedContent
         )
            => the_whenLeft.function.was_invoked_once_with<FakeExternalState, FakeLeft, FakeNewLeft, TheEitherHasBeenCreated.AndMapWasCalledWithExternalStateAsserts>(
               expectedExternalState,
               expectedContent);

         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndMapWasCalledWithExternalStateAsserts, TheEitherHasBeenCreated.AndMapWasCalledWithExternalStateAsserts> was_not_invoked()
            => the_whenLeft.function.was_not_invoked<FakeExternalState, FakeLeft, FakeNewLeft, TheEitherHasBeenCreated.AndMapWasCalledWithExternalStateAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
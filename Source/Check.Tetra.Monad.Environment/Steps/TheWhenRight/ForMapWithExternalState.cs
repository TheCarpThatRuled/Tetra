using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenRight
   {
      public sealed class ForMapWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndMapWasCalledWithExternalStateAsserts, TheEitherHasBeenCreated.AndMapWasCalledWithExternalStateAsserts> was_invoked_once_with
         (
            FakeExternalState expectedExternalState,
            FakeRight         expectedContent
         )
            => the_whenRight.function.was_invoked_once_with<FakeExternalState, FakeRight, FakeNewRight, TheEitherHasBeenCreated.AndMapWasCalledWithExternalStateAsserts>(
               expectedExternalState,
               expectedContent);

         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndMapWasCalledWithExternalStateAsserts, TheEitherHasBeenCreated.AndMapWasCalledWithExternalStateAsserts> was_not_invoked()
            => the_whenRight.function.was_not_invoked<FakeExternalState, FakeRight, FakeNewRight, TheEitherHasBeenCreated.AndMapWasCalledWithExternalStateAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
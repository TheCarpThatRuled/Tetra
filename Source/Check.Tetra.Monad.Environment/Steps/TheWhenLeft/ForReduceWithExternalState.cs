using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenLeft
   {

      public sealed class ForReduceWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts, TheEitherHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts>
            was_invoked_once_with(FakeExternalState expectedExternalState,
                                  FakeLeft          expectedContent)
            => the_whenLeft.function.was_invoked_once_with<FakeExternalState, FakeLeft, FakeNewType, TheEitherHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts>(
               expectedExternalState,
               expectedContent);

         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts, TheEitherHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts> was_not_invoked()
            => the_whenLeft.function.was_not_invoked<FakeExternalState, FakeLeft, FakeNewType, TheEitherHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenRight
   {

      public sealed class ForReduceWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts, TheEitherHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts>
            was_invoked_once_with(FakeExternalState expectedExternalState,
                                  FakeRight          expectedContent)
            => the_whenRight.function.was_invoked_once_with<FakeExternalState, FakeRight, FakeNewType, TheEitherHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts>(
               expectedExternalState,
               expectedContent);

         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts, TheEitherHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts> was_not_invoked()
            => the_whenRight.function.was_not_invoked<FakeExternalState, FakeRight, FakeNewType, TheEitherHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenLeft
   {
      public sealed class ForUnifyWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndUnifyWasCalledWithExternalStateAsserts, TheEitherHasBeenCreated.AndUnifyWasCalledWithExternalStateAsserts>
            was_invoked_once_with(FakeExternalState expectedExternalState,
                                  FakeLeft          expectedContent)
            => the_whenLeft.function.was_invoked_once_with<FakeExternalState, FakeLeft, FakeNewType, TheEitherHasBeenCreated.AndUnifyWasCalledWithExternalStateAsserts>(
               expectedExternalState,
               expectedContent);

         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndUnifyWasCalledWithExternalStateAsserts, TheEitherHasBeenCreated.AndUnifyWasCalledWithExternalStateAsserts> was_not_invoked()
            => the_whenLeft.function.was_not_invoked<FakeExternalState, FakeLeft, FakeNewType, TheEitherHasBeenCreated.AndUnifyWasCalledWithExternalStateAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenRight
   {

      public sealed class ForUnifyWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndUnifyWasCalledWithExternalStateAsserts, TheEitherHasBeenCreated.AndUnifyWasCalledWithExternalStateAsserts>
            was_invoked_once_with(FakeExternalState expectedExternalState,
                                  FakeRight          expectedContent)
            => the_whenRight.function.was_invoked_once_with<FakeExternalState, FakeRight, FakeNewType, TheEitherHasBeenCreated.AndUnifyWasCalledWithExternalStateAsserts>(
               expectedExternalState,
               expectedContent);

         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndUnifyWasCalledWithExternalStateAsserts, TheEitherHasBeenCreated.AndUnifyWasCalledWithExternalStateAsserts> was_not_invoked()
            => the_whenRight.function.was_not_invoked<FakeExternalState, FakeRight, FakeNewType, TheEitherHasBeenCreated.AndUnifyWasCalledWithExternalStateAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}

using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenNone
   {
      public sealed class ForUnifyWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheOptionHasBeenCreated.AndUnifyWasCalledWithExternalStateAsserts, TheOptionHasBeenCreated.AndUnifyWasCalledWithExternalStateAsserts>
            was_invoked_once_with(FakeExternalState externalState)
            => the_whenNone.function.was_invoked_once_with<FakeExternalState, FakeNewType, TheOptionHasBeenCreated.AndUnifyWasCalledWithExternalStateAsserts>(externalState);

         /* ------------------------------------------------------------ */

         public IAssert<TheOptionHasBeenCreated.AndUnifyWasCalledWithExternalStateAsserts, TheOptionHasBeenCreated.AndUnifyWasCalledWithExternalStateAsserts> was_not_invoked()
            => the_whenNone.function.was_not_invoked<FakeExternalState, FakeNewType, TheOptionHasBeenCreated.AndUnifyWasCalledWithExternalStateAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
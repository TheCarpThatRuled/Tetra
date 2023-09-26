using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenNone
   {
      public sealed class ForUnify
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheOptionHasBeenCreated.AndUnifyWasCalledAsserts, TheOptionHasBeenCreated.AndUnifyWasCalledAsserts> was_invoked_once()
            => the_whenNone.function.was_invoked_once<FakeNewType, TheOptionHasBeenCreated.AndUnifyWasCalledAsserts>();

         /* ------------------------------------------------------------ */

         public IAssert<TheOptionHasBeenCreated.AndUnifyWasCalledAsserts, TheOptionHasBeenCreated.AndUnifyWasCalledAsserts> was_not_invoked()
            => the_whenNone.function.was_not_invoked<FakeNewType, TheOptionHasBeenCreated.AndUnifyWasCalledAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
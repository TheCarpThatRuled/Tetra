using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenLeft
   {
      public sealed class ForUnify
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndUnifyWasCalledAsserts, TheEitherHasBeenCreated.AndUnifyWasCalledAsserts> was_invoked_once_with
         (
            FakeLeft expected
         )
            => the_whenLeft.function.was_invoked_once_with<FakeLeft, FakeNewType, TheEitherHasBeenCreated.AndUnifyWasCalledAsserts>(expected);

         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndUnifyWasCalledAsserts, TheEitherHasBeenCreated.AndUnifyWasCalledAsserts> was_not_invoked()
            => the_whenLeft.function.was_not_invoked<FakeLeft, FakeNewType, TheEitherHasBeenCreated.AndUnifyWasCalledAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
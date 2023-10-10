using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenRight
   {
      public sealed class ForUnify
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndUnifyWasCalledAsserts, TheEitherHasBeenCreated.AndUnifyWasCalledAsserts> was_invoked_once_with
         (
            FakeRight expected
         )
            => the_whenRight.function.was_invoked_once_with<FakeRight, FakeNewType, TheEitherHasBeenCreated.AndUnifyWasCalledAsserts>(expected);

         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndUnifyWasCalledAsserts, TheEitherHasBeenCreated.AndUnifyWasCalledAsserts> was_not_invoked()
            => the_whenRight.function.was_not_invoked<FakeRight, FakeNewType, TheEitherHasBeenCreated.AndUnifyWasCalledAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
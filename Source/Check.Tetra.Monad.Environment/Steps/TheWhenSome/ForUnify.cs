using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenSome
   {
      public sealed class ForUnify
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheOptionHasBeenCreated.AndUnifyWasCalledAsserts, TheOptionHasBeenCreated.AndUnifyWasCalledAsserts> was_invoked_once_with
         (
            FakeType expected
         )
            => the_whenSome.function.was_invoked_once_with<FakeType, FakeNewType, TheOptionHasBeenCreated.AndUnifyWasCalledAsserts>(expected);

         /* ------------------------------------------------------------ */

         public IAssert<TheOptionHasBeenCreated.AndUnifyWasCalledAsserts, TheOptionHasBeenCreated.AndUnifyWasCalledAsserts> was_not_invoked()
            => the_whenSome.function.was_not_invoked<FakeType, FakeNewType, TheOptionHasBeenCreated.AndUnifyWasCalledAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
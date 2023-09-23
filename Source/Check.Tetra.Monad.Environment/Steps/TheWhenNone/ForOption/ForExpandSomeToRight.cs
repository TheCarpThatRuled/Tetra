using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenNone
   {
      partial class ForOption
      {
         public sealed class ForExpandSomeToRight
         {
            /* ------------------------------------------------------------ */
            // Assert
            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndExpandSomeToRightWasCalledAsserts, TheOptionHasBeenCreated.AndExpandSomeToRightWasCalledAsserts> was_invoked_once()
               => the_whenNone.function.was_invoked_once<FakeLeft, TheOptionHasBeenCreated.AndExpandSomeToRightWasCalledAsserts>();

            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndExpandSomeToRightWasCalledAsserts, TheOptionHasBeenCreated.AndExpandSomeToRightWasCalledAsserts> was_not_invoked()
               => the_whenNone.function.was_not_invoked<FakeLeft, TheOptionHasBeenCreated.AndExpandSomeToRightWasCalledAsserts>();

            /* ------------------------------------------------------------ */
         }
      }
   }
}
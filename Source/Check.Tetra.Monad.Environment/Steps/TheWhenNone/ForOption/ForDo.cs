using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenNone
   {
      partial class ForOption
      {
         public sealed class ForDo
         {
            /* ------------------------------------------------------------ */
            // Assert
            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndDoWasCalledAsserts, TheOptionHasBeenCreated.AndDoWasCalledAsserts> was_invoked_once()
               => the_whenNone.action.was_invoked_once<TheOptionHasBeenCreated.AndDoWasCalledAsserts>();

            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndDoWasCalledAsserts, TheOptionHasBeenCreated.AndDoWasCalledAsserts> was_not_invoked()
               => the_whenNone.action.was_not_invoked<TheOptionHasBeenCreated.AndDoWasCalledAsserts>();

            /* ------------------------------------------------------------ */
         }
      }
   }
}
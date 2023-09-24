using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenNone
   {
      public sealed class ForExpandSomeToLeft
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheOptionHasBeenCreated.AndExpandSomeToLeftWasCalledAsserts, TheOptionHasBeenCreated.AndExpandSomeToLeftWasCalledAsserts> was_invoked_once()
            => the_whenNone.function.was_invoked_once<FakeRight, TheOptionHasBeenCreated.AndExpandSomeToLeftWasCalledAsserts>();

         /* ------------------------------------------------------------ */

         public IAssert<TheOptionHasBeenCreated.AndExpandSomeToLeftWasCalledAsserts, TheOptionHasBeenCreated.AndExpandSomeToLeftWasCalledAsserts> was_not_invoked()
            => the_whenNone.function.was_not_invoked<FakeRight, TheOptionHasBeenCreated.AndExpandSomeToLeftWasCalledAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
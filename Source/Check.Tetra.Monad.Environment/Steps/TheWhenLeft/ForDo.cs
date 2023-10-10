using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenLeft
   {
      public sealed class ForDo
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndDoWasCalledAsserts, TheEitherHasBeenCreated.AndDoWasCalledAsserts> was_invoked_once_with
         (
            FakeLeft expected
         )
            => the_whenLeft.action.was_invoked_once_with<FakeLeft, TheEitherHasBeenCreated.AndDoWasCalledAsserts>(expected);

         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndDoWasCalledAsserts, TheEitherHasBeenCreated.AndDoWasCalledAsserts> was_not_invoked()
            => the_whenLeft.action.was_not_invoked<FakeLeft, TheEitherHasBeenCreated.AndDoWasCalledAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
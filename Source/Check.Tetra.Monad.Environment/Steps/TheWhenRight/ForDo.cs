using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenRight
   {
      public sealed class ForDo
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndDoWasCalledAsserts, TheEitherHasBeenCreated.AndDoWasCalledAsserts> was_invoked_once_with(FakeRight expected)
            => the_whenRight.action.was_invoked_once_with<FakeRight, TheEitherHasBeenCreated.AndDoWasCalledAsserts>(expected);

         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndDoWasCalledAsserts, TheEitherHasBeenCreated.AndDoWasCalledAsserts> was_not_invoked()
            => the_whenRight.action.was_not_invoked<FakeRight, TheEitherHasBeenCreated.AndDoWasCalledAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
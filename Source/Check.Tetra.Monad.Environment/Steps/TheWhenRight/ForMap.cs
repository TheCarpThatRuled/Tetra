using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenRight
   {
      public sealed class ForMap
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndMapWasCalledAsserts, TheEitherHasBeenCreated.AndMapWasCalledAsserts> was_invoked_once_with
         (
            FakeRight expected
         )
            => the_whenRight.function.was_invoked_once_with<FakeRight, FakeNewRight, TheEitherHasBeenCreated.AndMapWasCalledAsserts>(expected);

         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndMapWasCalledAsserts, TheEitherHasBeenCreated.AndMapWasCalledAsserts> was_not_invoked()
            => the_whenRight.function.was_not_invoked<FakeRight, FakeNewRight, TheEitherHasBeenCreated.AndMapWasCalledAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
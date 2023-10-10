using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenLeft
   {
      public sealed class ForMap
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndMapWasCalledAsserts, TheEitherHasBeenCreated.AndMapWasCalledAsserts> was_invoked_once_with
         (
            FakeLeft expected
         )
            => the_whenLeft.function.was_invoked_once_with<FakeLeft, FakeNewLeft, TheEitherHasBeenCreated.AndMapWasCalledAsserts>(expected);

         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndMapWasCalledAsserts, TheEitherHasBeenCreated.AndMapWasCalledAsserts> was_not_invoked()
            => the_whenLeft.function.was_not_invoked<FakeLeft, FakeNewLeft, TheEitherHasBeenCreated.AndMapWasCalledAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
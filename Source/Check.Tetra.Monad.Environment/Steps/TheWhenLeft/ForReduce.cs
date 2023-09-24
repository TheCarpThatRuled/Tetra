using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenLeft
   {

      public sealed class ForReduce
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndReduceWasCalledAsserts, TheEitherHasBeenCreated.AndReduceWasCalledAsserts> was_invoked_once_with(FakeLeft expected)
            => the_whenLeft.function.was_invoked_once_with<FakeLeft, FakeNewType, TheEitherHasBeenCreated.AndReduceWasCalledAsserts>(expected);

         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndReduceWasCalledAsserts, TheEitherHasBeenCreated.AndReduceWasCalledAsserts> was_not_invoked()
            => the_whenLeft.function.was_not_invoked<FakeLeft, FakeNewType, TheEitherHasBeenCreated.AndReduceWasCalledAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenRight
   {

      public sealed class ForReduce
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndReduceWasCalledAsserts, TheEitherHasBeenCreated.AndReduceWasCalledAsserts> was_invoked_once_with(FakeRight expected)
            => the_whenRight.function.was_invoked_once_with<FakeRight, FakeNewType, TheEitherHasBeenCreated.AndReduceWasCalledAsserts>(expected);

         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndReduceWasCalledAsserts, TheEitherHasBeenCreated.AndReduceWasCalledAsserts> was_not_invoked()
            => the_whenRight.function.was_not_invoked<FakeRight, FakeNewType, TheEitherHasBeenCreated.AndReduceWasCalledAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
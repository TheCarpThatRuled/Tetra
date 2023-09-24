using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenNone
   {
      public sealed class ForReduce
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheOptionHasBeenCreated.AndReduceWasCalledAsserts, TheOptionHasBeenCreated.AndReduceWasCalledAsserts> was_invoked_once()
            => the_whenNone.function.was_invoked_once<FakeNewType, TheOptionHasBeenCreated.AndReduceWasCalledAsserts>();

         /* ------------------------------------------------------------ */

         public IAssert<TheOptionHasBeenCreated.AndReduceWasCalledAsserts, TheOptionHasBeenCreated.AndReduceWasCalledAsserts> was_not_invoked()
            => the_whenNone.function.was_not_invoked<FakeNewType, TheOptionHasBeenCreated.AndReduceWasCalledAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
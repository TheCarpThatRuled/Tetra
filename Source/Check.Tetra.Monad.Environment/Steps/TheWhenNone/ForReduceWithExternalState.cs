using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenNone
   {
      public sealed class ForReduceWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheOptionHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts, TheOptionHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts>
            was_invoked_once_with(FakeExternalState externalState)
            => the_whenNone.function.was_invoked_once_with<FakeExternalState, FakeNewType, TheOptionHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts>(externalState);

         /* ------------------------------------------------------------ */

         public IAssert<TheOptionHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts, TheOptionHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts> was_not_invoked()
            => the_whenNone.function.was_not_invoked<FakeExternalState, FakeNewType, TheOptionHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenSome
   {

      public sealed class ForReduceWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheOptionHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts, TheOptionHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts>
            was_invoked_once_with(FakeExternalState expectedExternalState,
                                  FakeType          expectedContent)
            => the_whenSome.function.was_invoked_once_with<FakeExternalState, FakeType, FakeNewType, TheOptionHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts>(
               expectedExternalState,
               expectedContent);

         /* ------------------------------------------------------------ */

         public IAssert<TheOptionHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts, TheOptionHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts> was_not_invoked()
            => the_whenSome.function.was_not_invoked<FakeExternalState, FakeType, FakeNewType, TheOptionHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
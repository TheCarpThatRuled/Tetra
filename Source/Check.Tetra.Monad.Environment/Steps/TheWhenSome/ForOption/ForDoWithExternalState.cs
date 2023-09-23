using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenSome
   {
      partial class ForOption
      {
         public sealed class ForDoWithExternalState
         {
            /* ------------------------------------------------------------ */
            // Assert
            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndDoWasCalledWithExternalStateAsserts, TheOptionHasBeenCreated.AndDoWasCalledWithExternalStateAsserts> was_invoked_once_with(
               FakeExternalState externalState,
               FakeType          expected)
               => the_whenSome.action.was_invoked_once_with<FakeExternalState, FakeType, TheOptionHasBeenCreated.AndDoWasCalledWithExternalStateAsserts>(externalState,
                  expected);

            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndDoWasCalledWithExternalStateAsserts, TheOptionHasBeenCreated.AndDoWasCalledWithExternalStateAsserts> was_not_invoked()
               => the_whenSome.action.was_not_invoked<FakeExternalState, FakeType, TheOptionHasBeenCreated.AndDoWasCalledWithExternalStateAsserts>();

            /* ------------------------------------------------------------ */
         }
      }
   }
}
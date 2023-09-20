using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenNone
   {
      public sealed class ForDoWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<DoWasCalledWithExternalState.Asserts, DoWasCalledWithExternalState.Asserts> was_invoked_once_with(FakeExternalState externalState)
            => the_whenNone.was_invoked_once_with<FakeExternalState, DoWasCalledWithExternalState.Asserts>(externalState);

         /* ------------------------------------------------------------ */

         public IAssert<DoWasCalledWithExternalState.Asserts, DoWasCalledWithExternalState.Asserts> was_not_invoked()
            => the_whenNone.was_not_invoked<FakeExternalState, DoWasCalledWithExternalState.Asserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
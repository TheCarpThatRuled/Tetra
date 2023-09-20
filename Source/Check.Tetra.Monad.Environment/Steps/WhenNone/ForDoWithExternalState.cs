using Tetra.Testing;
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class WhenNone
   {
      public sealed class ForDoWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<DoWasCalledWithExternalState.Asserts, DoWasCalledWithExternalState.Asserts> was_invoked_once_with(FakeExternalState externalState)
            => whenNone.was_invoked_once_with<FakeExternalState, DoWasCalledWithExternalState.Asserts>(externalState);

         /* ------------------------------------------------------------ */

         public IAssert<DoWasCalledWithExternalState.Asserts, DoWasCalledWithExternalState.Asserts> was_not_invoked()
            => whenNone.was_not_invoked<FakeExternalState, DoWasCalledWithExternalState.Asserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class WhenSome
   {
      public sealed class ForDoWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<DoWasCalledWithExternalState.Asserts, DoWasCalledWithExternalState.Asserts> was_invoked_once_with(FakeExternalState externalState,
                                                                                                                          FakeType          expected)
            => whenSome.was_invoked_once_with<FakeExternalState, FakeType, DoWasCalledWithExternalState.Asserts>(
               externalState,
               expected);

         /* ------------------------------------------------------------ */

         public IAssert<DoWasCalledWithExternalState.Asserts, DoWasCalledWithExternalState.Asserts> was_not_invoked()
            => whenSome.was_not_invoked<FakeExternalState, FakeType, DoWasCalledWithExternalState.Asserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
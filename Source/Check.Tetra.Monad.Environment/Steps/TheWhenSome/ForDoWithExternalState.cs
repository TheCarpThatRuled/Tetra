using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenSome
   {
      public sealed class ForDoWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<DoWasCalledWithExternalState.Asserts, DoWasCalledWithExternalState.Asserts> was_invoked_once_with(FakeExternalState externalState,
                                                                                                                          FakeType          expected)
            => the_whenSome.action.was_invoked_once_with<FakeExternalState, FakeType, DoWasCalledWithExternalState.Asserts>(
               externalState,
               expected);

         /* ------------------------------------------------------------ */

         public IAssert<DoWasCalledWithExternalState.Asserts, DoWasCalledWithExternalState.Asserts> was_not_invoked()
            => the_whenSome.action.was_not_invoked<FakeExternalState, FakeType, DoWasCalledWithExternalState.Asserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
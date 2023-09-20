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

         public IAssert<ReduceWasCalledWithExternalState.Asserts, ReduceWasCalledWithExternalState.Asserts> was_invoked_once_with(FakeExternalState externalState)
            => the_whenNone.function.was_invoked_once_with<FakeExternalState, FakeNewType, ReduceWasCalledWithExternalState.Asserts>(externalState);

         /* ------------------------------------------------------------ */

         public IAssert<ReduceWasCalledWithExternalState.Asserts, ReduceWasCalledWithExternalState.Asserts> was_not_invoked()
            => the_whenNone.function.was_not_invoked<FakeExternalState, FakeNewType, ReduceWasCalledWithExternalState.Asserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
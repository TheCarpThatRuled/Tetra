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

         public IAssert<ReduceWasCalledWithExternalState.Asserts, ReduceWasCalledWithExternalState.Asserts> was_invoked_once_with(FakeExternalState expectedExternalState,
            FakeType                                                                                                                          expectedContent)
            => the_whenSome.function.was_invoked_once_with<FakeExternalState, FakeType, FakeNewType, ReduceWasCalledWithExternalState.Asserts>(expectedExternalState,
               expectedContent);

         /* ------------------------------------------------------------ */

         public IAssert<ReduceWasCalledWithExternalState.Asserts, ReduceWasCalledWithExternalState.Asserts> was_not_invoked()
            => the_whenSome.function.was_not_invoked<FakeExternalState, FakeType, FakeNewType, ReduceWasCalledWithExternalState.Asserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
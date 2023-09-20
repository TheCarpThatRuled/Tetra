using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenSome
   {
      public sealed class ForMapWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<MapWasCalledWithExternalState.Asserts, MapWasCalledWithExternalState.Asserts> was_invoked_once_with(FakeExternalState expectedExternalState,
            FakeType                                                                                                                          expectedContent)
            => the_whenSome.function.was_invoked_once_with<FakeExternalState, FakeType, FakeNewType, MapWasCalledWithExternalState.Asserts>(expectedExternalState,
               expectedContent);

         /* ------------------------------------------------------------ */

         public IAssert<MapWasCalledWithExternalState.Asserts, MapWasCalledWithExternalState.Asserts> was_not_invoked()
            => the_whenSome.function.was_not_invoked<FakeExternalState, FakeType, FakeNewType, MapWasCalledWithExternalState.Asserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
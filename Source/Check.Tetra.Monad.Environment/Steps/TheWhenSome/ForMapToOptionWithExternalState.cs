using Tetra;
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenSome
   {
      public sealed class ForMapToOptionWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<MapToOptionWasCalledWithExternalState.Asserts, MapToOptionWasCalledWithExternalState.Asserts> was_invoked_once_with(FakeExternalState expectedExternalState,
            FakeType                                                                                                                                          expectedContent)
            => the_whenSome.function.was_invoked_once_with<FakeExternalState, FakeType, IOption<FakeNewType>, MapToOptionWasCalledWithExternalState.Asserts>(expectedExternalState,
               expectedContent);

         /* ------------------------------------------------------------ */

         public IAssert<MapToOptionWasCalledWithExternalState.Asserts, MapToOptionWasCalledWithExternalState.Asserts> was_not_invoked()
            => the_whenSome.function.was_not_invoked<FakeExternalState, FakeType, IOption<FakeNewType>, MapToOptionWasCalledWithExternalState.Asserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
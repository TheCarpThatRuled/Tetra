using Tetra;
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenSome
   {
      partial class ForOption
      {
         public sealed class ForMapWithFuncToOptionAndExternalState
         {
            /* ------------------------------------------------------------ */
            // Assert
            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndMapWasCalledWithFuncToOptionAndExternalStateAsserts,
               TheOptionHasBeenCreated.AndMapWasCalledWithFuncToOptionAndExternalStateAsserts> was_invoked_once_with(FakeExternalState expectedExternalState,
                                                                                                                     FakeType          expectedContent)
               => the_whenSome.function
                              .was_invoked_once_with<FakeExternalState, FakeType, IOption<FakeNewType>,
                                  TheOptionHasBeenCreated.AndMapWasCalledWithFuncToOptionAndExternalStateAsserts>(expectedExternalState,
                                                                                                                  expectedContent);

            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndMapWasCalledWithFuncToOptionAndExternalStateAsserts,
               TheOptionHasBeenCreated.AndMapWasCalledWithFuncToOptionAndExternalStateAsserts> was_not_invoked()
               => the_whenSome.function
                              .was_not_invoked<FakeExternalState, FakeType, IOption<FakeNewType>, TheOptionHasBeenCreated.AndMapWasCalledWithFuncToOptionAndExternalStateAsserts>();

            /* ------------------------------------------------------------ */
         }
      }
   }
}
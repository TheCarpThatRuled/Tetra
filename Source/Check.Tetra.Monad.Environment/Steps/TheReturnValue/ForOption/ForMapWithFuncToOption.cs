using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheReturnValue
   {
      partial class ForOption
      {
         public sealed class ForMapToOption
         {
            /* ------------------------------------------------------------ */
            // Assert
            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndMapWasCalledWithFuncToOptionAsserts, TheOptionHasBeenCreated.AndMapWasCalledWithFuncToOptionAsserts> is_a_none()
               => the_return_value.is_a_none<FakeNewType, TheOptionHasBeenCreated.AndMapWasCalledWithFuncToOptionAsserts>();

            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndMapWasCalledWithFuncToOptionAsserts, TheOptionHasBeenCreated.AndMapWasCalledWithFuncToOptionAsserts> is_a_some_containing(
               FakeNewType expected)
               => the_return_value.is_a_some_containing<FakeNewType, TheOptionHasBeenCreated.AndMapWasCalledWithFuncToOptionAsserts>(expected);

            /* ------------------------------------------------------------ */
         }
      }
   }
}
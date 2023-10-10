using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheReturnValue
   {
      partial class ForOption
      {
         public sealed class ForMapWithExternalState
         {
            /* ------------------------------------------------------------ */
            // Assert
            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndMapWasCalledWithExternalStateAsserts, TheOptionHasBeenCreated.AndMapWasCalledWithExternalStateAsserts> is_a_none()
               => the_return_value.is_a_none<FakeNewType, TheOptionHasBeenCreated.AndMapWasCalledWithExternalStateAsserts>();

            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndMapWasCalledWithExternalStateAsserts, TheOptionHasBeenCreated.AndMapWasCalledWithExternalStateAsserts> is_a_some_containing
            (
               FakeNewType expected
            )
               => the_return_value.is_a_some_containing<FakeNewType, TheOptionHasBeenCreated.AndMapWasCalledWithExternalStateAsserts>(expected);

            /* ------------------------------------------------------------ */
         }
      }
   }
}
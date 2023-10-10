using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheReturnValue
   {
      partial class ForOption
      {
         public sealed class ForUnifyWithExternalState
         {
            /* ------------------------------------------------------------ */
            // Assert
            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndUnifyWasCalledWithExternalStateAsserts, TheOptionHasBeenCreated.AndUnifyWasCalledWithExternalStateAsserts> is_equal_to
            (
               FakeNewType expected
            )
               => the_return_value.is_equal_to<FakeNewType, TheOptionHasBeenCreated.AndUnifyWasCalledWithExternalStateAsserts>(expected);

            /* ------------------------------------------------------------ */
         }
      }
   }
}
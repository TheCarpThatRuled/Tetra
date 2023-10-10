using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheReturnValue
   {
      partial class ForOption
      {
         public sealed class ForExpandSomeToLeft
         {
            /* ------------------------------------------------------------ */
            // Assert
            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndExpandSomeToLeftWasCalledAsserts, TheOptionHasBeenCreated.AndExpandSomeToLeftWasCalledAsserts> is_a_left_containing
            (
               FakeType expected
            )
               => the_return_value.is_a_left_containing<FakeType, FakeRight, TheOptionHasBeenCreated.AndExpandSomeToLeftWasCalledAsserts>(expected);

            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndExpandSomeToLeftWasCalledAsserts, TheOptionHasBeenCreated.AndExpandSomeToLeftWasCalledAsserts> is_a_right_containing
            (
               FakeRight expected
            )
               => the_return_value.is_a_right_containing<FakeType, FakeRight, TheOptionHasBeenCreated.AndExpandSomeToLeftWasCalledAsserts>(expected);

            /* ------------------------------------------------------------ */
         }
      }
   }
}
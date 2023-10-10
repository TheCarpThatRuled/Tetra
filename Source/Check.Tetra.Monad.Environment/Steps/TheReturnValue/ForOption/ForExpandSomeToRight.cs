using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheReturnValue
   {
      partial class ForOption
      {
         public sealed class ForExpandSomeToRight
         {
            /* ------------------------------------------------------------ */
            // Assert
            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndExpandSomeToRightWasCalledAsserts, TheOptionHasBeenCreated.AndExpandSomeToRightWasCalledAsserts> is_a_left_containing
            (
               FakeLeft expected
            )
               => the_return_value.is_a_left_containing<FakeLeft, FakeType, TheOptionHasBeenCreated.AndExpandSomeToRightWasCalledAsserts>(expected);

            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndExpandSomeToRightWasCalledAsserts, TheOptionHasBeenCreated.AndExpandSomeToRightWasCalledAsserts> is_a_right_containing
            (
               FakeType expected
            )
               => the_return_value.is_a_right_containing<FakeLeft, FakeType, TheOptionHasBeenCreated.AndExpandSomeToRightWasCalledAsserts>(expected);

            /* ------------------------------------------------------------ */
         }
      }
   }
}
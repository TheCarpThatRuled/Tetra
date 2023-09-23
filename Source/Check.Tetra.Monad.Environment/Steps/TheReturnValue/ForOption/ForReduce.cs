using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheReturnValue
   {
      partial class ForOption
      {
         public sealed class ForReduce
         {
            /* ------------------------------------------------------------ */
            // Assert
            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndReduceWasCalledAsserts, TheOptionHasBeenCreated.AndReduceWasCalledAsserts> is_equal_to(FakeNewType expected)
               => the_return_value.is_equal_to<FakeNewType, TheOptionHasBeenCreated.AndReduceWasCalledAsserts>(expected);

            /* ------------------------------------------------------------ */
         }
      }
   }
}
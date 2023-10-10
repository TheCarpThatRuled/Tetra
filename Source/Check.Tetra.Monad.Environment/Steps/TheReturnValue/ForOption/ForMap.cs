using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheReturnValue
   {
      partial class ForOption
      {
         public sealed class ForMap
         {
            /* ------------------------------------------------------------ */
            // Assert
            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndMapWasCalledAsserts, TheOptionHasBeenCreated.AndMapWasCalledAsserts> is_a_none()
               => the_return_value.is_a_none<FakeNewType, TheOptionHasBeenCreated.AndMapWasCalledAsserts>();

            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndMapWasCalledAsserts, TheOptionHasBeenCreated.AndMapWasCalledAsserts> is_a_some_containing
            (
               FakeNewType expected
            )
               => the_return_value.is_a_some_containing<FakeNewType, TheOptionHasBeenCreated.AndMapWasCalledAsserts>(expected);

            /* ------------------------------------------------------------ */
         }
      }
   }
}
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenSome
   {
      partial class ForOption
      {
         public sealed class ForMap
         {
            /* ------------------------------------------------------------ */
            // Assert
            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndMapWasCalledAsserts, TheOptionHasBeenCreated.AndMapWasCalledAsserts> was_invoked_once_with(FakeType expected)
               => the_whenSome.function.was_invoked_once_with<FakeType, FakeNewType, TheOptionHasBeenCreated.AndMapWasCalledAsserts>(expected);

            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndMapWasCalledAsserts, TheOptionHasBeenCreated.AndMapWasCalledAsserts> was_not_invoked()
               => the_whenSome.function.was_not_invoked<FakeType, FakeNewType, TheOptionHasBeenCreated.AndMapWasCalledAsserts>();

            /* ------------------------------------------------------------ */
         }
      }
   }
}
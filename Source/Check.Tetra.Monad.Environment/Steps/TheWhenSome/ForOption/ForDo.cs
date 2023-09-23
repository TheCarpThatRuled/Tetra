using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenSome
   {
      partial class ForOption
      {
         public sealed class ForDo
         {
            /* ------------------------------------------------------------ */
            // Assert
            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndDoWasCalledAsserts, TheOptionHasBeenCreated.AndDoWasCalledAsserts> was_invoked_once_with(FakeType expected)
               => the_whenSome.action.was_invoked_once_with<FakeType, TheOptionHasBeenCreated.AndDoWasCalledAsserts>(expected);

            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndDoWasCalledAsserts, TheOptionHasBeenCreated.AndDoWasCalledAsserts> was_not_invoked()
               => the_whenSome.action.was_not_invoked<FakeType, TheOptionHasBeenCreated.AndDoWasCalledAsserts>();

            /* ------------------------------------------------------------ */
         }
      }
   }
}
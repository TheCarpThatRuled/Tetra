using Tetra;
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenSome
   {
      partial class ForOption
      {
         public sealed class ForMapWithFuncToOption
         {
            /* ------------------------------------------------------------ */
            // Assert
            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndMapWasCalledWithFuncToOptionAsserts, TheOptionHasBeenCreated.AndMapWasCalledWithFuncToOptionAsserts>
               was_invoked_once_with(FakeType expected)
               => the_whenSome.function.was_invoked_once_with<FakeType, IOption<FakeNewType>, TheOptionHasBeenCreated.AndMapWasCalledWithFuncToOptionAsserts>(expected);

            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndMapWasCalledWithFuncToOptionAsserts, TheOptionHasBeenCreated.AndMapWasCalledWithFuncToOptionAsserts> was_not_invoked()
               => the_whenSome.function.was_not_invoked<FakeType, IOption<FakeNewType>, TheOptionHasBeenCreated.AndMapWasCalledWithFuncToOptionAsserts>();

            /* ------------------------------------------------------------ */
         }
      }
   }
}
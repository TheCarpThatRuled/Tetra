using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenSome
   {

      public sealed class ForReduce
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheOptionHasBeenCreated.AndReduceWasCalledAsserts, TheOptionHasBeenCreated.AndReduceWasCalledAsserts> was_invoked_once_with(FakeType expected)
            => the_whenSome.function.was_invoked_once_with<FakeType, FakeNewType, TheOptionHasBeenCreated.AndReduceWasCalledAsserts>(expected);

         /* ------------------------------------------------------------ */

         public IAssert<TheOptionHasBeenCreated.AndReduceWasCalledAsserts, TheOptionHasBeenCreated.AndReduceWasCalledAsserts> was_not_invoked()
            => the_whenSome.function.was_not_invoked<FakeType, FakeNewType, TheOptionHasBeenCreated.AndReduceWasCalledAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
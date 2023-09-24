using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheReturnValue
   {
      partial class ForEither
      {
         public sealed class ForReduceWithExternalState
         {
            /* ------------------------------------------------------------ */
            // Assert
            /* ------------------------------------------------------------ */

            public IAssert<TheEitherHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts, TheEitherHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts> is_equal_to(
               FakeNewType expected)
               => the_return_value.is_equal_to<FakeNewType, TheEitherHasBeenCreated.AndReduceWasCalledWithExternalStateAsserts>(expected);

            /* ------------------------------------------------------------ */
         }
      }
   }
}
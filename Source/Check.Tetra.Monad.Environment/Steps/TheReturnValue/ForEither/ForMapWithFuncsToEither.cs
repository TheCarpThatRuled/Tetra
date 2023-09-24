using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheReturnValue
   {
      partial class ForEither
      {
         public sealed class ForMapToEither
         {
            /* ------------------------------------------------------------ */
            // Assert
            /* ------------------------------------------------------------ */

            public IAssert<TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAsserts, TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAsserts> is_a_left_containing(
               FakeNewLeft expected)
               => the_return_value.is_a_left_containing<FakeNewLeft, FakeNewRight, TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAsserts>(expected);

            /* ------------------------------------------------------------ */

            public IAssert<TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAsserts, TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAsserts> is_a_right_containing(
               FakeNewRight expected)
               => the_return_value.is_a_right_containing<FakeNewLeft, FakeNewRight, TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAsserts>(expected);

            /* ------------------------------------------------------------ */
         }
      }
   }
}
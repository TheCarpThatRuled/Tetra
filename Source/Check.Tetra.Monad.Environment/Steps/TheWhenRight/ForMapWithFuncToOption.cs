using Tetra;
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenRight
   {
      public sealed class ForMapWithFuncsToEither
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAsserts, TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAsserts>
            was_invoked_once_with(FakeRight expected)
            => the_whenRight.function.was_invoked_once_with<FakeRight, IEither<FakeNewLeft, FakeNewRight>, TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAsserts>(expected);

         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAsserts, TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAsserts> was_not_invoked()
            => the_whenRight.function.was_not_invoked<FakeRight, IEither<FakeNewLeft, FakeNewRight>, TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
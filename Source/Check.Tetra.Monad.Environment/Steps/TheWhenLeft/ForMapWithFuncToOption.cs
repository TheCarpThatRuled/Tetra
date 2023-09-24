using Tetra;
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenLeft
   {
      public sealed class ForMapWithFuncsToEither
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAsserts, TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAsserts>
            was_invoked_once_with(FakeLeft expected)
            => the_whenLeft.function.was_invoked_once_with<FakeLeft, IEither<FakeNewLeft, FakeNewRight>, TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAsserts>(expected);

         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAsserts, TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAsserts> was_not_invoked()
            => the_whenLeft.function.was_not_invoked<FakeLeft, IEither<FakeNewLeft, FakeNewRight>, TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
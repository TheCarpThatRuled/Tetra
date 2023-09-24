using Tetra;
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenLeft
   {
      public sealed class ForMapWithFuncsToEitherAndExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts,
            TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts> was_invoked_once_with(FakeExternalState expectedExternalState,
                                                                                                                  FakeLeft          expectedContent)
            => the_whenLeft.function
                           .was_invoked_once_with<FakeExternalState, FakeLeft, IEither<FakeNewLeft, FakeNewRight>,
                               TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts>(expectedExternalState,
                                                                                                               expectedContent);

         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts,
            TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts> was_not_invoked()
            => the_whenLeft.function
                           .was_not_invoked<FakeExternalState, FakeLeft, IEither<FakeNewLeft, FakeNewRight>, TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
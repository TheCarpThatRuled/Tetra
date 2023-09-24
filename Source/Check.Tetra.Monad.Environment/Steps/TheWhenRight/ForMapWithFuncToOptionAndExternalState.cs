using Tetra;
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenRight
   {
      public sealed class ForMapWithFuncsToEitherAndExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts,
            TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts> was_invoked_once_with(FakeExternalState expectedExternalState,
                                                                                                                  FakeRight          expectedContent)
            => the_whenRight.function
                           .was_invoked_once_with<FakeExternalState, FakeRight, IEither<FakeNewLeft, FakeNewRight>,
                               TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts>(expectedExternalState,
                                                                                                               expectedContent);

         /* ------------------------------------------------------------ */

         public IAssert<TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts,
            TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts> was_not_invoked()
            => the_whenRight.function
                           .was_not_invoked<FakeExternalState, FakeRight, IEither<FakeNewLeft, FakeNewRight>, TheEitherHasBeenCreated.AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
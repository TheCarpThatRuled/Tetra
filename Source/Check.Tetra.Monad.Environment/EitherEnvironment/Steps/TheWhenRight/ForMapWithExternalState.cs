using Tetra.Testing;

namespace Check.EitherEnvironment;

using static Names;
using static AAA_test<Actions, Asserts>;

partial class Steps
{
   partial class TheWhenRight
   {
      public sealed class ForMapWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert was_invoked_once_with
         (
            FakeExternalState expectedExternalState,
            FakeRight         expectedContent
         )
            => AtomicAssert
              .Create($"{nameof(the_whenRight)}_{nameof(was_invoked_once_with)}",
                      asserts => asserts
                                .Function<FakeExternalState, FakeRight, FakeNewRight>(WhenRight)
                                .WasInvokedOnce(expectedExternalState,
                                                expectedContent));

         /* ------------------------------------------------------------ */

         public IAssert was_not_invoked()
            => AtomicAssert
              .Create($"{nameof(the_whenRight)}_{nameof(was_not_invoked)}",
                      asserts => asserts
                                .Function<FakeExternalState, FakeRight, FakeNewRight>(WhenRight)
                                .WasNotInvoked());

         /* ------------------------------------------------------------ */
      }
   }
}
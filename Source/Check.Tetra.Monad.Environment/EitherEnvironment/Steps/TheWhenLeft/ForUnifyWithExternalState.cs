﻿using Tetra.Testing;

namespace Check.EitherEnvironment;

using static Names;
using static AAA_test<Actions, Asserts>;

partial class Steps
{
   partial class TheWhenLeft
   {
      public sealed class ForUnifyWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert
            was_invoked_once_with
            (
               FakeExternalState expectedExternalState,
               FakeLeft          expectedContent
            )
            => AtomicAssert
              .Create($"{nameof(the_whenLeft)}_{nameof(was_invoked_once_with)}",
                      asserts => asserts
                                .Function<FakeExternalState, FakeLeft, FakeNewType>(WhenLeft)
                                .WasInvokedOnce(expectedExternalState,
                                                expectedContent));

         /* ------------------------------------------------------------ */

         public IAssert was_not_invoked()
            => AtomicAssert
              .Create($"{nameof(the_whenLeft)}_{nameof(was_not_invoked)}",
                      asserts => asserts
                                .Function<FakeExternalState, FakeLeft, FakeNewType>(WhenLeft)
                                .WasNotInvoked());

         /* ------------------------------------------------------------ */
      }
   }
}
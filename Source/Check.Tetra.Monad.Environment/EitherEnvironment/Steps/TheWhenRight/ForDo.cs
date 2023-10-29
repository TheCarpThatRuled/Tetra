using Tetra.Testing;

namespace Check.EitherEnvironment;

using static Names;
using static AAA_test<Actions, Asserts>;

partial class Steps
{
   partial class TheWhenRight
   {
      public sealed class ForDo
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert was_invoked_once_with
         (
            FakeRight expected
         )
            => AtomicAssert
              .Create($"{nameof(the_whenRight)}_{nameof(was_invoked_once_with)}",
                      asserts => asserts
                                .Action<FakeRight>(WhenRight)
                                .WasInvokedOnce(expected));

         /* ------------------------------------------------------------ */

         public IAssert was_not_invoked()
            => AtomicAssert
              .Create($"{nameof(the_whenRight)}_{nameof(was_not_invoked)}",
                      asserts => asserts
                                .Action<FakeRight>(WhenRight)
                                .WasNotInvoked());

         /* ------------------------------------------------------------ */
      }
   }
}
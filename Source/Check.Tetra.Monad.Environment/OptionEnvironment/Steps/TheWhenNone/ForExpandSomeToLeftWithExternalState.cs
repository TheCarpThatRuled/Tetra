using Tetra.Testing;

namespace Check.OptionEnvironment;

using static Names;
using static AAA_test<Actions, Asserts>;

partial class Steps
{
   partial class TheWhenNone
   {
      public sealed class ForExpandSomeToLeftWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert was_invoked_once_with
            (
               FakeExternalState externalState
            )
            => AtomicAssert
              .Create($@"{nameof(the_whenNone)}_{nameof(was_invoked_once_with)} ""{externalState}""",
                      assert => assert
                               .Function<FakeExternalState, FakeRight>(WhenNone)
                               .WasInvokedOnce(externalState));

         /* ------------------------------------------------------------ */

         public IAssert was_not_invoked()
            => AtomicAssert
              .Create($"{nameof(the_whenNone)}_{nameof(was_not_invoked)}",
                      assert => assert
                               .Function<FakeExternalState, FakeRight>(WhenNone)
                               .WasNotInvoked());

         /* ------------------------------------------------------------ */
      }
   }
}
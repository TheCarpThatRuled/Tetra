using Tetra.Testing;

namespace Check.OptionEnvironment;

using static Names;
using static AAA_test<Actions, Asserts>;

partial class Steps
{
   partial class TheWhenSome
   {
      public sealed class ForMapWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert was_invoked_once_with
         (
            FakeExternalState expectedExternalState,
            FakeType          expectedContent
         )
            => AtomicAssert
              .Create($"""
                       {nameof(the_whenSome)}_{nameof(was_invoked_once_with)} "{expectedExternalState}", "{expectedContent}"
                       """,
                      assert => assert
                               .Function<FakeExternalState, FakeType, FakeNewType>(WhenSome)
                               .WasInvokedOnce(expectedExternalState,
                                               expectedContent));

         /* ------------------------------------------------------------ */

         public IAssert was_not_invoked()
            => AtomicAssert
              .Create($"{nameof(the_whenSome)}_{nameof(was_not_invoked)}",
                      assert => assert
                               .Function<FakeExternalState, FakeType, FakeNewType>(WhenSome)
                               .WasNotInvoked());

         /* ------------------------------------------------------------ */
      }
   }
}
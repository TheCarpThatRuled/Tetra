using static Check.Names;
using static Tetra.Testing.AAA_test<Check.OptionEnvironment.Actions, Check.OptionEnvironment.Asserts>;

namespace Check.OptionEnvironment;

partial class Steps
{
   partial class TheWhenSome
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
               FakeType          expectedContent
            )
            => AtomicAssert
              .Create($@"{nameof(the_whenSome)}_{nameof(was_invoked_once_with)} ""{expectedExternalState}"", ""{expectedContent}""",
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
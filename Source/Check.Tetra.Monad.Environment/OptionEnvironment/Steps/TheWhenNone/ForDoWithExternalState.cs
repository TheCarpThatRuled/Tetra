using static Check.Names;
using static Tetra.Testing.AAA_test<Check.OptionEnvironment.Actions, Check.OptionEnvironment.Asserts>;

namespace Check.OptionEnvironment;

partial class Steps
{
   partial class TheWhenNone
   {
      public sealed class ForDoWithExternalState
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
                               .Action<FakeExternalState>(WhenNone)
                               .WasInvokedOnce(externalState));

         /* ------------------------------------------------------------ */

         public IAssert was_not_invoked()
            => AtomicAssert
              .Create($"{nameof(the_whenNone)}_{nameof(was_not_invoked)}",
                      assert => assert
                               .Action<FakeExternalState>(WhenNone)
                               .WasNotInvoked());

         /* ------------------------------------------------------------ */
      }
   }
}
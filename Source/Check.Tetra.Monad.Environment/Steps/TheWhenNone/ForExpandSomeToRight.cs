using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenNone
   {
      public sealed class ForExpandSomeToRight
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<ExpandSomeToRightWasCalled.Asserts, ExpandSomeToRightWasCalled.Asserts> was_invoked_once()
            => the_whenNone.function.was_invoked_once<FakeLeft, ExpandSomeToRightWasCalled.Asserts>();

         /* ------------------------------------------------------------ */

         public IAssert<ExpandSomeToRightWasCalled.Asserts, ExpandSomeToRightWasCalled.Asserts> was_not_invoked()
            => the_whenNone.function.was_not_invoked<FakeLeft, ExpandSomeToRightWasCalled.Asserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
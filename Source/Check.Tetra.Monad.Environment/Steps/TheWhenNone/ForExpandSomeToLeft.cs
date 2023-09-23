using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenNone
   {
      public sealed class ForExpandSomeToLeft
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<ExpandSomeToLeftWasCalled.Asserts, ExpandSomeToLeftWasCalled.Asserts> was_invoked_once()
            => the_whenNone.function.was_invoked_once<FakeRight, ExpandSomeToLeftWasCalled.Asserts>();

         /* ------------------------------------------------------------ */

         public IAssert<ExpandSomeToLeftWasCalled.Asserts, ExpandSomeToLeftWasCalled.Asserts> was_not_invoked()
            => the_whenNone.function.was_not_invoked<FakeRight, ExpandSomeToLeftWasCalled.Asserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
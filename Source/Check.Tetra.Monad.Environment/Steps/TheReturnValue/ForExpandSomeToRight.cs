using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheReturnValue
   {
      public sealed class ForExpandSomeToRight
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<ExpandSomeToRightWasCalled.Asserts, ExpandSomeToRightWasCalled.Asserts> is_a_left_containing(FakeLeft expected)
            => the_return_value.is_a_left_containing<FakeLeft, FakeType, ExpandSomeToRightWasCalled.Asserts>(expected);

         /* ------------------------------------------------------------ */

         public IAssert<ExpandSomeToRightWasCalled.Asserts, ExpandSomeToRightWasCalled.Asserts> is_a_right_containing(FakeType expected)
            => the_return_value.is_a_right_containing<FakeLeft, FakeType, ExpandSomeToRightWasCalled.Asserts>(expected);

         /* ------------------------------------------------------------ */
      }
   }
}
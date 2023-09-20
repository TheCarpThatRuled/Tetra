using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenSome
   {
      public sealed class ForDo
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<DoWasCalled.Asserts, DoWasCalled.Asserts> was_invoked_once_with(FakeType expected)
            => the_whenSome.action.was_invoked_once_with<FakeType, DoWasCalled.Asserts>(expected);

         /* ------------------------------------------------------------ */

         public IAssert<DoWasCalled.Asserts, DoWasCalled.Asserts> was_not_invoked()
            => the_whenSome.action.was_not_invoked<FakeType, DoWasCalled.Asserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
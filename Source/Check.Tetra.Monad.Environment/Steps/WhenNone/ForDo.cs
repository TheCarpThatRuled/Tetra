using Tetra.Testing;
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class WhenNone 
   {
      public sealed class ForDo
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<DoWasCalled.Asserts, DoWasCalled.Asserts> was_invoked_once()
            => whenNone.was_invoked_once<DoWasCalled.Asserts>();

         /* ------------------------------------------------------------ */

         public IAssert<DoWasCalled.Asserts, DoWasCalled.Asserts> was_not_invoked()
            => whenNone.was_not_invoked<DoWasCalled.Asserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
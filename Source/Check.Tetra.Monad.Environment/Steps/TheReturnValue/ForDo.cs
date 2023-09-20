using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheReturnValue
   {
      public sealed class ForDo
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<DoWasCalled.Asserts, DoWasCalled.Asserts> is_this()
            => the_return_value.is_this<DoWasCalled.Asserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
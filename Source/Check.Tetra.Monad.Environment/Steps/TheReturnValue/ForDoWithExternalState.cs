using Tetra.Testing;
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheReturnValue
   {
      public sealed class ForDoWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<DoWasCalledWithExternalState.Asserts, DoWasCalledWithExternalState.Asserts> is_this()
            => the_return_value.is_this<DoWasCalledWithExternalState.Asserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
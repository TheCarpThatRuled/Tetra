using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheReturnValue
   {
      partial class ForOption
      {
         public sealed class ForDoWithExternalState
         {
            /* ------------------------------------------------------------ */
            // Assert
            /* ------------------------------------------------------------ */

            public IAssert<TheOptionHasBeenCreated.AndDoWasCalledWithExternalStateAsserts, TheOptionHasBeenCreated.AndDoWasCalledWithExternalStateAsserts> is_this()
               => the_return_value.is_this<TheOptionHasBeenCreated.AndDoWasCalledWithExternalStateAsserts>();

            /* ------------------------------------------------------------ */
         }
      }
   }
}
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheReturnValue
   {
      partial class ForEither
      {
         public sealed class ForDoWithExternalState
         {
            /* ------------------------------------------------------------ */
            // Assert
            /* ------------------------------------------------------------ */

            public IAssert<TheEitherHasBeenCreated.AndDoWasCalledWithExternalStateAsserts, TheEitherHasBeenCreated.AndDoWasCalledWithExternalStateAsserts> is_this()
               => the_return_value.is_this<TheEitherHasBeenCreated.AndDoWasCalledWithExternalStateAsserts>();

            /* ------------------------------------------------------------ */
         }
      }
   }
}
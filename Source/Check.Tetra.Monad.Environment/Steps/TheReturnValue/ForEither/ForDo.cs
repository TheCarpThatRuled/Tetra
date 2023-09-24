using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheReturnValue
   {
      partial class ForEither
      {
         public sealed class ForDo
         {
            /* ------------------------------------------------------------ */
            // Assert
            /* ------------------------------------------------------------ */

            public IAssert<TheEitherHasBeenCreated.AndDoWasCalledAsserts, TheEitherHasBeenCreated.AndDoWasCalledAsserts> is_this()
               => the_return_value.is_this<TheEitherHasBeenCreated.AndDoWasCalledAsserts>();

            /* ------------------------------------------------------------ */
         }
      }
   }
}
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheReturnValue
   {
      public sealed class ForAFactory
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<TheOptionHasBeenCreated.Asserts, TheOptionHasBeenCreated.Asserts> is_a_none()
            => the_return_value.is_a_none<FakeType, TheOptionHasBeenCreated.Asserts>();

         /* ------------------------------------------------------------ */

         public IAssert<TheOptionHasBeenCreated.Asserts, TheOptionHasBeenCreated.Asserts> is_a_some_containing(FakeType expected)
            => the_return_value.is_a_some_containing<FakeType, TheOptionHasBeenCreated.Asserts>(expected);

         /* ------------------------------------------------------------ */
      }
   }
}
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheReturnValue
   {
      public sealed class ForMapToOption
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<MapToOptionWasCalled.Asserts, MapToOptionWasCalled.Asserts> is_a_none()
            => the_return_value.is_a_none<FakeNewType, MapToOptionWasCalled.Asserts>();

         /* ------------------------------------------------------------ */

         public IAssert<MapToOptionWasCalled.Asserts, MapToOptionWasCalled.Asserts> is_a_some_containing(FakeNewType expected)
            => the_return_value.is_a_some_containing<FakeNewType, MapToOptionWasCalled.Asserts>(expected);

         /* ------------------------------------------------------------ */
      }
   }
}
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheReturnValue
   {
      public sealed class ForMap
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<MapWasCalled.Asserts, MapWasCalled.Asserts> is_a_none()
            => the_return_value.is_a_none<FakeNewType, MapWasCalled.Asserts>();

         /* ------------------------------------------------------------ */

         public IAssert<MapWasCalled.Asserts, MapWasCalled.Asserts> is_a_some_containing(FakeNewType expected)
            => the_return_value.is_a_some_containing<FakeNewType, MapWasCalled.Asserts>(expected);

         /* ------------------------------------------------------------ */
      }
   }
}
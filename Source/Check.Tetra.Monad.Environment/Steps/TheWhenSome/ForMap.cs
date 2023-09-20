using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenSome
   {
      public sealed class ForMap
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<MapWasCalled.Asserts, MapWasCalled.Asserts> was_invoked_once_with(FakeType expected)
            => the_whenSome.function.was_invoked_once_with<FakeType, FakeNewType, MapWasCalled.Asserts>(expected);

         /* ------------------------------------------------------------ */

         public IAssert<MapWasCalled.Asserts, MapWasCalled.Asserts> was_not_invoked()
            => the_whenSome.function.was_not_invoked<FakeType, FakeNewType, MapWasCalled.Asserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
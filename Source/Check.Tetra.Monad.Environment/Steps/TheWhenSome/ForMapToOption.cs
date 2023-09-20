using Tetra;
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenSome
   {
      public sealed class ForMapToOption
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<MapToOptionWasCalled.Asserts, MapToOptionWasCalled.Asserts> was_invoked_once_with(FakeType expected)
            => the_whenSome.function.was_invoked_once_with<FakeType, IOption<FakeNewType>, MapToOptionWasCalled.Asserts>(expected);

         /* ------------------------------------------------------------ */

         public IAssert<MapToOptionWasCalled.Asserts, MapToOptionWasCalled.Asserts> was_not_invoked()
            => the_whenSome.function.was_not_invoked<FakeType, IOption<FakeNewType>, MapToOptionWasCalled.Asserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
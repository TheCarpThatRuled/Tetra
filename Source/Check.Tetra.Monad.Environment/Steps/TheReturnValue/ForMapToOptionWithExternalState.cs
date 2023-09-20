using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheReturnValue
   {
      public sealed class ForMapToOptionWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<MapToOptionWasCalledWithExternalState.Asserts, MapToOptionWasCalledWithExternalState.Asserts> is_a_none()
            => the_return_value.is_a_none<FakeNewType, MapToOptionWasCalledWithExternalState.Asserts>();

         /* ------------------------------------------------------------ */

         public IAssert<MapToOptionWasCalledWithExternalState.Asserts, MapToOptionWasCalledWithExternalState.Asserts> is_a_some_containing(FakeNewType expected)
            => the_return_value.is_a_some_containing<FakeNewType, MapToOptionWasCalledWithExternalState.Asserts>(expected);

         /* ------------------------------------------------------------ */
      }
   }
}
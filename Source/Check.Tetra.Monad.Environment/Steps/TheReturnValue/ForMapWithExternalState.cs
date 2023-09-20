using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheReturnValue
   {
      public sealed class ForMapWithExternalState
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<MapWasCalledWithExternalState.Asserts, MapWasCalledWithExternalState.Asserts> is_a_none()
            => the_return_value.is_a_none<FakeNewType, MapWasCalledWithExternalState.Asserts>();

         /* ------------------------------------------------------------ */

         public IAssert<MapWasCalledWithExternalState.Asserts, MapWasCalledWithExternalState.Asserts> is_a_some_containing(FakeNewType expected)
            => the_return_value.is_a_some_containing<FakeNewType, MapWasCalledWithExternalState.Asserts>(expected);

         /* ------------------------------------------------------------ */
      }
   }
}
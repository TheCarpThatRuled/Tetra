using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenSome
   {
      public sealed class ForReduce
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<ReduceWasCalled.Asserts, ReduceWasCalled.Asserts> was_invoked_once_with(FakeType expected)
            => the_whenSome.function.was_invoked_once_with<FakeType, FakeNewType, ReduceWasCalled.Asserts>(expected);

         /* ------------------------------------------------------------ */

         public IAssert<ReduceWasCalled.Asserts, ReduceWasCalled.Asserts> was_not_invoked()
            => the_whenSome.function.was_not_invoked<FakeType, FakeNewType, ReduceWasCalled.Asserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
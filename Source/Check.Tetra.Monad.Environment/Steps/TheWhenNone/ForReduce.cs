using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenNone 
   {
      public sealed class ForReduce
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<ReduceWasCalled.Asserts, ReduceWasCalled.Asserts> was_invoked_once()
            => the_whenNone.function.was_invoked_once<FakeNewType, ReduceWasCalled.Asserts>();

         /* ------------------------------------------------------------ */

         public IAssert<ReduceWasCalled.Asserts, ReduceWasCalled.Asserts> was_not_invoked()
            => the_whenNone.function.was_not_invoked<FakeNewType, ReduceWasCalled.Asserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
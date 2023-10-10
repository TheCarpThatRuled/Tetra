using Tetra.Testing;
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenRight
   {
      private sealed class Function
      {
         /* ------------------------------------------------------------ */
         // Asserts
         /* ------------------------------------------------------------ */

         public IAssert<TAsserts, TAsserts> was_invoked_once_with<T, TReturn, TAsserts>
         (
            T expected
         )
            where TAsserts : IAsserts, IWhenRightFuncAsserts<T, TReturn, TAsserts>
            => AtomicAssert<TAsserts, TAsserts>
              .Create($@"{nameof(the_whenRight)}_{nameof(was_invoked_once_with)} ""{expected}""",
                      assert => assert
                               .WhenRight()
                               .WasInvokedOnce(expected));

         /* ------------------------------------------------------------ */

         public IAssert<TAsserts, TAsserts> was_invoked_once_with<T0, T1, TReturn, TAsserts>
         (
            T0 expectedArg0,
            T1 expectedArg1
         )
            where TAsserts : IAsserts, IWhenRightFuncAsserts<T0, T1, TReturn, TAsserts>
            => AtomicAssert<TAsserts, TAsserts>
              .Create($@"{nameof(the_whenRight)}_{nameof(was_invoked_once_with)} ""{expectedArg0}"", ""{expectedArg1}""",
                      assert => assert
                               .WhenRight()
                               .WasInvokedOnce(expectedArg0,
                                               expectedArg1));

         /* ------------------------------------------------------------ */

         public IAssert<TAsserts, TAsserts> was_not_invoked<T, TReturn, TAsserts>()
            where TAsserts : IAsserts, IWhenRightFuncAsserts<T, TReturn, TAsserts>
            => AtomicAssert<TAsserts, TAsserts>
              .Create($"{nameof(the_whenRight)}_{nameof(was_not_invoked)}",
                      assert => assert
                               .WhenRight()
                               .WasNotInvoked());

         /* ------------------------------------------------------------ */

         public IAssert<TAsserts, TAsserts> was_not_invoked<T0, T1, TReturn, TAsserts>()
            where TAsserts : IAsserts, IWhenRightFuncAsserts<T0, T1, TReturn, TAsserts>
            => AtomicAssert<TAsserts, TAsserts>
              .Create($"{nameof(the_whenRight)}_{nameof(was_not_invoked)}",
                      assert => assert
                               .WhenRight()
                               .WasNotInvoked());

         /* ------------------------------------------------------------ */
      }
   }
}
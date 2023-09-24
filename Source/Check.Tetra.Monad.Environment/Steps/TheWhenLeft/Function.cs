using Tetra.Testing;
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenLeft
   {
      private sealed class Function
      {
         /* ------------------------------------------------------------ */
         // Asserts
         /* ------------------------------------------------------------ */

         public IAssert<TAsserts, TAsserts> was_invoked_once_with<T, TReturn, TAsserts>(T expected)
            where TAsserts : IAsserts, IWhenLeftFuncAsserts<T, TReturn, TAsserts>
            => AtomicAssert<TAsserts, TAsserts>
              .Create($@"{nameof(the_whenLeft)}_{nameof(was_invoked_once_with)} ""{expected}""",
                      assert => assert
                               .WhenLeft()
                               .WasInvokedOnce(expected));

         /* ------------------------------------------------------------ */

         public IAssert<TAsserts, TAsserts> was_invoked_once_with<T0, T1, TReturn, TAsserts>(T0 expectedArg0,
                                                                                             T1 expectedArg1)
            where TAsserts : IAsserts, IWhenLeftFuncAsserts<T0, T1, TReturn, TAsserts>
            => AtomicAssert<TAsserts, TAsserts>
              .Create($@"{nameof(the_whenLeft)}_{nameof(was_invoked_once_with)} ""{expectedArg0}"", ""{expectedArg1}""",
                      assert => assert
                               .WhenLeft()
                               .WasInvokedOnce(expectedArg0,
                                               expectedArg1));

         /* ------------------------------------------------------------ */

         public IAssert<TAsserts, TAsserts> was_not_invoked<T, TReturn, TAsserts>()
            where TAsserts : IAsserts, IWhenLeftFuncAsserts<T, TReturn, TAsserts>
            => AtomicAssert<TAsserts, TAsserts>
              .Create($"{nameof(the_whenLeft)}_{nameof(was_not_invoked)}",
                      assert => assert
                               .WhenLeft()
                               .WasNotInvoked());

         /* ------------------------------------------------------------ */

         public IAssert<TAsserts, TAsserts> was_not_invoked<T0, T1, TReturn, TAsserts>()
            where TAsserts : IAsserts, IWhenLeftFuncAsserts<T0, T1, TReturn, TAsserts>
            => AtomicAssert<TAsserts, TAsserts>
              .Create($"{nameof(the_whenLeft)}_{nameof(was_not_invoked)}",
                      assert => assert
                               .WhenLeft()
                               .WasNotInvoked());

         /* ------------------------------------------------------------ */
      }
   }
}
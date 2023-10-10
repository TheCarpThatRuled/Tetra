using Tetra.Testing;
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenNone
   {
      private sealed class Function
      {
         /* ------------------------------------------------------------ */
         // Asserts
         /* ------------------------------------------------------------ */

         public IAssert<TAsserts, TAsserts> was_invoked_once<TReturn, TAsserts>()
            where TAsserts : IAsserts, IWhenNoneFuncAsserts<TReturn, TAsserts>
            => AtomicAssert<TAsserts, TAsserts>
              .Create($@"{nameof(the_whenNone)}_{nameof(was_invoked_once)}",
                      assert => assert
                               .WhenNone()
                               .WasInvokedOnce());

         /* ------------------------------------------------------------ */

         public IAssert<TAsserts, TAsserts> was_invoked_once_with<T, TReturn, TAsserts>
         (
            T expected
         )
            where TAsserts : IAsserts, IWhenNoneFuncAsserts<T, TReturn, TAsserts>
            => AtomicAssert<TAsserts, TAsserts>
              .Create($@"{nameof(the_whenNone)}_{nameof(was_invoked_once_with)} ""{expected}""",
                      assert => assert
                               .WhenNone()
                               .WasInvokedOnce(expected));

         /* ------------------------------------------------------------ */

         public IAssert<TAsserts, TAsserts> was_not_invoked<TReturn, TAsserts>()
            where TAsserts : IAsserts, IWhenNoneFuncAsserts<TReturn, TAsserts>
            => AtomicAssert<TAsserts, TAsserts>
              .Create($"{nameof(the_whenNone)}_{nameof(was_not_invoked)}",
                      assert => assert
                               .WhenNone()
                               .WasNotInvoked());

         /* ------------------------------------------------------------ */

         public IAssert<TAsserts, TAsserts> was_not_invoked<T, TReturn, TAsserts>()
            where TAsserts : IAsserts, IWhenNoneFuncAsserts<T, TReturn, TAsserts>
            => AtomicAssert<TAsserts, TAsserts>
              .Create($"{nameof(the_whenNone)}_{nameof(was_not_invoked)}",
                      assert => assert
                               .WhenNone()
                               .WasNotInvoked());

         /* ------------------------------------------------------------ */
      }
   }
}
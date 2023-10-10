using Tetra.Testing;
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenNone
   {
      private sealed class Action
      {
         /* ------------------------------------------------------------ */
         // Asserts
         /* ------------------------------------------------------------ */

         public IAssert<TAsserts, TAsserts> was_invoked_once<TAsserts>()
            where TAsserts : IAsserts, IWhenNoneActionAsserts<TAsserts>
            => AtomicAssert<TAsserts, TAsserts>
              .Create($"{nameof(the_whenNone)}_{nameof(was_invoked_once)}",
                      assert => assert
                               .WhenNone()
                               .WasInvokedOnce());

         /* ------------------------------------------------------------ */

         public IAssert<TAsserts, TAsserts> was_invoked_once_with<T, TAsserts>
         (
            T expected
         )
            where TAsserts : IAsserts, IWhenNoneActionAsserts<T, TAsserts>
            => AtomicAssert<TAsserts, TAsserts>
              .Create($@"{nameof(the_whenNone)}_{nameof(was_invoked_once_with)} ""{expected}""",
                      assert => assert
                               .WhenNone()
                               .WasInvokedOnce(expected));

         /* ------------------------------------------------------------ */

         public IAssert<TAsserts, TAsserts> was_not_invoked<TAsserts>()
            where TAsserts : IAsserts, IWhenNoneActionAsserts<TAsserts>
            => AtomicAssert<TAsserts, TAsserts>
              .Create($"{nameof(the_whenNone)}_{nameof(was_not_invoked)}",
                      assert => assert
                               .WhenNone()
                               .WasNotInvoked());

         /* ------------------------------------------------------------ */

         public IAssert<TAsserts, TAsserts> was_not_invoked<T, TAsserts>()
            where TAsserts : IAsserts, IWhenNoneActionAsserts<T, TAsserts>
            => AtomicAssert<TAsserts, TAsserts>
              .Create($"{nameof(the_whenNone)}_{nameof(was_not_invoked)}",
                      assert => assert
                               .WhenNone()
                               .WasNotInvoked());

         /* ------------------------------------------------------------ */
      }
   }
}
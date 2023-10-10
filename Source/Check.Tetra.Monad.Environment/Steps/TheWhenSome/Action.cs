﻿using Tetra.Testing;
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenSome
   {
      private sealed class Action
      {
         /* ------------------------------------------------------------ */
         // Asserts
         /* ------------------------------------------------------------ */

         public IAssert<TAsserts, TAsserts> was_invoked_once_with<T, TAsserts>
         (
            T expected
         )
            where TAsserts : IAsserts, IWhenSomeActionAsserts<T, TAsserts>
            => AtomicAssert<TAsserts, TAsserts>
              .Create($@"{nameof(the_whenSome)}_{nameof(was_invoked_once_with)} ""{expected}""",
                      assert => assert
                               .WhenSome()
                               .WasInvokedOnce(expected));

         /* ------------------------------------------------------------ */

         public IAssert<TAsserts, TAsserts> was_invoked_once_with<T0, T1, TAsserts>
         (
            T0 expectedArg0,
            T1 expectedArg1
         )
            where TAsserts : IAsserts, IWhenSomeActionAsserts<T0, T1, TAsserts>
            => AtomicAssert<TAsserts, TAsserts>
              .Create($@"{nameof(the_whenSome)}_{nameof(was_invoked_once_with)} ""{expectedArg0}"", ""{expectedArg1}""",
                      assert => assert
                               .WhenSome()
                               .WasInvokedOnce(expectedArg0,
                                               expectedArg1));

         /* ------------------------------------------------------------ */

         public IAssert<TAsserts, TAsserts> was_not_invoked<T, TAsserts>()
            where TAsserts : IAsserts, IWhenSomeActionAsserts<T, TAsserts>
            => AtomicAssert<TAsserts, TAsserts>
              .Create($"{nameof(the_whenSome)}_{nameof(was_not_invoked)}",
                      assert => assert
                               .WhenSome()
                               .WasNotInvoked());

         /* ------------------------------------------------------------ */

         public IAssert<TAsserts, TAsserts> was_not_invoked<T0, T1, TAsserts>()
            where TAsserts : IAsserts, IWhenSomeActionAsserts<T0, T1, TAsserts>
            => AtomicAssert<TAsserts, TAsserts>
              .Create($"{nameof(the_whenSome)}_{nameof(was_not_invoked)}",
                      assert => assert
                               .WhenSome()
                               .WasNotInvoked());

         /* ------------------------------------------------------------ */
      }
   }
}
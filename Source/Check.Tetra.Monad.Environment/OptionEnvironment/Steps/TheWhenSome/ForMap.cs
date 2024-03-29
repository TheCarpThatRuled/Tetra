﻿using Tetra.Testing;

namespace Check.OptionEnvironment;

using static Names;
using static AAA_test<Actions, Asserts>;

partial class Steps
{
   partial class TheWhenSome
   {
      public sealed class ForMap
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert was_invoked_once_with
         (
            FakeType expected
         )
            => AtomicAssert
              .Create($"""
                       {nameof(the_whenSome)}_{nameof(was_invoked_once_with)} "{expected}"
                       """,
                      assert => assert
                               .Function<FakeType, FakeNewType>(WhenSome)
                               .WasInvokedOnce(expected));

         /* ------------------------------------------------------------ */

         public IAssert was_not_invoked()
            => AtomicAssert
              .Create($"{nameof(the_whenSome)}_{nameof(was_not_invoked)}",
                      assert => assert
                               .Function<FakeType, FakeNewType>(WhenSome)
                               .WasNotInvoked());

         /* ------------------------------------------------------------ */
      }
   }
}
﻿using static Check.Names;
using static Tetra.Testing.AAA_test<Check.OptionEnvironment.Actions, Check.OptionEnvironment.Asserts>;

namespace Check.OptionEnvironment;

partial class Steps
{
   partial class TheWhenNone
   {
      public sealed class ForExpandSomeToLeft
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert was_invoked_once()
            => AtomicAssert
              .Create($"{nameof(the_whenNone)}_{nameof(was_invoked_once)}",
                      assert => assert
                               .Function<FakeRight>(WhenNone)
                               .WasInvokedOnce());

         /* ------------------------------------------------------------ */

         public IAssert was_not_invoked()
            => AtomicAssert
              .Create($"{nameof(the_whenNone)}_{nameof(was_not_invoked)}",
                      assert => assert
                               .Function<FakeRight>(WhenNone)
                               .WasNotInvoked());

         /* ------------------------------------------------------------ */
      }
   }
}
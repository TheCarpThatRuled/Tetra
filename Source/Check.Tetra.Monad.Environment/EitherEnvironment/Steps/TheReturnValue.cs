
using Tetra.Testing;

namespace Check.EitherEnvironment;

using static AAA_test<Actions, Asserts>;

partial class Steps
{
   public sealed class TheReturnValue
   {

      // ReSharper disable once InconsistentNaming
      public IAssert is_equal_to<T>
      (
         T expected
      )
         => AtomicAssert
           .Create($"{nameof(the_return_value)}_{nameof(is_equal_to)} {expected}",
                   asserts => asserts
                             .Returns<T>()
                             .IsEqualTo(expected));

      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public IAssert is_false()
         => AtomicAssert
           .Create($"{nameof(the_return_value)}_{nameof(is_false)}",
                   asserts => asserts
                             .ReturnsABoolean()
                             .IsFalse());

      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public IAssert is_a_left_containing<TLeft, TRight>
      (
         TLeft expected
      )
         => AtomicAssert
           .Create($"{nameof(the_return_value)}_{nameof(is_a_left_containing)} {expected}",
                   asserts => asserts
                             .ReturnsAnEither<TLeft, TRight>()
                             .IsALeft(expected));

      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public IAssert is_a_none<T>()
         => AtomicAssert
           .Create($"{nameof(the_return_value)}_{nameof(is_a_none)}",
                   asserts => asserts
                             .ReturnsAnOption<T>()
                             .IsANone());

      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public IAssert is_a_right_containing<TLeft, TRight>
      (
         TRight expected
      )
         => AtomicAssert
           .Create($"{nameof(the_return_value)}_{nameof(is_a_right_containing)} {expected}",
                   asserts => asserts
                             .ReturnsAnEither<TLeft, TRight>()
                             .IsARight(expected));

      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public IAssert is_a_some_containing<T>
      (
         T expected
      )
         => AtomicAssert
           .Create($"{nameof(the_return_value)}_{nameof(is_a_some_containing)} {expected}",
                   asserts => asserts
                             .ReturnsAnOption<T>()
                             .IsASome(expected));

      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public IAssert is_this()
         => AtomicAssert
           .Create($"{nameof(the_return_value)}_{nameof(is_this)}",
                   asserts => asserts
                             .ReturnsThis()
                             .AreReferenceEqual());

      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public IAssert is_true()
         => AtomicAssert
           .Create($"{nameof(the_return_value)}_{nameof(is_true)}",
                   asserts => asserts
                             .ReturnsABoolean()
                             .IsTrue());

      /* ------------------------------------------------------------ */
   }
}
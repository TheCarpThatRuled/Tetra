// ReSharper disable InconsistentNaming

using Tetra;
using static Tetra.Testing.AAA_test<Check.Actions, Check.Asserts>;

namespace Check;

partial class Steps
{
   public sealed class TheReturnValue
   {
      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal TheReturnValue() { }

      /* ------------------------------------------------------------ */
      // Asserts
      /* ------------------------------------------------------------ */

      public IAssert Is<T>
      (
         T expected
      )
         => AtomicAssert
           .Create($"{nameof(the_return_value)}.{nameof(Is)}: {expected}",
                   environment => environment
                                 .Returns<T>()
                                 .IsEqualTo(expected));

      /* ------------------------------------------------------------ */

      public IAssert Is_not_in_error<T>()
         => AtomicAssert
           .Create($"{nameof(the_return_value)}.{nameof(Is_not_in_error)}",
                   environment => environment
                                 .ReturnsAnOption<T>()
                                 .IsANone());

      /* ------------------------------------------------------------ */

      public IAssert Is_in_error
      (
         Message expected
      )
         => AtomicAssert
           .Create($"{nameof(the_return_value)}.{nameof(Is_in_error)}: {expected}",
                   environment => environment
                                 .ReturnsAnOption<Message>()
                                 .IsASome(expected));

      /* ------------------------------------------------------------ */

      public IAssert Is_in_error
      (
         Func<Message, bool> predicate
      )
         => AtomicAssert
           .Create($"{nameof(the_return_value)}.{nameof(Is_in_error)}: {nameof(predicate)}",
                   environment => environment
                                 .ReturnsAnOption<Message>()
                                 .IsASomeAnd(predicate));

      /* ------------------------------------------------------------ */
   }
}
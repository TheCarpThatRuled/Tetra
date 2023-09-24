// ReSharper disable InconsistentNaming

using Tetra;
using Tetra.Testing;

namespace Check;

public static class The_return_value
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static AAA_test.IAssert<ObjectAsserts<T, Asserts>, Asserts> Is<T>(T expected)
      => AAA_test
        .AtomicAssert<ObjectAsserts<T, Asserts>, Asserts>
        .Create($"{nameof(The_return_value)}.{nameof(Is)}: {expected}",
                environment => environment.IsEqualTo(expected));

   /* ------------------------------------------------------------ */

   public static AAA_test.IAssert<OptionAsserts<Message, Asserts>, Asserts> Is_not_in_error()
      => AAA_test
        .AtomicAssert<OptionAsserts<Message, Asserts>, Asserts>
        .Create($"{nameof(The_return_value)}.{nameof(Is_not_in_error)}",
                environment => environment.IsANone());

   /* ------------------------------------------------------------ */

   public static AAA_test.IAssert<OptionAsserts<Message, Asserts>, Asserts> Is_in_error(Message expected)
      => AAA_test
        .AtomicAssert<OptionAsserts<Message, Asserts>, Asserts>
        .Create($"{nameof(The_return_value)}.{nameof(Is_in_error)}: {expected}",
                environment => environment.IsASome(expected));

   /* ------------------------------------------------------------ */

   public static AAA_test.IAssert<OptionAsserts<Message, Asserts>, Asserts> Is_in_error(Func<Message, bool> predicate)
      => AAA_test
        .AtomicAssert<OptionAsserts<Message, Asserts>, Asserts>
        .Create($"{nameof(The_return_value)}.{nameof(Is_in_error)}: {nameof(predicate)}",
                environment => environment.IsASomeAnd(predicate));

   /* ------------------------------------------------------------ */
}
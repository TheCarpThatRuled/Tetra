// ReSharper disable InconsistentNaming

using Tetra;
using Tetra.Testing;

namespace Check;

public static class The_return_value
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static AAA_test.IAssert<ReturnAsserts<T, Asserts>, Asserts> Is<T>(T expected)
      => AAA_test
        .AtomicAssert<ReturnAsserts<T, Asserts>, Asserts>
        .Create(environment => environment.The_return_value_was(expected),
                $"{nameof(The_return_value)}.{nameof(Is)}: {expected}");

   /* ------------------------------------------------------------ */

   public static AAA_test.IAssert<ResultAsserts<Message, Asserts>, Asserts> Is_not_in_error()
      => AAA_test
        .AtomicAssert<ResultAsserts<Message, Asserts>, Asserts>
        .Create(environment => environment.The_returned_value_was_not_in_error(),
                $"{nameof(The_return_value)}.{nameof(Is_not_in_error)}");

   /* ------------------------------------------------------------ */

   public static AAA_test.IAssert<ResultAsserts<Message, Asserts>, Asserts> Is_in_error(Message expected)
      => AAA_test
        .AtomicAssert<ResultAsserts<Message, Asserts>, Asserts>
        .Create(environment => environment.The_returned_value_was_in_error(expected),
                $"{nameof(The_return_value)}.{nameof(Is_in_error)}: {expected}");

   /* ------------------------------------------------------------ */

   public static AAA_test.IAssert<ResultAsserts<Message, Asserts>, Asserts> Is_in_error(Func<Message, bool> predicate)
      => AAA_test
        .AtomicAssert<ResultAsserts<Message, Asserts>, Asserts>
        .Create(environment => environment.The_returned_value_was_in_error(predicate),
                $"{nameof(The_return_value)}.{nameof(Is_in_error)}: {nameof(predicate)}");

   /* ------------------------------------------------------------ */
}
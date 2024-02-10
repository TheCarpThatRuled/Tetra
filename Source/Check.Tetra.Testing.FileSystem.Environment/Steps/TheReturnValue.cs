// ReSharper disable InconsistentNaming

using Tetra;
using static Tetra.Testing.AAA_property_test<Check.Actions, Check.Asserts>;
using static Tetra.Testing.AAA_property_test;

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

      public IAssert @is<T>
      (
         Parameter<T> expected
      )
         => AtomicAssert
           .Create($"{nameof(the_return_value)}.{nameof(@is)}: {expected}",
                   (
                      parameters,
                      environment
                   ) => environment
                       .Returns<T>()
                       .IsEqualTo(parameters.Retrieve(expected)));

      /* ------------------------------------------------------------ */

      public IAssert is_false()
         => AtomicAssert
           .Create($"{nameof(the_return_value)}.{nameof(is_false)}",
                   (
                      _,
                      environment
                   ) => environment
                       .ReturnsABoolean()
                       .IsFalse());

      /* ------------------------------------------------------------ */

      public IAssert is_true()
         => AtomicAssert
           .Create($"{nameof(the_return_value)}.{nameof(is_true)}",
                   (
                      _,
                      environment
                   ) => environment
                       .ReturnsABoolean()
                       .IsTrue());

      /* ------------------------------------------------------------ */

      public IAssert is_not_in_error<T>()
         => AtomicAssert
           .Create($"{nameof(the_return_value)}.{nameof(is_not_in_error)}",
                   (
                      _,
                      environment
                   ) => environment
                       .ReturnsAnOption<T>()
                       .IsANone());

      /* ------------------------------------------------------------ */

      public IAssert Is_in_error
      (
         Parameter<Message> expected
      )
         => AtomicAssert
           .Create($"{nameof(the_return_value)}.{nameof(Is_in_error)}: {expected}",
                   (
                      parameters,
                      environment
                   ) => environment
                       .ReturnsAnOption<Message>()
                       .IsASome(parameters.Retrieve(expected)));

      /* ------------------------------------------------------------ */

      public IAssert Is_in_error
      (
         Func<Message, bool> predicate
      )
         => AtomicAssert
           .Create($"{nameof(the_return_value)}.{nameof(Is_in_error)}: {nameof(predicate)}",
                   (
                      _,
                      environment
                   ) => environment
                       .ReturnsAnOption<Message>()
                       .IsASomeAnd(predicate));

      /* ------------------------------------------------------------ */
   }
}
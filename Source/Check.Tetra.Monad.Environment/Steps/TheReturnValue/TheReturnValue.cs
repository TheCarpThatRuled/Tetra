using Tetra.Testing;
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   public sealed partial class TheReturnValue
   {
      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public ForOption for_Option { get; } = new();

      /* ------------------------------------------------------------ */
      // Assert
      /* ------------------------------------------------------------ */

      public IAssert<BooleanAsserts<TestTerminus>, TestTerminus> is_false()
         => AtomicAssert<BooleanAsserts<TestTerminus>, TestTerminus>
           .Create($"{nameof(the_return_value)}_{nameof(is_false)}",
                   assert => assert.IsFalse());

      /* ------------------------------------------------------------ */

      public IAssert<EitherAsserts<TLeft, TRight, TestTerminus>, TestTerminus> is_a_left_containing<TLeft, TRight>(TLeft expected)
         => AtomicAssert<EitherAsserts<TLeft, TRight, TestTerminus>, TestTerminus>
           .Create($@"{nameof(the_return_value)}_{nameof(is_a_left_containing)} ""{expected}""",
                   assert => assert.IsALeft(expected));

      /* ------------------------------------------------------------ */

      public IAssert<OptionAsserts<T, TestTerminus>, TestTerminus> is_a_none<T>()
         => AtomicAssert<OptionAsserts<T, TestTerminus>, TestTerminus>
           .Create($"{nameof(the_return_value)}_{nameof(is_a_none)}",
                   assert => assert.IsANone());

      /* ------------------------------------------------------------ */

      public IAssert<EitherAsserts<TLeft, TRight, TestTerminus>, TestTerminus> is_a_right_containing<TLeft, TRight>(TRight expected)
         => AtomicAssert<EitherAsserts<TLeft, TRight, TestTerminus>, TestTerminus>
           .Create($@"{nameof(the_return_value)}_{nameof(is_a_right_containing)} ""{expected}""",
                   assert => assert.IsARight(expected));

      /* ------------------------------------------------------------ */

      public IAssert<OptionAsserts<T, TestTerminus>, TestTerminus> is_a_some_containing<T>(T expected)
         => AtomicAssert<OptionAsserts<T, TestTerminus>, TestTerminus>
           .Create($@"{nameof(the_return_value)}_{nameof(is_a_some_containing)} ""{expected}""",
                   assert => assert.IsASome(expected));

      /* ------------------------------------------------------------ */

      public IAssert<BooleanAsserts<TestTerminus>, TestTerminus> is_true()
         => AtomicAssert<BooleanAsserts<TestTerminus>, TestTerminus>
           .Create($"{nameof(the_return_value)}_{nameof(is_true)}",
                   assert => assert.IsTrue());

      /* ------------------------------------------------------------ */
      // Private Assert
      /* ------------------------------------------------------------ */

      public IAssert<ObjectAsserts<T, TestTerminus>, TestTerminus> is_equal_to<T>(T expected)
         => AtomicAssert<ObjectAsserts<T, TestTerminus>, TestTerminus>
           .Create($@"{nameof(the_return_value)}_{nameof(is_equal_to)} ""{expected}""",
                   assert => assert
                     .IsEqualTo(expected));

      /* ------------------------------------------------------------ */

      public IAssert<TAsserts, TAsserts> is_equal_to<T, TAsserts>(T expected)
         where TAsserts : IAsserts, IReturnsAsserts<T, TAsserts>
         => AtomicAssert<TAsserts, TAsserts>
           .Create($@"{nameof(the_return_value)}_{nameof(is_equal_to)} ""{expected}""",
                   assert => assert
                            .ReturnValue()
                            .IsEqualTo(expected));

      /* ------------------------------------------------------------ */

      private IAssert<TAsserts, TAsserts> is_this<TAsserts>()
         where TAsserts : IAsserts, IReturnsThisAsserts<TAsserts>
         => AtomicAssert<TAsserts, TAsserts>
           .Create($"{nameof(the_return_value)}_{nameof(is_this)}",
                   assert => assert
                            .ReturnValue()
                            .AreReferenceEqual());

      /* ------------------------------------------------------------ */

      private IAssert<TAsserts, TAsserts> is_a_left_containing<TLeft, TRight, TAsserts>(TLeft expected)
         where TAsserts : IAsserts, IReturnsAnEitherAsserts<TLeft, TRight, TAsserts>
         => AtomicAssert<TAsserts, TAsserts>
           .Create($@"{nameof(the_return_value)}_{nameof(is_a_left_containing)} ""{expected}""",
                   assert => assert
                            .ReturnValue()
                            .IsALeft(expected));

      /* ------------------------------------------------------------ */

      private IAssert<TAsserts, TAsserts> is_a_none<T, TAsserts>()
         where TAsserts : IAsserts, IReturnsAnOptionAsserts<T, TAsserts>
         => AtomicAssert<TAsserts, TAsserts>
           .Create($"{nameof(the_return_value)}_{nameof(is_a_none)}",
                   assert => assert
                            .ReturnValue()
                            .IsANone());

      /* ------------------------------------------------------------ */

      private IAssert<TAsserts, TAsserts> is_a_right_containing<TLeft, TRight, TAsserts>(TRight expected)
         where TAsserts : IAsserts, IReturnsAnEitherAsserts<TLeft, TRight, TAsserts>
         => AtomicAssert<TAsserts, TAsserts>
           .Create($@"{nameof(the_return_value)}_{nameof(is_a_right_containing)} ""{expected}""",
                   assert => assert
                            .ReturnValue()
                            .IsARight(expected));

      /* ------------------------------------------------------------ */

      private IAssert<TAsserts, TAsserts> is_a_some_containing<T, TAsserts>(T expected)
         where TAsserts : IAsserts, IReturnsAnOptionAsserts<T, TAsserts>
         => AtomicAssert<TAsserts, TAsserts>
           .Create($@"{nameof(the_return_value)}_{nameof(is_a_some_containing)} ""{expected}""",
                   assert => assert
                            .ReturnValue()
                            .IsASome(expected));

      /* ------------------------------------------------------------ */
   }
}
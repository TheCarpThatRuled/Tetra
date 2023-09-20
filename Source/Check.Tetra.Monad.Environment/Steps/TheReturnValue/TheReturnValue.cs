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
      public ForAFactory for_a_factory { get; } = new();

      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public ForDo for_Do { get; } = new();

      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public ForDoWithExternalState for_Do_with_externalState { get; } = new();

      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public ForMap for_Map { get; } = new();

      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public ForMapToOption for_Map_to_IOption { get; } = new();

      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public ForMapToOptionWithExternalState for_Map_to_IOption_with_externalState { get; } = new();

      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public ForMapWithExternalState for_Map_with_externalState { get; } = new();

      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public ForReduce for_Reduce { get; } = new();

      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public ForReduceWithExternalState for_Reduce_with_externalState { get; } = new();

      /* ------------------------------------------------------------ */
      // Assert
      /* ------------------------------------------------------------ */

      public IAssert<BooleanAsserts<TestTerminus>, TestTerminus> is_false()
         => AtomicAssert<BooleanAsserts<TestTerminus>, TestTerminus>
           .Create($"{nameof(the_return_value)}_{nameof(is_false)}",
                   assert => assert.IsFalse());

      /* ------------------------------------------------------------ */

      public IAssert<BooleanAsserts<TestTerminus>, TestTerminus> is_true()
         => AtomicAssert<BooleanAsserts<TestTerminus>, TestTerminus>
           .Create($"{nameof(the_return_value)}_{nameof(is_true)}",
                   assert => assert.IsTrue());

      /* ------------------------------------------------------------ */
      // Private Assert
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

      private IAssert<TAsserts, TAsserts> is_a_none<T, TAsserts>()
         where TAsserts : IAsserts, IReturnsAnOptionAsserts<T, TAsserts>
         => AtomicAssert<TAsserts, TAsserts>
           .Create($"{nameof(the_return_value)}_{nameof(is_a_none)}",
                   assert => assert
                            .ReturnValue()
                            .IsANone());

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
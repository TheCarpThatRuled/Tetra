using Tetra.Testing;
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   public sealed partial class TheReturnValue
   { /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public ForDo for_Do { get; } = new();

      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public ForDoWithExternalState for_Do_with_externalState { get; } = new();

      /* ------------------------------------------------------------ */
      // Private Assert
      /* ------------------------------------------------------------ */

      private IAssert<TAsserts, TAsserts> is_this<TAsserts>()
         where TAsserts : IAsserts, IReturnsThisAsserts<TAsserts>
         => AtomicAssert<TAsserts, TAsserts>
           .Create($"{nameof(the_return_value)}_{nameof(is_this)}",
                   assert => assert
                            .ReturnValue()
                            .AreReferenceEqual());

      /* ------------------------------------------------------------ */

      public IAssert<TAsserts, TAsserts> is_a_none<T, TAsserts>()
         where TAsserts : IAsserts, IReturnsAnOptionAsserts<T, TAsserts>
         => AtomicAssert<TAsserts, TAsserts>
           .Create($"{nameof(the_return_value)}_{nameof(is_a_none)}",
                   assert => assert
                            .ReturnValue()
                            .IsANone());

      /* ------------------------------------------------------------ */

      public IAssert<TAsserts, TAsserts> is_a_some_containing<T, TAsserts>(T expected)
         where TAsserts : IAsserts, IReturnsAnOptionAsserts<T, TAsserts>
         => AtomicAssert<TAsserts, TAsserts>
           .Create($@"{nameof(the_return_value)}_{nameof(is_a_some_containing)} ""{expected}""",
                   assert => assert
                            .ReturnValue()
                            .IsASome(expected));

      /* ------------------------------------------------------------ */
   }
}
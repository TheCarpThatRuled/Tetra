using Tetra.Testing;
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   public sealed partial class WhenSome
   {
      /* ------------------------------------------------------------ */
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

      private IAssert<TAsserts, TAsserts> was_invoked_once_with<T, TAsserts>(T expected)
         where TAsserts : IAsserts, IWhenSomeActionAsserts<T, TAsserts>
         => AtomicAssert<TAsserts, TAsserts>
           .Create($@"{nameof(whenSome)}_{nameof(was_invoked_once_with)} ""{expected}""",
                   assert => assert
                            .WhenSome()
                            .WasInvokedOnce(expected));

      /* ------------------------------------------------------------ */

      private IAssert<TAsserts, TAsserts> was_invoked_once_with<T0, T1, TAsserts>(T0 expectedArg0,
                                                                                  T1 expectedArg1)
         where TAsserts : IAsserts, IWhenSomeActionAsserts<T0, T1, TAsserts>
         => AtomicAssert<TAsserts, TAsserts>
           .Create($@"{nameof(whenSome)}_{nameof(was_invoked_once_with)} ""{expectedArg0}"", ""{expectedArg1}""",
                   assert => assert
                            .WhenSome()
                            .WasInvokedOnce(expectedArg0,
                                            expectedArg1));

      /* ------------------------------------------------------------ */

      private IAssert<TAsserts, TAsserts> was_not_invoked<T, TAsserts>()
         where TAsserts : IAsserts, IWhenSomeActionAsserts<T, TAsserts>
         => AtomicAssert<TAsserts, TAsserts>
           .Create($"{nameof(whenSome)}_{nameof(was_not_invoked)}",
                   assert => assert
                            .WhenSome()
                            .WasNotInvoked());

      /* ------------------------------------------------------------ */

      private IAssert<TAsserts, TAsserts> was_not_invoked<T0, T1, TAsserts>()
         where TAsserts : IAsserts, IWhenSomeActionAsserts<T0, T1, TAsserts>
         => AtomicAssert<TAsserts, TAsserts>
           .Create($"{nameof(whenSome)}_{nameof(was_not_invoked)}",
                   assert => assert
                            .WhenSome()
                            .WasNotInvoked());

      /* ------------------------------------------------------------ */
   }
}
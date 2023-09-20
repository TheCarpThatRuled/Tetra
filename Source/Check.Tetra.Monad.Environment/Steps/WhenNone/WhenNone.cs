using Tetra.Testing;
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   public sealed partial class WhenNone
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

      private IAssert<TAsserts, TAsserts> was_invoked_once<TAsserts>()
         where TAsserts : IAsserts, IWhenNoneActionAsserts<TAsserts>
         => AtomicAssert<TAsserts, TAsserts>
           .Create($"{nameof(whenNone)}_{nameof(was_invoked_once)}",
                   assert => assert
                            .WhenNone()
                            .WasInvokedOnce());

      /* ------------------------------------------------------------ */

      private IAssert<TAsserts, TAsserts> was_invoked_once_with<T, TAsserts>(T expected)
         where TAsserts : IAsserts, IWhenNoneActionAsserts<T, TAsserts>
         => AtomicAssert<TAsserts, TAsserts>
           .Create($@"{nameof(whenNone)}_{nameof(was_invoked_once_with)} ""{expected}""",
                   assert => assert
                            .WhenNone()
                            .WasInvokedOnce(expected));

      /* ------------------------------------------------------------ */

      private IAssert<TAsserts, TAsserts> was_not_invoked<TAsserts>()
         where TAsserts : IAsserts, IWhenNoneActionAsserts<TAsserts>
         => AtomicAssert<TAsserts, TAsserts>
           .Create($"{nameof(whenNone)}_{nameof(was_not_invoked)}",
                   assert => assert
                            .WhenNone()
                            .WasNotInvoked());

      /* ------------------------------------------------------------ */

      private IAssert<TAsserts, TAsserts> was_not_invoked<T, TAsserts>()
         where TAsserts : IAsserts, IWhenNoneActionAsserts<T, TAsserts>
         => AtomicAssert<TAsserts, TAsserts>
           .Create($"{nameof(whenNone)}_{nameof(was_not_invoked)}",
                   assert => assert
                            .WhenNone()
                            .WasNotInvoked());

      /* ------------------------------------------------------------ */
   }
}
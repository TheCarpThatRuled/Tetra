using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheOptionHasBeenCreated
{
   public sealed class AndExpandSomeToRightWasCalledWithExternalStateAsserts : IAsserts,
                                                                               IReturnsAnEitherAsserts<FakeLeft, FakeType, AndExpandSomeToRightWasCalledWithExternalStateAsserts>,
                                                                               IWhenNoneFuncAsserts<FakeExternalState, FakeLeft,
                                                                                  AndExpandSomeToRightWasCalledWithExternalStateAsserts>
   {
      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IEither<FakeLeft, FakeType>               _returnValue;
      private readonly FakeFunction<FakeExternalState, FakeLeft> _whenNone;

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal AndExpandSomeToRightWasCalledWithExternalStateAsserts
      (
         FakeFunction<FakeExternalState, FakeLeft> whenNone,
         IEither<FakeLeft, FakeType>               returnValue
      )
      {
         _returnValue = returnValue;
         _whenNone    = whenNone;
      }
      /* ------------------------------------------------------------ */
      //  IReturnsAnEitherAsserts<FakeLeft, FakeType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public EitherAsserts<FakeLeft, FakeType, AndExpandSomeToRightWasCalledWithExternalStateAsserts> ReturnValue()
         => EitherAsserts<FakeLeft, FakeType, AndExpandSomeToRightWasCalledWithExternalStateAsserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenNoneFuncAsserts<FakeExternalState, FakeLeft, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeExternalState, FakeLeft, AndExpandSomeToRightWasCalledWithExternalStateAsserts> WhenNone()
         => FuncAsserts<FakeExternalState, FakeLeft, AndExpandSomeToRightWasCalledWithExternalStateAsserts>
           .Create("whenNone",
                   _whenNone,
                   () => this);

      /* ------------------------------------------------------------ */
   }
}
using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheEitherHasBeenCreated
{
   public sealed class AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts : IAsserts,
                                                                                 IReturnsAnEitherAsserts<FakeNewLeft, FakeNewRight, AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts>,
                                                                                 IWhenLeftFuncAsserts<FakeExternalState, FakeLeft, IEither<FakeNewLeft, FakeNewRight>, AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts>,
                                                                                 IWhenRightFuncAsserts<FakeExternalState, FakeRight, IEither<FakeNewLeft, FakeNewRight>, AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsAnEitherAsserts<FakeNewLeft, FakeNewRight, AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts> Methods
      /* ------------------------------------------------------------ */

      public EitherAsserts<FakeNewLeft, FakeNewRight, AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts> ReturnValue()
         => EitherAsserts<FakeNewLeft, FakeNewRight, AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenLeftFuncAsserts<FakeExternalState, FakeLeft, IEither<FakeNewLeft, FakeNewRight>, AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeExternalState, FakeLeft, IEither<FakeNewLeft, FakeNewRight>, AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts> WhenLeft()
         => FuncAsserts<FakeExternalState, FakeLeft, IEither<FakeNewLeft, FakeNewRight>, AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts>
           .Create("whenLeft",
                   _whenLeft,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenRightFuncAsserts<FakeExternalState, FakeRight, IEither<FakeNewLeft, FakeNewRight>, AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeExternalState, FakeRight, IEither<FakeNewLeft, FakeNewRight>, AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts> WhenRight()
         => FuncAsserts<FakeExternalState, FakeRight, IEither<FakeNewLeft, FakeNewRight>, AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts>
           .Create("whenRight",
                   _whenRight,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts(FakeFunction<FakeExternalState, FakeLeft, IEither<FakeNewLeft, FakeNewRight>>  whenLeft,
                                                                       FakeFunction<FakeExternalState, FakeRight, IEither<FakeNewLeft, FakeNewRight>> whenRight,
                                                                       IEither<FakeNewLeft, FakeNewRight>                                             returnValue)
      {
         _returnValue = returnValue;
         _whenLeft    = whenLeft;
         _whenRight   = whenRight;
      }

      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IEither<FakeNewLeft, FakeNewRight>                                             _returnValue;
      private readonly FakeFunction<FakeExternalState, FakeLeft, IEither<FakeNewLeft, FakeNewRight>>  _whenLeft;
      private readonly FakeFunction<FakeExternalState, FakeRight, IEither<FakeNewLeft, FakeNewRight>> _whenRight;

      /* ------------------------------------------------------------ */
   }
}
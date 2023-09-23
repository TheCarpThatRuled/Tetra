using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheEitherHasBeenCreated
{
   public sealed class AndMapWasCalledWithFuncsToEitherAsserts : IAsserts,
                                                                 IReturnsAnEitherAsserts<FakeNewLeft, FakeNewRight, AndMapWasCalledWithFuncsToEitherAsserts>,
                                                                 IWhenLeftFuncAsserts<FakeLeft, IEither<FakeNewLeft, FakeNewRight>, AndMapWasCalledWithFuncsToEitherAsserts>,
                                                                 IWhenRightFuncAsserts<FakeRight, IEither<FakeNewLeft, FakeNewRight>, AndMapWasCalledWithFuncsToEitherAsserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsAnEitherAsserts<FakeNewLeft, FakeNewRight, AndMapWasCalledWithFuncsToEitherAsserts> Methods
      /* ------------------------------------------------------------ */

      public EitherAsserts<FakeNewLeft, FakeNewRight, AndMapWasCalledWithFuncsToEitherAsserts> ReturnValue()
         => EitherAsserts<FakeNewLeft, FakeNewRight, AndMapWasCalledWithFuncsToEitherAsserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenLeftFuncAsserts<FakeLeft, IEither<FakeNewLeft, FakeNewRight>, AndMapWasCalledWithFuncsToEitherAsserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeLeft, IEither<FakeNewLeft, FakeNewRight>, AndMapWasCalledWithFuncsToEitherAsserts> WhenLeft()
         => FuncAsserts<FakeLeft, IEither<FakeNewLeft, FakeNewRight>, AndMapWasCalledWithFuncsToEitherAsserts>
           .Create("whenLeft",
                   _whenLeft,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenRightFuncAsserts<FakeRight, IEither<FakeNewLeft, FakeNewRight>, AndMapWasCalledWithFuncsToEitherAsserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeRight, IEither<FakeNewLeft, FakeNewRight>, AndMapWasCalledWithFuncsToEitherAsserts> WhenRight()
         => FuncAsserts<FakeRight, IEither<FakeNewLeft, FakeNewRight>, AndMapWasCalledWithFuncsToEitherAsserts>
           .Create("whenRight",
                   _whenRight,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal AndMapWasCalledWithFuncsToEitherAsserts(FakeFunction<FakeLeft, IEither<FakeNewLeft, FakeNewRight>>  whenLeft,
                                                       FakeFunction<FakeRight, IEither<FakeNewLeft, FakeNewRight>> whenRight,
                                                       IEither<FakeNewLeft, FakeNewRight>                          returnValue)
      {
         _returnValue = returnValue;
         _whenLeft    = whenLeft;
         _whenRight   = whenRight;
      }

      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IEither<FakeNewLeft, FakeNewRight>                          _returnValue;
      private readonly FakeFunction<FakeLeft, IEither<FakeNewLeft, FakeNewRight>>  _whenLeft;
      private readonly FakeFunction<FakeRight, IEither<FakeNewLeft, FakeNewRight>> _whenRight;

      /* ------------------------------------------------------------ */
   }
}
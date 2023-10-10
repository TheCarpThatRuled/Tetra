using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheEitherHasBeenCreated
{
   public sealed class AndMapWasCalledWithExternalStateAsserts : IAsserts,
                                                                 IReturnsAnEitherAsserts<FakeNewLeft, FakeNewRight, AndMapWasCalledWithExternalStateAsserts>,
                                                                 IWhenLeftFuncAsserts<FakeExternalState, FakeLeft, FakeNewLeft, AndMapWasCalledWithExternalStateAsserts>,
                                                                 IWhenRightFuncAsserts<FakeExternalState, FakeRight, FakeNewRight, AndMapWasCalledWithExternalStateAsserts>
   {
      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IEither<FakeNewLeft, FakeNewRight>                       _returnValue;
      private readonly FakeFunction<FakeExternalState, FakeLeft, FakeNewLeft>   _whenLeft;
      private readonly FakeFunction<FakeExternalState, FakeRight, FakeNewRight> _whenRight;

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal AndMapWasCalledWithExternalStateAsserts
      (
         FakeFunction<FakeExternalState, FakeLeft, FakeNewLeft>   whenLeft,
         FakeFunction<FakeExternalState, FakeRight, FakeNewRight> whenRight,
         IEither<FakeNewLeft, FakeNewRight>                       returnValue
      )
      {
         _returnValue = returnValue;
         _whenLeft    = whenLeft;
         _whenRight   = whenRight;
      }
      /* ------------------------------------------------------------ */
      //  IReturnsAnEitherAsserts<FakeNewLeft, FakeNewRight, Asserts> Methods
      /* ------------------------------------------------------------ */

      public EitherAsserts<FakeNewLeft, FakeNewRight, AndMapWasCalledWithExternalStateAsserts> ReturnValue()
         => EitherAsserts<FakeNewLeft, FakeNewRight, AndMapWasCalledWithExternalStateAsserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenLeftFuncAsserts<FakeExternalState, FakeLeft, FakeNewLeft, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeExternalState, FakeLeft, FakeNewLeft, AndMapWasCalledWithExternalStateAsserts> WhenLeft()
         => FuncAsserts<FakeExternalState, FakeLeft, FakeNewLeft, AndMapWasCalledWithExternalStateAsserts>
           .Create("whenLeft",
                   _whenLeft,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenRightFuncAsserts<FakeExternalState, FakeRight, FakeNewRight, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeExternalState, FakeRight, FakeNewRight, AndMapWasCalledWithExternalStateAsserts> WhenRight()
         => FuncAsserts<FakeExternalState, FakeRight, FakeNewRight, AndMapWasCalledWithExternalStateAsserts>
           .Create("whenRight",
                   _whenRight,
                   () => this);

      /* ------------------------------------------------------------ */
   }
}
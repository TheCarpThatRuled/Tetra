using Tetra.Testing;

namespace Check;

public static partial class TheEitherHasBeenCreated
{
   public sealed class AndReduceWasCalledWithExternalStateAsserts : IAsserts,
                                                                    IReturnsAsserts<FakeNewType, AndReduceWasCalledWithExternalStateAsserts>,
                                                                    IWhenLeftFuncAsserts<FakeExternalState, FakeLeft, FakeNewType, AndReduceWasCalledWithExternalStateAsserts>,
                                                                    IWhenRightFuncAsserts<FakeExternalState, FakeRight, FakeNewType, AndReduceWasCalledWithExternalStateAsserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsAsserts<FakeNewType, AndReduceWasCalledWithExternalStateAsserts> Methods
      /* ------------------------------------------------------------ */

      public ObjectAsserts<FakeNewType, AndReduceWasCalledWithExternalStateAsserts> ReturnValue()
         => ObjectAsserts<FakeNewType, AndReduceWasCalledWithExternalStateAsserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenLeftFunctionAsserts<FakeExternalState, FakeLeft, FakeNewType, AndReduceWasCalledWithExternalStateAsserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeExternalState, FakeLeft, FakeNewType, AndReduceWasCalledWithExternalStateAsserts> WhenLeft()
         => FuncAsserts<FakeExternalState, FakeLeft, FakeNewType, AndReduceWasCalledWithExternalStateAsserts>
           .Create("whenLeft",
                   _whenLeft,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenRightFunctionAsserts<FakeExternalState, FakeRight, FakeNewType, AndReduceWasCalledWithExternalStateAsserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeExternalState, FakeRight, FakeNewType, AndReduceWasCalledWithExternalStateAsserts> WhenRight()
         => FuncAsserts<FakeExternalState, FakeRight, FakeNewType, AndReduceWasCalledWithExternalStateAsserts>
           .Create("whenRight",
                   _whenRight,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal AndReduceWasCalledWithExternalStateAsserts(FakeFunction<FakeExternalState, FakeLeft, FakeNewType>  whenLeft,
                                                          FakeFunction<FakeExternalState, FakeRight, FakeNewType> whenRight,
                                                          FakeNewType                                             returnValue)
      {
         _returnValue = returnValue;
         _whenLeft    = whenLeft;
         _whenRight   = whenRight;
      }

      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly FakeNewType                                             _returnValue;
      private readonly FakeFunction<FakeExternalState, FakeLeft, FakeNewType>  _whenLeft;
      private readonly FakeFunction<FakeExternalState, FakeRight, FakeNewType> _whenRight;

      /* ------------------------------------------------------------ */
   }
}
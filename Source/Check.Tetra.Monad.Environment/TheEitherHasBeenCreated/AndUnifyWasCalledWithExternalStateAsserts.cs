using Tetra.Testing;

namespace Check;

public static partial class TheEitherHasBeenCreated
{
   public sealed class AndUnifyWasCalledWithExternalStateAsserts : IAsserts,
                                                                    IReturnsAsserts<FakeNewType, AndUnifyWasCalledWithExternalStateAsserts>,
                                                                    IWhenLeftFuncAsserts<FakeExternalState, FakeLeft, FakeNewType, AndUnifyWasCalledWithExternalStateAsserts>,
                                                                    IWhenRightFuncAsserts<FakeExternalState, FakeRight, FakeNewType, AndUnifyWasCalledWithExternalStateAsserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsAsserts<FakeNewType, AndReduceWasCalledWithExternalStateAsserts> Methods
      /* ------------------------------------------------------------ */

      public ObjectAsserts<FakeNewType, AndUnifyWasCalledWithExternalStateAsserts> ReturnValue()
         => ObjectAsserts<FakeNewType, AndUnifyWasCalledWithExternalStateAsserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenLeftFunctionAsserts<FakeExternalState, FakeLeft, FakeNewType, AndReduceWasCalledWithExternalStateAsserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeExternalState, FakeLeft, FakeNewType, AndUnifyWasCalledWithExternalStateAsserts> WhenLeft()
         => FuncAsserts<FakeExternalState, FakeLeft, FakeNewType, AndUnifyWasCalledWithExternalStateAsserts>
           .Create("whenLeft",
                   _whenLeft,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenRightFunctionAsserts<FakeExternalState, FakeRight, FakeNewType, AndReduceWasCalledWithExternalStateAsserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeExternalState, FakeRight, FakeNewType, AndUnifyWasCalledWithExternalStateAsserts> WhenRight()
         => FuncAsserts<FakeExternalState, FakeRight, FakeNewType, AndUnifyWasCalledWithExternalStateAsserts>
           .Create("whenRight",
                   _whenRight,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal AndUnifyWasCalledWithExternalStateAsserts(FakeFunction<FakeExternalState, FakeLeft, FakeNewType>  whenLeft,
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
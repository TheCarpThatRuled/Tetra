using Tetra.Testing;

namespace Check;

public static partial class TheEitherHasBeenCreated
{
   public sealed class AndUnifyWasCalledAsserts : IAsserts,
                                                  IReturnsAsserts<FakeNewType, AndUnifyWasCalledAsserts>,
                                                  IWhenLeftFuncAsserts<FakeLeft, FakeNewType, AndUnifyWasCalledAsserts>,
                                                  IWhenRightFuncAsserts<FakeRight, FakeNewType, AndUnifyWasCalledAsserts>
   {
      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly FakeNewType                          _returnValue;
      private readonly FakeFunction<FakeLeft, FakeNewType>  _whenLeft;
      private readonly FakeFunction<FakeRight, FakeNewType> _whenRight;

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal AndUnifyWasCalledAsserts
      (
         FakeFunction<FakeLeft, FakeNewType>  whenLeft,
         FakeFunction<FakeRight, FakeNewType> whenRight,
         FakeNewType                          returnValue
      )
      {
         _returnValue = returnValue;
         _whenLeft    = whenLeft;
         _whenRight   = whenRight;
      }
      /* ------------------------------------------------------------ */
      //  IReturnsAsserts<FakeNewType, AndReduceWasCalledAsserts> Methods
      /* ------------------------------------------------------------ */

      public ObjectAsserts<FakeNewType, AndUnifyWasCalledAsserts> ReturnValue()
         => ObjectAsserts<FakeNewType, AndUnifyWasCalledAsserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenLeftFunctionAsserts<FakeLeft, FakeNewType, AndReduceWasCalledAsserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeLeft, FakeNewType, AndUnifyWasCalledAsserts> WhenLeft()
         => FuncAsserts<FakeLeft, FakeNewType, AndUnifyWasCalledAsserts>
           .Create("whenLeft",
                   _whenLeft,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenRightFunctionAsserts<FakeRight, FakeNewType, AndReduceWasCalledAsserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeRight, FakeNewType, AndUnifyWasCalledAsserts> WhenRight()
         => FuncAsserts<FakeRight, FakeNewType, AndUnifyWasCalledAsserts>
           .Create("whenRight",
                   _whenRight,
                   () => this);

      /* ------------------------------------------------------------ */
   }
}
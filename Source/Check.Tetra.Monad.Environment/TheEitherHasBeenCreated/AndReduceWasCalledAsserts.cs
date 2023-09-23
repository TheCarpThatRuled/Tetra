using Tetra.Testing;

namespace Check;

public static partial class TheEitherHasBeenCreated
{
   public sealed class AndReduceWasCalledAsserts : IAsserts,
                                                   IReturnsAsserts<FakeNewType, AndReduceWasCalledAsserts>,
                                                   IWhenLeftFuncAsserts<FakeLeft, FakeNewType, AndReduceWasCalledAsserts>,
                                                   IWhenRightFuncAsserts<FakeRight, FakeNewType, AndReduceWasCalledAsserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsAnEitherAsserts<FakeNewType, AndReduceWasCalledAsserts> Methods
      /* ------------------------------------------------------------ */

      public ObjectAsserts<FakeNewType, AndReduceWasCalledAsserts> ReturnValue()
         => ObjectAsserts<FakeNewType, AndReduceWasCalledAsserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenLeftFunctionAsserts<FakeLeft, FakeNewType, AndReduceWasCalledAsserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeLeft, FakeNewType, AndReduceWasCalledAsserts> WhenLeft()
         => FuncAsserts<FakeLeft, FakeNewType, AndReduceWasCalledAsserts>
           .Create("whenLeft",
                   _whenLeft,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenRightFunctionAsserts<FakeRight, FakeNewType, AndReduceWasCalledAsserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeRight, FakeNewType, AndReduceWasCalledAsserts> WhenRight()
         => FuncAsserts<FakeRight, FakeNewType, AndReduceWasCalledAsserts>
           .Create("whenRight",
                   _whenRight,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal AndReduceWasCalledAsserts(FakeFunction<FakeLeft, FakeNewType>  whenLeft,
                                         FakeFunction<FakeRight, FakeNewType> whenRight,
                                         FakeNewType                          returnValue)
      {
         _returnValue = returnValue;
         _whenLeft    = whenLeft;
         _whenRight   = whenRight;
      }

      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly FakeNewType                          _returnValue;
      private readonly FakeFunction<FakeLeft, FakeNewType>  _whenLeft;
      private readonly FakeFunction<FakeRight, FakeNewType> _whenRight;

      /* ------------------------------------------------------------ */
   }
}
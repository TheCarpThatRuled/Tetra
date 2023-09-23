using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheEitherHasBeenCreated
{
   public sealed class AndMapWasCalledAsserts : IAsserts,
                                                IReturnsAnEitherAsserts<FakeNewLeft, FakeNewRight, AndMapWasCalledAsserts>,
                                                IWhenLeftFuncAsserts<FakeLeft, FakeNewLeft, AndMapWasCalledAsserts>,
                                                IWhenRightFuncAsserts<FakeRight, FakeNewRight, AndMapWasCalledAsserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsAnEitherAsserts<FakeNewLeft, FakeNewRight, AndMapWasCalledAsserts> Methods
      /* ------------------------------------------------------------ */

      public EitherAsserts<FakeNewLeft, FakeNewRight, AndMapWasCalledAsserts> ReturnValue()
         => EitherAsserts<FakeNewLeft, FakeNewRight, AndMapWasCalledAsserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenLeftFuncAsserts<FakeLeft, FakeNewLeft, AndMapWasCalledAsserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeLeft, FakeNewLeft, AndMapWasCalledAsserts> WhenLeft()
         => FuncAsserts<FakeLeft, FakeNewLeft, AndMapWasCalledAsserts>
           .Create("whenLeft",
                   _whenLeft,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenRightFuncAsserts<FakeRight, FakeNewRight, AndMapWasCalledAsserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeRight, FakeNewRight, AndMapWasCalledAsserts> WhenRight()
         => FuncAsserts<FakeRight, FakeNewRight, AndMapWasCalledAsserts>
           .Create("whenRight",
                   _whenRight,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal AndMapWasCalledAsserts(FakeFunction<FakeLeft, FakeNewLeft>   whenLeft,
                                      FakeFunction<FakeRight, FakeNewRight> whenRight,
                                      IEither<FakeNewLeft, FakeNewRight>    returnValue)
      {
         _returnValue = returnValue;
         _whenLeft    = whenLeft;
         _whenRight   = whenRight;
      }

      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IEither<FakeNewLeft, FakeNewRight>    _returnValue;
      private readonly FakeFunction<FakeLeft, FakeNewLeft>   _whenLeft;
      private readonly FakeFunction<FakeRight, FakeNewRight> _whenRight;

      /* ------------------------------------------------------------ */
   }
}
using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheOptionHasBeenCreated
{
   public sealed class AndExpandSomeToRightWasCalledAsserts : IAsserts,
                                 IReturnsAnEitherAsserts<FakeLeft, FakeType, AndExpandSomeToRightWasCalledAsserts>,
                                 IWhenNoneFuncAsserts<FakeLeft, AndExpandSomeToRightWasCalledAsserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsAnEitherAsserts<FakeLeft, FakeType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public EitherAsserts<FakeLeft, FakeType, AndExpandSomeToRightWasCalledAsserts> ReturnValue()
         => EitherAsserts<FakeLeft, FakeType, AndExpandSomeToRightWasCalledAsserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenNoneFuncAsserts<FakeLeft, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeLeft, AndExpandSomeToRightWasCalledAsserts> WhenNone()
         => FuncAsserts<FakeLeft, AndExpandSomeToRightWasCalledAsserts>
           .Create("whenNone",
                   _whenNone,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal AndExpandSomeToRightWasCalledAsserts(FakeFunction<FakeLeft>      whenNone,
                       IEither<FakeLeft, FakeType> returnValue)
      {
         _returnValue = returnValue;
         _whenNone    = whenNone;
      }

      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IEither<FakeLeft, FakeType> _returnValue;
      private readonly FakeFunction<FakeLeft>      _whenNone;

      /* ------------------------------------------------------------ */
   }
}
using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheOptionHasBeenCreated
{
   public sealed class AndExpandSomeToLeftWasCalledAsserts : IAsserts,
                                                             IReturnsAnEitherAsserts<FakeType, FakeRight, AndExpandSomeToLeftWasCalledAsserts>,
                                                             IWhenNoneFuncAsserts<FakeRight, AndExpandSomeToLeftWasCalledAsserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsAnEitherAsserts<FakeRight, FakeType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public EitherAsserts<FakeType, FakeRight, AndExpandSomeToLeftWasCalledAsserts> ReturnValue()
         => EitherAsserts<FakeType, FakeRight, AndExpandSomeToLeftWasCalledAsserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenNoneFuncAsserts<FakeRight, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeRight, AndExpandSomeToLeftWasCalledAsserts> WhenNone()
         => FuncAsserts<FakeRight, AndExpandSomeToLeftWasCalledAsserts>
           .Create("whenNone",
                   _whenNone,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal AndExpandSomeToLeftWasCalledAsserts(FakeFunction<FakeRight>      whenNone,
                                                   IEither<FakeType, FakeRight> returnValue)
      {
         _returnValue = returnValue;
         _whenNone    = whenNone;
      }

      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IEither<FakeType, FakeRight> _returnValue;
      private readonly FakeFunction<FakeRight>      _whenNone;

      /* ------------------------------------------------------------ */
   }
}
using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheOptionHasBeenCreated
{
   public sealed class AndExpandSomeToLeftWasCalledWithExternalStateAsserts : IAsserts,
                                                                              IReturnsAnEitherAsserts<FakeType, FakeRight, AndExpandSomeToLeftWasCalledWithExternalStateAsserts>,
                                                                              IWhenNoneFuncAsserts<FakeExternalState, FakeRight,
                                                                                 AndExpandSomeToLeftWasCalledWithExternalStateAsserts>
   {
      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IEither<FakeType, FakeRight>               _returnValue;
      private readonly FakeFunction<FakeExternalState, FakeRight> _whenNone;

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal AndExpandSomeToLeftWasCalledWithExternalStateAsserts
      (
         FakeFunction<FakeExternalState, FakeRight> whenNone,
         IEither<FakeType, FakeRight>               returnValue
      )
      {
         _returnValue = returnValue;
         _whenNone    = whenNone;
      }
      /* ------------------------------------------------------------ */
      //  IReturnsAnEitherAsserts<FakeType, FakeRight, Asserts> Methods
      /* ------------------------------------------------------------ */

      public EitherAsserts<FakeType, FakeRight, AndExpandSomeToLeftWasCalledWithExternalStateAsserts> ReturnValue()
         => EitherAsserts<FakeType, FakeRight, AndExpandSomeToLeftWasCalledWithExternalStateAsserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenNoneFuncAsserts<FakeExternalState, FakeRight, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeExternalState, FakeRight, AndExpandSomeToLeftWasCalledWithExternalStateAsserts> WhenNone()
         => FuncAsserts<FakeExternalState, FakeRight, AndExpandSomeToLeftWasCalledWithExternalStateAsserts>
           .Create("whenNone",
                   _whenNone,
                   () => this);

      /* ------------------------------------------------------------ */
   }
}
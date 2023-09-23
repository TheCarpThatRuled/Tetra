using Tetra;
using Tetra.Testing;

namespace Check;

public static class ExpandSomeToLeftWasCalledWithExternalState
{
   public sealed class Asserts : IAsserts,
                                 IReturnsAnEitherAsserts<FakeType, FakeRight, Asserts>,
                                 IWhenNoneFuncAsserts<FakeExternalState, FakeRight, Asserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsAnEitherAsserts<FakeType, FakeRight, Asserts> Methods
      /* ------------------------------------------------------------ */

      public EitherAsserts<FakeType, FakeRight, Asserts> ReturnValue()
         => EitherAsserts<FakeType, FakeRight, Asserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenNoneFuncAsserts<FakeExternalState, FakeRight, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeExternalState, FakeRight, Asserts> WhenNone()
         => FuncAsserts<FakeExternalState, FakeRight, Asserts>
           .Create("whenNone",
                   _whenNone,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal Asserts(FakeFunction<FakeExternalState, FakeRight> whenNone,
                       IEither<FakeType, FakeRight>               returnValue)
      {
         _returnValue = returnValue;
         _whenNone    = whenNone;
      }

      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IEither<FakeType, FakeRight>               _returnValue;
      private readonly FakeFunction<FakeExternalState, FakeRight> _whenNone;

      /* ------------------------------------------------------------ */
   }
}
using Tetra;
using Tetra.Testing;

namespace Check;

public static class ExpandSomeToRightWasCalledWithExternalState
{
   public sealed class Asserts : IAsserts,
                                 IReturnsAnEitherAsserts<FakeLeft, FakeType, Asserts>,
                                 IWhenNoneFuncAsserts<FakeExternalState, FakeLeft, Asserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsAnEitherAsserts<FakeLeft, FakeType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public EitherAsserts<FakeLeft, FakeType, Asserts> ReturnValue()
         => EitherAsserts<FakeLeft, FakeType, Asserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenNoneFuncAsserts<FakeExternalState, FakeLeft, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeExternalState, FakeLeft, Asserts> WhenNone()
         => FuncAsserts<FakeExternalState, FakeLeft, Asserts>
           .Create("whenNone",
                   _whenNone,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal Asserts(FakeFunction<FakeExternalState, FakeLeft> whenNone,
                       IEither<FakeLeft, FakeType>               returnValue)
      {
         _returnValue = returnValue;
         _whenNone    = whenNone;
      }

      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IEither<FakeLeft, FakeType>               _returnValue;
      private readonly FakeFunction<FakeExternalState, FakeLeft> _whenNone;

      /* ------------------------------------------------------------ */
   }
}
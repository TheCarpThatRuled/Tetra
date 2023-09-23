using Tetra;
using Tetra.Testing;

namespace Check;

public static class ExpandSomeToRightWasCalled
{
   public sealed class Asserts : IAsserts,
                                 IReturnsAnEitherAsserts<FakeLeft, FakeType, Asserts>,
                                 IWhenNoneFuncAsserts<FakeLeft, Asserts>
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
      //  IWhenNoneFuncAsserts<FakeLeft, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeLeft, Asserts> WhenNone()
         => FuncAsserts<FakeLeft, Asserts>
           .Create("whenNone",
                   _whenNone,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal Asserts(FakeFunction<FakeLeft>      whenNone,
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
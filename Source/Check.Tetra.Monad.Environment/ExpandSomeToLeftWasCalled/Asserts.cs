using Tetra;
using Tetra.Testing;

namespace Check;

public static class ExpandSomeToLeftWasCalled
{
   public sealed class Asserts : IAsserts,
                                 IReturnsAnEitherAsserts<FakeType, FakeRight, Asserts>,
                                 IWhenNoneFuncAsserts<FakeRight, Asserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsAnEitherAsserts<FakeRight, FakeType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public EitherAsserts<FakeType, FakeRight, Asserts> ReturnValue()
         => EitherAsserts< FakeType, FakeRight, Asserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenNoneFuncAsserts<FakeRight, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeRight, Asserts> WhenNone()
         => FuncAsserts<FakeRight, Asserts>
           .Create("whenNone",
                   _whenNone,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal Asserts(FakeFunction<FakeRight>    whenNone,
                       IEither<FakeType, FakeRight> returnValue)
      {
         _returnValue = returnValue;
         _whenNone    = whenNone;
      }

      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IEither<FakeType, FakeRight> _returnValue;
      private readonly FakeFunction<FakeRight>    _whenNone;

      /* ------------------------------------------------------------ */
   }
}
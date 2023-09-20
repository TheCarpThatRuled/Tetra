using Tetra;
using Tetra.Testing;

namespace Check;

public static class MapToOptionWasCalledWithExternalState
{
   public sealed class Asserts : IAsserts,
                                 IReturnsAnOptionAsserts<FakeNewType, Asserts>,
                                 IWhenSomeFuncAsserts<FakeExternalState, FakeType, IOption<FakeNewType>, Asserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsAnOptionAsserts<FakeNewType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public OptionAsserts<FakeNewType, Asserts> ReturnValue()
         => OptionAsserts<FakeNewType, Asserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenSomeFuncAsserts<FakeExternalState, FakeType, IOption<FakeNewType>, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeExternalState, FakeType, IOption<FakeNewType>, Asserts> WhenSome()
         => FuncAsserts<FakeExternalState, FakeType, IOption<FakeNewType>, Asserts>
           .Create("whenSome",
                   _whenSome,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal Asserts(FakeFunction<FakeExternalState, FakeType, IOption<FakeNewType>> whenSome,
                       IOption<FakeNewType>                                            returnValue)
      {
         _returnValue = returnValue;
         _whenSome    = whenSome;
      }

      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IOption<FakeNewType>                                            _returnValue;
      private readonly FakeFunction<FakeExternalState, FakeType, IOption<FakeNewType>> _whenSome;

      /* ------------------------------------------------------------ */
   }
}
using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheOptionHasBeenCreated
{
   public sealed class AndMapWasCalledWithFuncToOptionAndExternalStateAsserts : IAsserts,
                                 IReturnsAnOptionAsserts<FakeNewType, AndMapWasCalledWithFuncToOptionAndExternalStateAsserts>,
                                 IWhenSomeFuncAsserts<FakeExternalState, FakeType, IOption<FakeNewType>, AndMapWasCalledWithFuncToOptionAndExternalStateAsserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsAnOptionAsserts<FakeNewType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public OptionAsserts<FakeNewType, AndMapWasCalledWithFuncToOptionAndExternalStateAsserts> ReturnValue()
         => OptionAsserts<FakeNewType, AndMapWasCalledWithFuncToOptionAndExternalStateAsserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenSomeFuncAsserts<FakeExternalState, FakeType, IOption<FakeNewType>, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeExternalState, FakeType, IOption<FakeNewType>, AndMapWasCalledWithFuncToOptionAndExternalStateAsserts> WhenSome()
         => FuncAsserts<FakeExternalState, FakeType, IOption<FakeNewType>, AndMapWasCalledWithFuncToOptionAndExternalStateAsserts>
           .Create("whenSome",
                   _whenSome,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal AndMapWasCalledWithFuncToOptionAndExternalStateAsserts(FakeFunction<FakeExternalState, FakeType, IOption<FakeNewType>> whenSome,
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
using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheOptionHasBeenCreated
{
   public sealed class AndMapWasCalledWithExternalStateAsserts : IAsserts,
                                 IReturnsAnOptionAsserts<FakeNewType, AndMapWasCalledWithExternalStateAsserts>,
                                 IWhenSomeFuncAsserts<FakeExternalState, FakeType, FakeNewType, AndMapWasCalledWithExternalStateAsserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsAnOptionAsserts<FakeNewType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public OptionAsserts<FakeNewType, AndMapWasCalledWithExternalStateAsserts> ReturnValue()
         => OptionAsserts<FakeNewType, AndMapWasCalledWithExternalStateAsserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenSomeFuncAsserts<FakeExternalState, FakeType, FakeNewType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeExternalState, FakeType, FakeNewType, AndMapWasCalledWithExternalStateAsserts> WhenSome()
         => FuncAsserts<FakeExternalState, FakeType, FakeNewType, AndMapWasCalledWithExternalStateAsserts>
           .Create("whenSome",
                   _whenSome,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal AndMapWasCalledWithExternalStateAsserts(FakeFunction<FakeExternalState, FakeType, FakeNewType> whenSome,
                       IOption<FakeNewType>                                   returnValue)
      {
         _returnValue = returnValue;
         _whenSome    = whenSome;
      }

      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IOption<FakeNewType>                                   _returnValue;
      private readonly FakeFunction<FakeExternalState, FakeType, FakeNewType> _whenSome;

      /* ------------------------------------------------------------ */
   }
}
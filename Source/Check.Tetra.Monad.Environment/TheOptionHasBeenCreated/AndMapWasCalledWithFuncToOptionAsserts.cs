using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheOptionHasBeenCreated
{
   public sealed class AndMapWasCalledWithFuncToOptionAsserts : IAsserts,
                                 IReturnsAnOptionAsserts<FakeNewType, AndMapWasCalledWithFuncToOptionAsserts>,
                                 IWhenSomeFuncAsserts<FakeType, IOption<FakeNewType>, AndMapWasCalledWithFuncToOptionAsserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsThisAsserts<Asserts> Methods
      /* ------------------------------------------------------------ */

      public OptionAsserts<FakeNewType, AndMapWasCalledWithFuncToOptionAsserts> ReturnValue()
         => OptionAsserts<FakeNewType, AndMapWasCalledWithFuncToOptionAsserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenSomeFuncAsserts<FakeType, IOption<FakeNewType>, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeType, IOption<FakeNewType>, AndMapWasCalledWithFuncToOptionAsserts> WhenSome()
         => FuncAsserts<FakeType, IOption<FakeNewType>, AndMapWasCalledWithFuncToOptionAsserts>
           .Create("whenSome",
                   _whenSome,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal AndMapWasCalledWithFuncToOptionAsserts(FakeFunction<FakeType, IOption<FakeNewType>> whenSome,
                       IOption<FakeNewType>                         returnValue)
      {
         _returnValue = returnValue;
         _whenSome    = whenSome;
      }

      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IOption<FakeNewType>                         _returnValue;
      private readonly FakeFunction<FakeType, IOption<FakeNewType>> _whenSome;

      /* ------------------------------------------------------------ */
   }
}
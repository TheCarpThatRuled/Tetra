using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheOptionHasBeenCreated
{
   public sealed class AndMapWasCalledAsserts : IAsserts,
                                 IReturnsAnOptionAsserts<FakeNewType, AndMapWasCalledAsserts>,
                                 IWhenSomeFuncAsserts<FakeType, FakeNewType, AndMapWasCalledAsserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsThisAsserts<Asserts> Methods
      /* ------------------------------------------------------------ */

      public OptionAsserts<FakeNewType, AndMapWasCalledAsserts> ReturnValue()
         => OptionAsserts<FakeNewType, AndMapWasCalledAsserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenSomeFuncAsserts<FakeType, FakeNewType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeType, FakeNewType, AndMapWasCalledAsserts> WhenSome()
         => FuncAsserts<FakeType, FakeNewType, AndMapWasCalledAsserts>
           .Create("whenSome",
                   _whenSome,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal AndMapWasCalledAsserts(FakeFunction<FakeType, FakeNewType> whenSome,
                       IOption<FakeNewType>                returnValue)
      {
         _returnValue = returnValue;
         _whenSome    = whenSome;
      }

      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IOption<FakeNewType>                _returnValue;
      private readonly FakeFunction<FakeType, FakeNewType> _whenSome;

      /* ------------------------------------------------------------ */
   }
}
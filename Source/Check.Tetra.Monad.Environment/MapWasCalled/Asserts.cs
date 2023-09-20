using Tetra;
using Tetra.Testing;

namespace Check;

public static class MapWasCalled
{
   public sealed class Asserts : IAsserts,
                                 IReturnsAnOptionAsserts<FakeNewType, Asserts>,
                                 IWhenSomeFuncAsserts<FakeType, FakeNewType, Asserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsThisAsserts<Asserts> Methods
      /* ------------------------------------------------------------ */

      public OptionAsserts<FakeNewType, Asserts> ReturnValue()
         => OptionAsserts<FakeNewType, Asserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenSomeFuncAsserts<FakeType, FakeNewType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeType, FakeNewType, Asserts> WhenSome()
         => FuncAsserts<FakeType, FakeNewType, Asserts>
           .Create("whenSome",
                   _whenSome,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal Asserts(FakeFunction<FakeType, FakeNewType> whenSome,
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
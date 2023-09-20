using Tetra;
using Tetra.Testing;

namespace Check;

public static class MapToOptionWasCalled
{
   public sealed class Asserts : IAsserts,
                                 IReturnsAnOptionAsserts<FakeNewType, Asserts>,
                                 IWhenSomeFuncAsserts<FakeType, IOption<FakeNewType>, Asserts>
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
      //  IWhenSomeFuncAsserts<FakeType, IOption<FakeNewType>, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeType, IOption<FakeNewType>, Asserts> WhenSome()
         => FuncAsserts<FakeType, IOption<FakeNewType>, Asserts>
           .Create("whenSome",
                   _whenSome,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal Asserts(FakeFunction<FakeType, IOption<FakeNewType>> whenSome,
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
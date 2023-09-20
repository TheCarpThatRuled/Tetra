using Tetra.Testing;

namespace Check;

public static class ReduceWasCalledWithExternalState
{
   public sealed class Asserts : IAsserts,
                                 IReturnsAsserts<FakeNewType, Asserts>,
                                 IWhenNoneFuncAsserts<FakeExternalState, FakeNewType, Asserts>,
                                 IWhenSomeFuncAsserts<FakeExternalState, FakeType, FakeNewType, Asserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsAsserts<FakeNewType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public ObjectAsserts<FakeNewType, Asserts> ReturnValue()
         => ObjectAsserts<FakeNewType, Asserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenNoneFunctionAsserts<FakeExternalState, FakeNewType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeExternalState, FakeNewType, Asserts> WhenNone()
         => FuncAsserts<FakeExternalState, FakeNewType, Asserts>
           .Create("whenNone",
                   _whenNone,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenSomeFunctionAsserts<FakeExternalState, FakeType, FakeNewType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeExternalState, FakeType, FakeNewType, Asserts> WhenSome()
         => FuncAsserts<FakeExternalState, FakeType, FakeNewType, Asserts>
           .Create("whenSome",
                   _whenSome,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal Asserts(FakeFunction<FakeExternalState, FakeType, FakeNewType> whenSome,
                       FakeFunction<FakeExternalState, FakeNewType>           whenNone,
                       FakeNewType                                            returnValue)
      {
         _returnValue = returnValue;
         _whenNone    = whenNone;
         _whenSome    = whenSome;
      }

      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly FakeNewType                                            _returnValue;
      private readonly FakeFunction<FakeExternalState, FakeNewType>           _whenNone;
      private readonly FakeFunction<FakeExternalState, FakeType, FakeNewType> _whenSome;

      /* ------------------------------------------------------------ */
   }
}
using Tetra.Testing;

namespace Check;

public static partial class TheOptionHasBeenCreated
{
   public sealed class AndReduceWasCalledWithExternalStateAsserts : IAsserts,
                                 IReturnsAsserts<FakeNewType, AndReduceWasCalledWithExternalStateAsserts>,
                                 IWhenNoneFuncAsserts<FakeExternalState, FakeNewType, AndReduceWasCalledWithExternalStateAsserts>,
                                 IWhenSomeFuncAsserts<FakeExternalState, FakeType, FakeNewType, AndReduceWasCalledWithExternalStateAsserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsAsserts<FakeNewType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public ObjectAsserts<FakeNewType, AndReduceWasCalledWithExternalStateAsserts> ReturnValue()
         => ObjectAsserts<FakeNewType, AndReduceWasCalledWithExternalStateAsserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenNoneFunctionAsserts<FakeExternalState, FakeNewType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeExternalState, FakeNewType, AndReduceWasCalledWithExternalStateAsserts> WhenNone()
         => FuncAsserts<FakeExternalState, FakeNewType, AndReduceWasCalledWithExternalStateAsserts>
           .Create("whenNone",
                   _whenNone,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenSomeFunctionAsserts<FakeExternalState, FakeType, FakeNewType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeExternalState, FakeType, FakeNewType, AndReduceWasCalledWithExternalStateAsserts> WhenSome()
         => FuncAsserts<FakeExternalState, FakeType, FakeNewType, AndReduceWasCalledWithExternalStateAsserts>
           .Create("whenSome",
                   _whenSome,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal AndReduceWasCalledWithExternalStateAsserts(FakeFunction<FakeExternalState, FakeType, FakeNewType> whenSome,
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
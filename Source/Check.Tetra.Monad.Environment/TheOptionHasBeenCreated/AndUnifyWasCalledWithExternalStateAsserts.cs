using Tetra.Testing;

namespace Check;

public static partial class TheOptionHasBeenCreated
{
   public sealed class AndUnifyWasCalledWithExternalStateAsserts : IAsserts,
                                                                   IReturnsAsserts<FakeNewType, AndUnifyWasCalledWithExternalStateAsserts>,
                                                                   IWhenNoneFuncAsserts<FakeExternalState, FakeNewType, AndUnifyWasCalledWithExternalStateAsserts>,
                                                                   IWhenSomeFuncAsserts<FakeExternalState, FakeType, FakeNewType, AndUnifyWasCalledWithExternalStateAsserts>
   {
      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly FakeNewType                                            _returnValue;
      private readonly FakeFunction<FakeExternalState, FakeNewType>           _whenNone;
      private readonly FakeFunction<FakeExternalState, FakeType, FakeNewType> _whenSome;

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal AndUnifyWasCalledWithExternalStateAsserts
      (
         FakeFunction<FakeExternalState, FakeType, FakeNewType> whenSome,
         FakeFunction<FakeExternalState, FakeNewType>           whenNone,
         FakeNewType                                            returnValue
      )
      {
         _returnValue = returnValue;
         _whenNone    = whenNone;
         _whenSome    = whenSome;
      }
      /* ------------------------------------------------------------ */
      //  IReturnsAsserts<FakeNewType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public ObjectAsserts<FakeNewType, AndUnifyWasCalledWithExternalStateAsserts> ReturnValue()
         => ObjectAsserts<FakeNewType, AndUnifyWasCalledWithExternalStateAsserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenNoneFunctionAsserts<FakeExternalState, FakeNewType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeExternalState, FakeNewType, AndUnifyWasCalledWithExternalStateAsserts> WhenNone()
         => FuncAsserts<FakeExternalState, FakeNewType, AndUnifyWasCalledWithExternalStateAsserts>
           .Create("whenNone",
                   _whenNone,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenSomeFunctionAsserts<FakeExternalState, FakeType, FakeNewType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeExternalState, FakeType, FakeNewType, AndUnifyWasCalledWithExternalStateAsserts> WhenSome()
         => FuncAsserts<FakeExternalState, FakeType, FakeNewType, AndUnifyWasCalledWithExternalStateAsserts>
           .Create("whenSome",
                   _whenSome,
                   () => this);

      /* ------------------------------------------------------------ */
   }
}
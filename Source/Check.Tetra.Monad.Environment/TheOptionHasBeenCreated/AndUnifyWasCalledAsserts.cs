using Tetra.Testing;

namespace Check;

public static partial class TheOptionHasBeenCreated
{
   public sealed class AndUnifyWasCalledAsserts : IAsserts,
                                 IReturnsAsserts<FakeNewType, AndUnifyWasCalledAsserts>,
                                 IWhenNoneFuncAsserts<FakeNewType, AndUnifyWasCalledAsserts>,
                                 IWhenSomeFuncAsserts<FakeType, FakeNewType, AndUnifyWasCalledAsserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsAnOptionAsserts<FakeNewType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public ObjectAsserts<FakeNewType, AndUnifyWasCalledAsserts> ReturnValue()
         => ObjectAsserts<FakeNewType, AndUnifyWasCalledAsserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenNoneFunctionAsserts<FakeNewType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeNewType, AndUnifyWasCalledAsserts> WhenNone()
         => FuncAsserts<FakeNewType, AndUnifyWasCalledAsserts>
           .Create("whenNone",
                   _whenNone,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenSomeFunctionAsserts<FakeType, FakeNewType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeType, FakeNewType, AndUnifyWasCalledAsserts> WhenSome()
         => FuncAsserts<FakeType, FakeNewType, AndUnifyWasCalledAsserts>
           .Create("whenSome",
                   _whenSome,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal AndUnifyWasCalledAsserts(FakeFunction<FakeType, FakeNewType> whenSome,
                       FakeFunction<FakeNewType>           whenNone,
                       FakeNewType                         returnValue)
      {
         _returnValue = returnValue;
         _whenNone    = whenNone;
         _whenSome    = whenSome;
      }

      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly FakeNewType                         _returnValue;
      private readonly FakeFunction<FakeNewType>           _whenNone;
      private readonly FakeFunction<FakeType, FakeNewType> _whenSome;

      /* ------------------------------------------------------------ */
   }
}
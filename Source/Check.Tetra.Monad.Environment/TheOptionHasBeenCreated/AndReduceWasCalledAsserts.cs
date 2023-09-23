using Tetra.Testing;

namespace Check;

public static partial class TheOptionHasBeenCreated
{
   public sealed class AndReduceWasCalledAsserts : IAsserts,
                                 IReturnsAsserts<FakeNewType, AndReduceWasCalledAsserts>,
                                 IWhenNoneFuncAsserts<FakeNewType, AndReduceWasCalledAsserts>,
                                 IWhenSomeFuncAsserts<FakeType, FakeNewType, AndReduceWasCalledAsserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsAnOptionAsserts<FakeNewType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public ObjectAsserts<FakeNewType, AndReduceWasCalledAsserts> ReturnValue()
         => ObjectAsserts<FakeNewType, AndReduceWasCalledAsserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenNoneFunctionAsserts<FakeNewType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeNewType, AndReduceWasCalledAsserts> WhenNone()
         => FuncAsserts<FakeNewType, AndReduceWasCalledAsserts>
           .Create("whenNone",
                   _whenNone,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenSomeFunctionAsserts<FakeType, FakeNewType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeType, FakeNewType, AndReduceWasCalledAsserts> WhenSome()
         => FuncAsserts<FakeType, FakeNewType, AndReduceWasCalledAsserts>
           .Create("whenSome",
                   _whenSome,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal AndReduceWasCalledAsserts(FakeFunction<FakeType, FakeNewType> whenSome,
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
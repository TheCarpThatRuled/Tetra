using Tetra.Testing;

namespace Check;

public static class ReduceWasCalled
{
   public sealed class Asserts : IAsserts,
                                 IReturnsAsserts<FakeNewType, Asserts>,
                                 IWhenNoneFuncAsserts<FakeNewType, Asserts>,
                                 IWhenSomeFuncAsserts<FakeType, FakeNewType, Asserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsAnOptionAsserts<FakeNewType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public ObjectAsserts<FakeNewType, Asserts> ReturnValue()
         => ObjectAsserts<FakeNewType, Asserts>
           .Create("Return Value",
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenNoneFunctionAsserts<FakeNewType, Asserts> Methods
      /* ------------------------------------------------------------ */

      public FuncAsserts<FakeNewType, Asserts> WhenNone()
         => FuncAsserts<FakeNewType, Asserts>
           .Create("whenNone",
                   _whenNone,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenSomeFunctionAsserts<FakeType, FakeNewType, Asserts> Methods
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
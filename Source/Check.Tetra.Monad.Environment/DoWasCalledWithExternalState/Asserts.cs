using Tetra;
using Tetra.Testing;

namespace Check;

public static class DoWasCalledWithExternalState
{
   public sealed class Asserts : IAsserts,
                                 IReturnsThisAsserts<Asserts>,
                                 IWhenNoneActionAsserts<FakeExternalState, Asserts>,
                                 IWhenSomeActionAsserts<FakeExternalState, FakeType, Asserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsThisAsserts<Asserts> Methods
      /* ------------------------------------------------------------ */

      public ReturnsThisAsserts<Asserts> ReturnValue()
         => ReturnsThisAsserts<Asserts>
           .Create(_option,
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenNoneActionAsserts<FakeExternalState,Asserts> Methods
      /* ------------------------------------------------------------ */

      public ActionAsserts<FakeExternalState, Asserts> WhenNone()
         => ActionAsserts<FakeExternalState, Asserts>
           .Create("whenNone",
                   _whenNone,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenSomeActionAsserts<FakeExternalState,FakeType,Asserts> Methods
      /* ------------------------------------------------------------ */

      public ActionAsserts<FakeExternalState, FakeType, Asserts> WhenSome()
         => ActionAsserts<FakeExternalState, FakeType, Asserts>
           .Create("whenSome",
                   _whenSome,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal Asserts(IOption<FakeType>                       option,
                       FakeAction<FakeExternalState, FakeType> whenSome,
                       FakeAction<FakeExternalState>           whenNone,
                       IOption<FakeType>                       returnValue)
      {
         _option      = option;
         _returnValue = returnValue;
         _whenNone    = whenNone;
         _whenSome    = whenSome;
      }

      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IOption<FakeType>                       _option;
      private readonly IOption<FakeType>                       _returnValue;
      private readonly FakeAction<FakeExternalState>           _whenNone;
      private readonly FakeAction<FakeExternalState, FakeType> _whenSome;

      /* ------------------------------------------------------------ */
   }
}
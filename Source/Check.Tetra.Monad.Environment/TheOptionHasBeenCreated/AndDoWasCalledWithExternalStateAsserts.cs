using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheOptionHasBeenCreated
{
   public sealed class AndDoWasCalledWithExternalStateAsserts : IAsserts,
                                                                IReturnsThisAsserts<AndDoWasCalledWithExternalStateAsserts>,
                                                                IWhenNoneActionAsserts<FakeExternalState, AndDoWasCalledWithExternalStateAsserts>,
                                                                IWhenSomeActionAsserts<FakeExternalState, FakeType, AndDoWasCalledWithExternalStateAsserts>
   {
      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IOption<FakeType>                       _option;
      private readonly IOption<FakeType>                       _returnValue;
      private readonly FakeAction<FakeExternalState>           _whenNone;
      private readonly FakeAction<FakeExternalState, FakeType> _whenSome;

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal AndDoWasCalledWithExternalStateAsserts
      (
         IOption<FakeType>                       option,
         FakeAction<FakeExternalState, FakeType> whenSome,
         FakeAction<FakeExternalState>           whenNone,
         IOption<FakeType>                       returnValue
      )
      {
         _option      = option;
         _returnValue = returnValue;
         _whenNone    = whenNone;
         _whenSome    = whenSome;
      }
      /* ------------------------------------------------------------ */
      //  IReturnsThisAsserts<Asserts> Methods
      /* ------------------------------------------------------------ */

      public ReturnsThisAsserts<AndDoWasCalledWithExternalStateAsserts> ReturnValue()
         => ReturnsThisAsserts<AndDoWasCalledWithExternalStateAsserts>
           .Create(_option,
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenNoneActionAsserts<FakeExternalState,Asserts> Methods
      /* ------------------------------------------------------------ */

      public ActionAsserts<FakeExternalState, AndDoWasCalledWithExternalStateAsserts> WhenNone()
         => ActionAsserts<FakeExternalState, AndDoWasCalledWithExternalStateAsserts>
           .Create("whenNone",
                   _whenNone,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenSomeActionAsserts<FakeExternalState,FakeType,Asserts> Methods
      /* ------------------------------------------------------------ */

      public ActionAsserts<FakeExternalState, FakeType, AndDoWasCalledWithExternalStateAsserts> WhenSome()
         => ActionAsserts<FakeExternalState, FakeType, AndDoWasCalledWithExternalStateAsserts>
           .Create("whenSome",
                   _whenSome,
                   () => this);

      /* ------------------------------------------------------------ */
   }
}
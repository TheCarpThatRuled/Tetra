using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheEitherHasBeenCreated
{
   public sealed class AndDoWasCalledWithExternalStateAsserts : IAsserts,
                                                                IReturnsThisAsserts<AndDoWasCalledWithExternalStateAsserts>,
                                                                IWhenLeftActionAsserts<FakeExternalState, FakeLeft, AndDoWasCalledWithExternalStateAsserts>,
                                                                IWhenRightActionAsserts<FakeExternalState, FakeRight, AndDoWasCalledWithExternalStateAsserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsThisAsserts<AndDoWasCalledWithExternalStateAsserts> Methods
      /* ------------------------------------------------------------ */

      public ReturnsThisAsserts<AndDoWasCalledWithExternalStateAsserts> ReturnValue()
         => ReturnsThisAsserts<AndDoWasCalledWithExternalStateAsserts>
           .Create(_either,
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenLeftActionAsserts<FakeExternalState, FakeLeft, AndDoWasCalledWithExternalStateAsserts> Methods
      /* ------------------------------------------------------------ */

      public ActionAsserts<FakeExternalState, FakeLeft, AndDoWasCalledWithExternalStateAsserts> WhenLeft()
         => ActionAsserts<FakeExternalState, FakeLeft, AndDoWasCalledWithExternalStateAsserts>
           .Create("whenLeft",
                   _whenLeft,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenRightActionAsserts<FakeExternalState, FakeRight, AndDoWasCalledWithExternalStateAsserts> Methods
      /* ------------------------------------------------------------ */

      public ActionAsserts<FakeExternalState, FakeRight, AndDoWasCalledWithExternalStateAsserts> WhenRight()
         => ActionAsserts<FakeExternalState, FakeRight, AndDoWasCalledWithExternalStateAsserts>
           .Create("whenRight",
                   _whenRight,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal AndDoWasCalledWithExternalStateAsserts(IEither<FakeLeft, FakeRight>             option,
                                                      FakeAction<FakeExternalState, FakeLeft>  whenLeft,
                                                      FakeAction<FakeExternalState, FakeRight> whenRight,
                                                      IEither<FakeLeft, FakeRight>             returnValue)
      {
         _either      = option;
         _returnValue = returnValue;
         _whenLeft    = whenLeft;
         _whenRight   = whenRight;
      }

      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IEither<FakeLeft, FakeRight>             _either;
      private readonly IEither<FakeLeft, FakeRight>             _returnValue;
      private readonly FakeAction<FakeExternalState, FakeLeft>  _whenLeft;
      private readonly FakeAction<FakeExternalState, FakeRight> _whenRight;

      /* ------------------------------------------------------------ */
   }
}
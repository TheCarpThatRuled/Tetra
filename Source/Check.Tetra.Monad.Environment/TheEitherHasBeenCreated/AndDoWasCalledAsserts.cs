using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheEitherHasBeenCreated
{
   public sealed class AndDoWasCalledAsserts : IAsserts,
                                               IReturnsThisAsserts<AndDoWasCalledAsserts>,
                                               IWhenLeftActionAsserts<FakeLeft, AndDoWasCalledAsserts>,
                                               IWhenRightActionAsserts<FakeRight, AndDoWasCalledAsserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsThisAsserts<AndDoWasCalledAsserts> Methods
      /* ------------------------------------------------------------ */

      public ReturnsThisAsserts<AndDoWasCalledAsserts> ReturnValue()
         => ReturnsThisAsserts<AndDoWasCalledAsserts>
           .Create(_either,
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenLeftActionAsserts<FakeLeft,AndDoWasCalledAsserts> Methods
      /* ------------------------------------------------------------ */

      public ActionAsserts<FakeLeft, AndDoWasCalledAsserts> WhenLeft()
         => ActionAsserts<FakeLeft, AndDoWasCalledAsserts>
           .Create("whenLeft",
                   _whenLeft,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenRightActionAsserts<FakeRight, AndDoWasCalledAsserts> Methods
      /* ------------------------------------------------------------ */

      public ActionAsserts<FakeRight, AndDoWasCalledAsserts> WhenRight()
         => ActionAsserts<FakeRight, AndDoWasCalledAsserts>
           .Create("whenRight",
                   _whenRight,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal AndDoWasCalledAsserts(IEither<FakeLeft, FakeRight> option,
                                     FakeAction<FakeLeft>         whenLeft,
                                     FakeAction<FakeRight>        whenRight,
                                     IEither<FakeLeft, FakeRight> returnValue)
      {
         _either      = option;
         _returnValue = returnValue;
         _whenLeft    = whenLeft;
         _whenRight   = whenRight;
      }

      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IEither<FakeLeft, FakeRight> _either;
      private readonly IEither<FakeLeft, FakeRight> _returnValue;
      private readonly FakeAction<FakeLeft>         _whenLeft;
      private readonly FakeAction<FakeRight>        _whenRight;

      /* ------------------------------------------------------------ */
   }
}
using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheOptionHasBeenCreated
{
   public sealed class AndDoWasCalledAsserts : IAsserts,
                                               IReturnsThisAsserts<AndDoWasCalledAsserts>,
                                               IWhenNoneActionAsserts<AndDoWasCalledAsserts>,
                                               IWhenSomeActionAsserts<FakeType, AndDoWasCalledAsserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsThisAsserts<Asserts> Methods
      /* ------------------------------------------------------------ */

      public ReturnsThisAsserts<AndDoWasCalledAsserts> ReturnValue()
         => ReturnsThisAsserts<AndDoWasCalledAsserts>
           .Create(_option,
                   _returnValue,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenNoneActionAsserts<Asserts> Methods
      /* ------------------------------------------------------------ */

      public ActionAsserts<AndDoWasCalledAsserts> WhenNone()
         => ActionAsserts<AndDoWasCalledAsserts>
           .Create("whenNone",
                   _whenNone,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenSomeActionAsserts<FakeType,Asserts> Methods
      /* ------------------------------------------------------------ */

      public ActionAsserts<FakeType, AndDoWasCalledAsserts> WhenSome()
         => ActionAsserts<FakeType, AndDoWasCalledAsserts>
           .Create("whenSome",
                   _whenSome,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal AndDoWasCalledAsserts(IOption<FakeType>    option,
                                     FakeAction<FakeType> whenSome,
                                     FakeAction           whenNone,
                                     IOption<FakeType>    returnValue)
      {
         _option      = option;
         _returnValue = returnValue;
         _whenNone    = whenNone;
         _whenSome    = whenSome;
      }

      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IOption<FakeType>    _option;
      private readonly IOption<FakeType>    _returnValue;
      private readonly FakeAction           _whenNone;
      private readonly FakeAction<FakeType> _whenSome;

      /* ------------------------------------------------------------ */
   }
}
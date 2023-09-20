using Tetra;
using Tetra.Testing;

namespace Check;

public static class DoWasCalled
{
   public sealed class Asserts : IAsserts,
                                 IReturnsThisAsserts<Asserts>,
                                 IWhenNoneActionAsserts<Asserts>,
                                 IWhenSomeActionAsserts<FakeType, Asserts>
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
      //  IWhenNoneActionAsserts<Asserts> Methods
      /* ------------------------------------------------------------ */

      public ActionAsserts<Asserts> WhenNone()
         => ActionAsserts<Asserts>
           .Create("whenNone",
                   _whenNone,
                   () => this);

      /* ------------------------------------------------------------ */
      //  IWhenSomeActionAsserts<FakeType,Asserts> Methods
      /* ------------------------------------------------------------ */

      public ActionAsserts<FakeType, Asserts> WhenSome()
         => ActionAsserts<FakeType, Asserts>
           .Create("whenSome",
                   _whenSome,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal Asserts(IOption<FakeType>    option,
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
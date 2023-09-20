using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheOptionHasBeenCreated
{
   public sealed class Asserts : IAsserts,
                                 IReturnsAnOptionAsserts<FakeType, Asserts>
   {
      /* ------------------------------------------------------------ */
      //  IReturnsAnOptionAsserts<FakeType, Asserts>
      /* ------------------------------------------------------------ */

      public OptionAsserts<FakeType, Asserts> ReturnValue()
         => OptionAsserts<FakeType, Asserts>
           .Create("Return Value",
                   _option,
                   () => this);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal Asserts(IOption<FakeType> option)
         => _option = option;

      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IOption<FakeType> _option;

      /* ------------------------------------------------------------ */
   }
}
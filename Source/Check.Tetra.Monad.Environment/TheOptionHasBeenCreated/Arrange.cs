using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheOptionHasBeenCreated
{
   public sealed class Arrange : IArranges
   {
      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IOption<FakeType> _option;

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal Arrange
      (
         IOption<FakeType> option
      )
         => _option = option;
      /* ------------------------------------------------------------ */
      //  Methods
      /* ------------------------------------------------------------ */

      public Act ToActs()
         => new(_option);

      /* ------------------------------------------------------------ */
   }
}
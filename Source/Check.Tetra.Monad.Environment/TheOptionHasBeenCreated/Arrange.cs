using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheOptionHasBeenCreated
{
   public sealed class Arrange : IArranges
   {
      /* ------------------------------------------------------------ */
      //  Methods
      /* ------------------------------------------------------------ */

      public Act ToActs()
         => new(_option);

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal Arrange(IOption<FakeType> option)
         => _option = option;

      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IOption<FakeType> _option;

      /* ------------------------------------------------------------ */
   }
}

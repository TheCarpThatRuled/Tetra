using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheEitherHasBeenCreated
{
   public sealed class Arrange : IArranges
   {
      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IEither<FakeLeft, FakeRight> _either;

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal Arrange
      (
         IEither<FakeLeft, FakeRight> option
      )
         => _either = option;
      /* ------------------------------------------------------------ */
      //  Methods
      /* ------------------------------------------------------------ */

      public Act ToActs()
         => new(_either);

      /* ------------------------------------------------------------ */
   }
}
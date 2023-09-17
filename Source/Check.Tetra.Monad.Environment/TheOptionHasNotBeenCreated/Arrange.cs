using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheOptionHasNotBeenCreated
{
   public sealed class Arrange : IArranges
   {
      /* ------------------------------------------------------------ */
      //  Methods
      /* ------------------------------------------------------------ */

      public TheOptionHasBeenCreated.Arrange CallOptionSomeT(FakeType content)
         => new(Option.Some(content));

      /* ------------------------------------------------------------ */

      public TheOptionHasBeenCreated.Arrange CallOptionTNone()
         => new(Option<FakeType>.None());

      /* ------------------------------------------------------------ */

      public TheOptionHasBeenCreated.Arrange CallOptionTSome(FakeType content)
         => new(Option<FakeType>.Some(content));

      /* ------------------------------------------------------------ */

      public Act ToActs()
         => new();

      /* ------------------------------------------------------------ */
      //  Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static Arrange Start(AAA_test.Disposables disposable)
         => new();

      /* ------------------------------------------------------------ */
      //  Private Constructors
      /* ------------------------------------------------------------ */

      private Arrange() { }

      /* ------------------------------------------------------------ */
   }
}

using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheEitherHasNotBeenCreated
{
   public sealed class Arrange : IArranges
   {
      /* ------------------------------------------------------------ */
      //  Private Constructors
      /* ------------------------------------------------------------ */

      private Arrange() { }
      /* ------------------------------------------------------------ */
      //  Methods
      /* ------------------------------------------------------------ */

      public TheEitherHasBeenCreated.Arrange CallEitherRight
      (
         FakeRight? content
      )
         => new(Either<FakeLeft, FakeRight>.Right(content!));

      /* ------------------------------------------------------------ */

      public TheEitherHasBeenCreated.Arrange CallEitherLeft
      (
         FakeLeft? content
      )
         => new(Either<FakeLeft, FakeRight>.Left(content!));

      /* ------------------------------------------------------------ */

      public Act ToActs()
         => new();

      /* ------------------------------------------------------------ */
      //  Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static Arrange Start
      (
         AAA_test.Disposables disposable
      )
         => new();

      /* ------------------------------------------------------------ */
   }
}
using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheEitherHasNotBeenCreated
{
   public sealed class Arrange : IArranges
   {
      /* ------------------------------------------------------------ */
      //  Methods
      /* ------------------------------------------------------------ */

      public TheEitherHasBeenCreated.Arrange CallEitherTRight(FakeRight? content)
         => new(Either<FakeLeft, FakeRight>.Right(content!));

      /* ------------------------------------------------------------ */

      public TheEitherHasBeenCreated.Arrange CallEitherTLeft(FakeLeft? content)
         => new(Either<FakeLeft, FakeRight>.Left(content!));

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
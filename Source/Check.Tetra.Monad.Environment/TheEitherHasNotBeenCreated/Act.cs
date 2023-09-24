using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheEitherHasNotBeenCreated
{
   public sealed class Act : IActs
   {
      /* ------------------------------------------------------------ */
      //  Methods
      /* ------------------------------------------------------------ */

      public EitherAsserts<FakeLeft, FakeRight, TestTerminus> CallEitherRight(FakeRight? content)
      {
         var actual = Either<FakeLeft, FakeRight>.Right(content!);

         return EitherAsserts<FakeLeft, FakeRight, TestTerminus>.Create("Return value",
                                                                        actual,
                                                                        TestTerminus.Create);
      }

      /* ------------------------------------------------------------ */

      public EitherAsserts<FakeLeft, FakeRight, TestTerminus> CallEitherLeft(FakeLeft? content)
      {
         var actual = Either<FakeLeft, FakeRight>.Left(content!);

         return EitherAsserts<FakeLeft, FakeRight, TestTerminus>.Create("Return value",
                                                                        actual,
                                                                        TestTerminus.Create);
      }

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal Act() { }

      /* ------------------------------------------------------------ */
   }
}
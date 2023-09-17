using Tetra;
using Tetra.Testing;

namespace Check;
public static partial class TheOptionHasNotBeenCreated
{
   public sealed class Act : IActs
   {
      /* ------------------------------------------------------------ */
      //  Methods
      /* ------------------------------------------------------------ */

      public TheOptionHasBeenCreated.Asserts CallOptionSomeT(FakeType content)
         => new(Option.Some(content));

      /* ------------------------------------------------------------ */

      public TheOptionHasBeenCreated.Asserts CallOptionTNone()
         => new(Option<FakeType>.None());

      /* ------------------------------------------------------------ */

      public TheOptionHasBeenCreated.Asserts CallOptionTSome(FakeType content)
         => new(Option<FakeType>.Some(content));

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal Act() { }

      /* ------------------------------------------------------------ */
   }
}

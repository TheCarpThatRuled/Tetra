using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheOptionHasNotBeenCreated
{
   public sealed class Act : IActs
   {
      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal Act() { }
      /* ------------------------------------------------------------ */
      //  Methods
      /* ------------------------------------------------------------ */

      public OptionAsserts<FakeType, TestTerminus> CallOptionSomeT
      (
         FakeType? content
      )
      {
         var actual = Option.Some(content!);

         return OptionAsserts<FakeType, TestTerminus>.Create("Return value",
                                                             actual,
                                                             TestTerminus.Create);
      }

      /* ------------------------------------------------------------ */

      public OptionAsserts<FakeType, TestTerminus> CallOptionTNone()
      {
         var actual = Option<FakeType>.None();

         return OptionAsserts<FakeType, TestTerminus>.Create("Return value",
                                                             actual,
                                                             TestTerminus.Create);
      }

      /* ------------------------------------------------------------ */

      public OptionAsserts<FakeType, TestTerminus> CallOptionTSome
      (
         FakeType? content
      )
      {
         var actual = Option<FakeType>.Some(content!);

         return OptionAsserts<FakeType, TestTerminus>.Create("Return value",
                                                             actual,
                                                             TestTerminus.Create);
      }

      /* ------------------------------------------------------------ */
   }
}
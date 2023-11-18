using Tetra;
using Tetra.Testing;

namespace Check.Check_Label;

using static AAA_test<Actions, Asserts>;

public static partial class Steps
{
   public sealed class TheSystem
   {
      /* ------------------------------------------------------------ */
      // ArrangeAct Functions
      /* ------------------------------------------------------------ */

      public IArrangeAct Updates_Content
      (
         object content
      )
         => AtomicArrangeAct
           .Create($"{nameof(The_system)}.{nameof(Updates_Content)}: {content}",
                   environment => environment
                                 .Content
                                 .Push(content)
                                 .Next());

      /* ------------------------------------------------------------ */

      public IArrangeAct Updates_Visibility
      (
         Visibility visibility
      )
         => AtomicArrangeAct
           .Create($"{nameof(The_system)}.{nameof(Updates_Visibility)}: {visibility}",
                   environment => environment
                                 .Visibility
                                 .Push(visibility)
                                 .Next());

      /* ------------------------------------------------------------ */
   }
}
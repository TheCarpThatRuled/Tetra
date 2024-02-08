using Tetra;
using Tetra.Testing;

namespace Check.Check_Label;

using static AAA_test<Actions, Asserts>;

public static partial class Steps
{
   public sealed class TheSystem
   {
      /* ------------------------------------------------------------ */
      // Actions
      /* ------------------------------------------------------------ */

      public IAction Updates_Content
      (
         object content
      )
         => AtomicAction
           .Create($"{nameof(The_system)}.{nameof(Updates_Content)}: {content}",
                   environment => environment
                                 .Content
                                 .Push(content)
                                 .Next());

      /* ------------------------------------------------------------ */

      public IAction Updates_Visibility
      (
         Visibility visibility
      )
         => AtomicAction
           .Create($"{nameof(The_system)}.{nameof(Updates_Visibility)}: {visibility}",
                   environment => environment
                                 .Visibility
                                 .Push(visibility)
                                 .Next());

      /* ------------------------------------------------------------ */
   }
}
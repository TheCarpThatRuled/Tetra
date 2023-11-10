using Tetra;
using Tetra.Testing;
// ReSharper disable InconsistentNaming

namespace Check.Check_Button;

using static AAA_test<Actions, Asserts>;

partial class Steps
{
   public sealed class TheSystem
   {
      /* ------------------------------------------------------------ */
      // ArrangeAct Functions
      /* ------------------------------------------------------------ */

      public IArrangeAct updates_IsEnabled
      (
         bool enabled
      )
         => AtomicArrangeAct
           .Create($"{nameof(The_system)}.{nameof(updates_IsEnabled)}: {enabled}",
                   actions => actions
                             .IsEnabled
                             .Push(enabled)
                             .Next());

      /* ------------------------------------------------------------ */

      public IArrangeAct updates_Visibility
      (
         Visibility visibility
      )
         => AtomicArrangeAct
           .Create($"{nameof(The_system)}.{nameof(updates_Visibility)}: {visibility}",
                   actions => actions
                             .Visibility
                             .Push(visibility)
                             .Next());

      /* ------------------------------------------------------------ */
   }
}
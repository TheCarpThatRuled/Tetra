using Tetra.Testing;
// ReSharper disable InconsistentNaming

namespace Check.Check_Button;

using static AAA_test<Actions, Asserts>;

partial class Steps
{
   public sealed class TheUI
   {
      /* ------------------------------------------------------------ */
      // Given Functions
      /* ------------------------------------------------------------ */

      public IInitialArrange has_not_created_the_button()
         => AtomicInitialArrange
           .Create($"{nameof(The_UI)}.{nameof(has_not_created_the_button)}",
                   Actions.Start);

      /* ------------------------------------------------------------ */

      public IInitialArrange has_created_the_button
      (
         The_UI_creates_a_button args
      )
         => has_not_created_the_button()
           .And(creates_the_button(args))
           .Recharacterise($"{nameof(The_UI)}.{nameof(has_created_the_button)}: {args.BriefCharacterisation()}");

      /* ------------------------------------------------------------ */
      // ArrangeAct Functions
      /* ------------------------------------------------------------ */

      public IArrangeAct creates_the_button
      (
         The_UI_creates_a_button args
      )
         => AtomicArrangeAct
           .Create($"{nameof(The_UI)}.{nameof(creates_the_button)}: {args.BriefCharacterisation()}",
                   actions => actions.CreateButton(args));

      /* ------------------------------------------------------------ */
   }
}
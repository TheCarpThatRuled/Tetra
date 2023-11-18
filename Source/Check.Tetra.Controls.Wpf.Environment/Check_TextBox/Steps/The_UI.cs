using Tetra.Testing;

namespace Check.Check_TextBox;

using static AAA_test<Actions, Asserts>;

public static partial class Steps
{
   // ReSharper disable once InconsistentNaming
   public sealed class TheUI
   {
      /* ------------------------------------------------------------ */
      // Given Functions
      /* ------------------------------------------------------------ */

      public IInitialArrange Has_not_created_the_text_box()
         => AtomicInitialArrange
           .Create($"{nameof(The_UI)}.{nameof(Has_not_created_the_text_box)}",
                   Actions.Start);

      /* ------------------------------------------------------------ */

      public IInitialArrange Has_created_the_text_box
      (
         The_UI_creates_a_text_box args
      )
         => Has_not_created_the_text_box()
           .And(Creates_the_text_box(args))
           .Recharacterise($"{nameof(The_UI)}.{nameof(Has_created_the_text_box)}: {args.BriefCharacterisation()}");

      /* ------------------------------------------------------------ */
      // ArrangeAct Functions
      /* ------------------------------------------------------------ */

      public IArrangeAct Creates_the_text_box
      (
         The_UI_creates_a_text_box args
      )
         => AtomicArrangeAct
           .Create($"{nameof(The_UI)}.{nameof(Creates_the_text_box)}: {args.BriefCharacterisation()}",
                   environment => environment.CreateTextBox(args));

      /* ------------------------------------------------------------ */
   }
}
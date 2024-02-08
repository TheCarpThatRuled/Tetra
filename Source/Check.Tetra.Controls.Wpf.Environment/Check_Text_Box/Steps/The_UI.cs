using Tetra.Testing;

namespace Check.Check_Text_Box;

using static AAA_test<Actions, Asserts>;

public static partial class Steps
{
   // ReSharper disable once InconsistentNaming
   public sealed class TheUI
   {
      /* ------------------------------------------------------------ */
      // Givens
      /* ------------------------------------------------------------ */

      public IInitialAction Has_not_created_the_text_box()
         => AtomicInitialAction
           .Create($"{nameof(The_UI)}.{nameof(Has_not_created_the_text_box)}",
                   _=> Actions.Start());

      /* ------------------------------------------------------------ */

      public IInitialAction Has_created_the_text_box
      (
         The_UI_creates_a_text_box args
      )
         => Has_not_created_the_text_box()
           .And(Creates_the_text_box(args))
           .Recharacterise($"{nameof(The_UI)}.{nameof(Has_created_the_text_box)}: {args.BriefCharacterisation()}");

      /* ------------------------------------------------------------ */
      // Actions
      /* ------------------------------------------------------------ */

      public IAction Creates_the_text_box
      (
         The_UI_creates_a_text_box args
      )
         => AtomicAction
           .Create($"{nameof(The_UI)}.{nameof(Creates_the_text_box)}: {args.BriefCharacterisation()}",
                   environment => environment.CreateTextBox(args));

      /* ------------------------------------------------------------ */
   }
}
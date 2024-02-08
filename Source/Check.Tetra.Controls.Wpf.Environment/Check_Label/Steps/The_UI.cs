using Tetra.Testing;

namespace Check.Check_Label;

using static AAA_test<Actions, Asserts>;

public static partial class Steps
{
   // ReSharper disable once InconsistentNaming
   public sealed class TheUI
   {
      /* ------------------------------------------------------------ */
      // Givens
      /* ------------------------------------------------------------ */

      public IInitialAction Has_not_created_the_label()
         => AtomicInitialAction
           .Create($"{nameof(The_UI)}.{nameof(Has_not_created_the_label)}",
                   _ => Actions.Start());

      /* ------------------------------------------------------------ */

      public IInitialAction Has_created_the_label
      (
         The_UI_creates_a_label args
      )
         => Has_not_created_the_label()
           .And(Creates_the_label(args))
           .Recharacterise($"{nameof(The_UI)}.{nameof(Has_created_the_label)}: {args.BriefCharacterisation()}");

      /* ------------------------------------------------------------ */
      // Actions
      /* ------------------------------------------------------------ */

      public IAction Creates_the_label
      (
         The_UI_creates_a_label args
      )
         => AtomicAction
           .Create($"{nameof(The_UI)}.{nameof(Creates_the_label)}: {args.BriefCharacterisation()}",
                   environment => environment.CreateLabel(args));

      /* ------------------------------------------------------------ */
   }
}
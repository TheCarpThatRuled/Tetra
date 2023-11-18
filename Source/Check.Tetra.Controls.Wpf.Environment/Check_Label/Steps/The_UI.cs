using Tetra.Testing;

namespace Check.Check_Label;

using static AAA_test<Actions, Asserts>;

public static partial class Steps
{
   // ReSharper disable once InconsistentNaming
   public sealed class TheUI
   {
      /* ------------------------------------------------------------ */
      // Given Functions
      /* ------------------------------------------------------------ */

      public IInitialArrange Has_not_created_the_label()
         => AtomicInitialArrange
           .Create($"{nameof(The_UI)}.{nameof(Has_not_created_the_label)}",
                   Actions.Start);

      /* ------------------------------------------------------------ */

      public IInitialArrange Has_created_the_label
      (
         The_UI_creates_a_label args
      )
         => Has_not_created_the_label()
           .And(Creates_the_label(args))
           .Recharacterise($"{nameof(The_UI)}.{nameof(Has_created_the_label)}: {args.BriefCharacterisation()}");

      /* ------------------------------------------------------------ */
      // ArrangeAct Functions
      /* ------------------------------------------------------------ */

      public IArrangeAct Creates_the_label
      (
         The_UI_creates_a_label args
      )
         => AtomicArrangeAct
           .Create($"{nameof(The_UI)}.{nameof(Creates_the_label)}: {args.BriefCharacterisation()}",
                   environment => environment.CreateLabel(args));

      /* ------------------------------------------------------------ */
   }
}
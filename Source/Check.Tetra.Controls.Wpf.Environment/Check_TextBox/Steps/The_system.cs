using Tetra;
using Tetra.Testing;

namespace Check.Check_TextBox;

using static AAA_test<Actions, Asserts>;

public static partial class Steps
{
   public sealed class TheSystem
   {
      /* ------------------------------------------------------------ */
      // ArrangeAct Functions
      /* ------------------------------------------------------------ */

      public IArrangeAct Updates_IsEnabled
      (
         bool enabled
      )
         => AtomicArrangeAct
           .Create($"{nameof(The_system)}_{nameof(Updates_IsEnabled)}: {enabled}",
                   environment => environment
                                 .IsEnabled
                                 .Push(enabled)
                                 .Next());

      /* ------------------------------------------------------------ */

      public IArrangeAct Updates_Text
      (
         string text
      )
         => AtomicArrangeAct
           .Create($@"{nameof(The_system)}_{nameof(Updates_Text)}: ""{text}""",
                   environment => environment
                                 .Text
                                 .Push(text)
                                 .Next());

      /* ------------------------------------------------------------ */

      public IArrangeAct Updates_Visibility
      (
         Visibility visibility
      )
         => AtomicArrangeAct
           .Create($"{nameof(The_system)}_{nameof(Updates_Visibility)}: {visibility}",
                   environment => environment
                                 .Visibility
                                 .Push(visibility)
                                 .Next());

      /* ------------------------------------------------------------ */
      // Assert Functions
      /* ------------------------------------------------------------ */

      public IAssert Text_is
      (
         string expected
      )
         => AtomicAssert
           .Create($@"{nameof(The_system)}_{nameof(Text_is)}: ""{expected}""",
                   environment => environment
                                 .Text
                                 .Contains(expected)
                                 .Next());

      /* ------------------------------------------------------------ */
   }
}
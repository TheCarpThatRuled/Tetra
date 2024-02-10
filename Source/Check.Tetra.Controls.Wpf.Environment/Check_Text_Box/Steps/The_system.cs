using Tetra;
using Tetra.Testing;

namespace Check.Check_Text_Box;

using static AAA_test<Actions, Asserts>;

public static partial class Steps
{
   public sealed class TheSystem
   {
      /* ------------------------------------------------------------ */
      // Actions
      /* ------------------------------------------------------------ */

      public IAction Updates_IsEnabled
      (
         bool enabled
      )
         => AtomicAction
           .Create($"{nameof(The_system)}_{nameof(Updates_IsEnabled)}: {enabled}",
                   environment => environment
                                 .IsEnabled
                                 .Push(enabled)
                                 .Next());

      /* ------------------------------------------------------------ */

      public IAction Updates_Text
      (
         string text
      )
         => AtomicAction
           .Create($"""
                    {nameof(The_system)}_{nameof(Updates_Text)}: "{text}"
                    """,
                   environment => environment
                                 .Text
                                 .Push(text)
                                 .Next());

      /* ------------------------------------------------------------ */

      public IAction Updates_Visibility
      (
         Visibility visibility
      )
         => AtomicAction
           .Create($"{nameof(The_system)}_{nameof(Updates_Visibility)}: {visibility}",
                   environment => environment
                                 .Visibility
                                 .Push(visibility)
                                 .Next());

      /* ------------------------------------------------------------ */
      // Asserts
      /* ------------------------------------------------------------ */

      public IAssert Text_is
      (
         string expected
      )
         => AtomicAssert
           .Create($"""
                    {nameof(The_system)}_{nameof(Text_is)}: "{expected}"
                    """,
                   environment => environment
                                 .Text
                                 .Contains(expected)
                                 .Next());

      /* ------------------------------------------------------------ */
   }
}
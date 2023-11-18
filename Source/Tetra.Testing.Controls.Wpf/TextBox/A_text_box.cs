using System.Windows;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class A_text_box
{
   /* ------------------------------------------------------------ */
   // ArrangeAct Functions
   /* ------------------------------------------------------------ */

   public static AAA_test<TActions, TAsserts>.IArrangeAct receives_text<TActions, TAsserts>
   (
      string                                   text,
      string                                   actor,
      string                                   textBoxCharacterisation,
      Func<TActions, TextBoxActions<TActions>> getActions
   )
      where TActions : ITestEnvironment<TAsserts>
      => AAA_test<TActions, TAsserts>
        .AtomicArrangeAct
        .Create($@"{actor}_enters_text_in_{textBoxCharacterisation}: ""{text}""",
                actions => getActions(actions)
                          .EnterText(text)
                          .Next());

   /* ------------------------------------------------------------ */
   // Assert Functions
   /* ------------------------------------------------------------ */

   public static AAA_test<TActions, TAsserts>.IAssert IsEnabled_is<TActions, TAsserts>
   (
      bool                                     expected,
      string                                   characterisationHeader,
      Func<TAsserts, TextBoxAsserts<TAsserts>> getAsserts
   )
      where TActions : ITestEnvironment<TAsserts>
      => AAA_test<TActions, TAsserts>
        .AtomicAssert
        .Create($"{characterisationHeader}.{nameof(IsEnabled_is)}: {expected}",
                asserts => getAsserts(asserts)
                          .EnabledEquals(expected)
                          .Next());

   /* ------------------------------------------------------------ */

   public static AAA_test<TActions, TAsserts>.IAssert Matches<TActions, TAsserts>
   (
      Expected_text_box                        expected,
      string                                   characterisationHeader,
      Func<TAsserts, TextBoxAsserts<TAsserts>> getAsserts
   )
      where TActions : ITestEnvironment<TAsserts>
      => Text_is<TActions, TAsserts>(expected.Text(),
                                     characterisationHeader,
                                     getAsserts)
        .And(IsEnabled_is<TActions, TAsserts>(expected.IsEnabled(),
                                              characterisationHeader,
                                              getAsserts))
        .And(Visibility_is<TActions, TAsserts>(expected.Visibility(),
                                               characterisationHeader,
                                               getAsserts));

   /* ------------------------------------------------------------ */

   public static AAA_test<TActions, TAsserts>.IAssert Text_is<TActions, TAsserts>
   (
      string                                   expected,
      string                                   characterisationHeader,
      Func<TAsserts, TextBoxAsserts<TAsserts>> getAsserts
   )
      where TActions : ITestEnvironment<TAsserts>
      => AAA_test<TActions, TAsserts>
        .AtomicAssert
        .Create($"{characterisationHeader}.{nameof(Text_is)}: {expected}",
                asserts => getAsserts(asserts)
                          .TextEquals(expected)
                          .Next());

   /* ------------------------------------------------------------ */

   public static AAA_test<TActions, TAsserts>.IAssert Visibility_is<TActions, TAsserts>
   (
      Visibility                               expected,
      string                                   characterisationHeader,
      Func<TAsserts, TextBoxAsserts<TAsserts>> getAsserts
   )
      where TActions : ITestEnvironment<TAsserts>
      => AAA_test<TActions, TAsserts>
        .AtomicAssert
        .Create($"{characterisationHeader}.{nameof(Visibility_is)}: {expected.ToHumanReadable()}",
                asserts => getAsserts(asserts)
                          .VisibilityEquals(expected)
                          .Next());

   /* ------------------------------------------------------------ */
}
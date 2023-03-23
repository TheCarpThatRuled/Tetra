using System.Windows;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class A_text_box
{
   /* ------------------------------------------------------------ */
   // Assert Functions
   /* ------------------------------------------------------------ */

   public static IAssert<TextBoxAsserts<T>, TextBoxAsserts<T>> IsEnabled_is<T>(bool   expected,
                                                                               string characterisationHeader)
      where T : IAsserts
      => AtomicAssert<TextBoxAsserts<T>, TextBoxAsserts<T>>
        .Create(asserts => asserts.IsEnabled_is(expected),
                $"{characterisationHeader}.{nameof(IsEnabled_is)}: {expected}");

   /* ------------------------------------------------------------ */

   public static IAssert<TextBoxAsserts<T>, T> Matches<T>(Expected_text_box expected,
                                                          string            characterisationHeader)
      where T : IAsserts
      => Text_is<T>(expected.Text(),
                    characterisationHeader)
        .And(IsEnabled_is<T>(expected.IsEnabled(),
                             characterisationHeader))
        .And(Visibility_is<T>(expected.Visibility(),
                              characterisationHeader))
        .And(ReturnToParent<T>());

   /* ------------------------------------------------------------ */

   public static IAssert<TextBoxAsserts<T>, T> ReturnToParent<T>()
      where T : IAsserts
      => SilentAssert<TextBoxAsserts<T>, T>
        .Create(asserts => asserts.ReturnToParent());

   /* ------------------------------------------------------------ */

   public static IAssert<TextBoxAsserts<T>, TextBoxAsserts<T>> Text_is<T>(string expected,
                                                                          string characterisationHeader)
      where T : IAsserts
      => AtomicAssert<TextBoxAsserts<T>, TextBoxAsserts<T>>
        .Create(asserts => asserts.Text_is(expected),
                $"{characterisationHeader}.{nameof(Text_is)}: {expected}");

   /* ------------------------------------------------------------ */

   public static IAssert<TextBoxAsserts<T>, TextBoxAsserts<T>> Visibility_is<T>(Visibility expected,
                                                                                string     characterisationHeader)
      where T : IAsserts
      => AtomicAssert<TextBoxAsserts<T>, TextBoxAsserts<T>>
        .Create(asserts => asserts.Visibility_is(expected),
                $"{characterisationHeader}.{nameof(Visibility_is)}: {expected.ToHumanReadable()}");

   /* ------------------------------------------------------------ */
}
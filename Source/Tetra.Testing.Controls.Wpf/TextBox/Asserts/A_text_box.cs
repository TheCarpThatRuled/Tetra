using System.Windows;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class A_text_box
{
   /* ------------------------------------------------------------ */
   // Assert Functions
   /* ------------------------------------------------------------ */

   public static AAA_test.IAssert<TextBoxAsserts<T>, TextBoxAsserts<T>> IsEnabled_is<T>
   (
      bool   expected,
      string characterisationHeader
   )
      where T : IAsserts
      => AAA_test.AtomicAssert<TextBoxAsserts<T>, TextBoxAsserts<T>>
                 .Create($"{characterisationHeader}.{nameof(IsEnabled_is)}: {expected}",
                         asserts => asserts.IsEnabled_is(expected));

   /* ------------------------------------------------------------ */

   public static AAA_test.IAssert<TextBoxAsserts<T>, T> Matches<T>
   (
      Expected_text_box expected,
      string            characterisationHeader
   )
      where T : IAsserts
      => Text_is<T>(expected.Text(),
                    characterisationHeader)
        .And(IsEnabled_is<T>(expected.IsEnabled(),
                             characterisationHeader))
        .And(Visibility_is<T>(expected.Visibility(),
                              characterisationHeader))
        .And(ReturnToParent<T>());

   /* ------------------------------------------------------------ */

   public static AAA_test.IAssert<TextBoxAsserts<T>, T> ReturnToParent<T>()
      where T : IAsserts
      => AAA_test.SilentAssert<TextBoxAsserts<T>, T>
                 .Create(asserts => asserts.ReturnToParent());

   /* ------------------------------------------------------------ */

   public static AAA_test.IAssert<TextBoxAsserts<T>, TextBoxAsserts<T>> Text_is<T>
   (
      string expected,
      string characterisationHeader
   )
      where T : IAsserts
      => AAA_test.AtomicAssert<TextBoxAsserts<T>, TextBoxAsserts<T>>
                 .Create($"{characterisationHeader}.{nameof(Text_is)}: {expected}",
                         asserts => asserts.Text_is(expected));

   /* ------------------------------------------------------------ */

   public static AAA_test.IAssert<TextBoxAsserts<T>, TextBoxAsserts<T>> Visibility_is<T>
   (
      Visibility expected,
      string     characterisationHeader
   )
      where T : IAsserts
      => AAA_test.AtomicAssert<TextBoxAsserts<T>, TextBoxAsserts<T>>
                 .Create($"{characterisationHeader}.{nameof(Visibility_is)}: {expected.ToHumanReadable()}",
                         asserts => asserts.Visibility_is(expected));

   /* ------------------------------------------------------------ */
}
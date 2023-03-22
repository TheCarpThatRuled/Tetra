using System.Windows;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class A_label
{
   /* ------------------------------------------------------------ */
   // Assert Functions
   /* ------------------------------------------------------------ */

   public static IAssert<LabelAsserts<T>, T> Matches<T>(Expected_label expected,
                                                        string         characterisationHeader)
      where T : IAsserts
      => Content_is<T>(expected.Content(),
                       characterisationHeader)
        .And(Visibility_is<T>(expected.Visibility(),
                              characterisationHeader))
        .And(ReturnToParent<T>());

   /* ------------------------------------------------------------ */

   public static IAssert<LabelAsserts<T>, LabelAsserts<T>> Content_is<T>(object expected,
                                                                         string characterisationHeader)
      where T : IAsserts
      => AtomicAssert<LabelAsserts<T>, LabelAsserts<T>>
        .Create(asserts => asserts.Content_is(expected),
                $"{characterisationHeader}.{nameof(Content_is)}: {expected}");

   /* ------------------------------------------------------------ */

   public static IAssert<LabelAsserts<T>, T> ReturnToParent<T>()
      where T : IAsserts
      => SilentAssert<LabelAsserts<T>, T>
        .Create(asserts => asserts.ReturnToParent());

   /* ------------------------------------------------------------ */

   public static IAssert<LabelAsserts<T>, LabelAsserts<T>> Visibility_is<T>(Visibility expected,
                                                                            string     characterisationHeader)
      where T : IAsserts
      => AtomicAssert<LabelAsserts<T>, LabelAsserts<T>>
        .Create(asserts => asserts.Visibility_is(expected),
                $"{characterisationHeader}.{nameof(Visibility_is)}: {expected.ToHumanReadable()}");

   /* ------------------------------------------------------------ */
}
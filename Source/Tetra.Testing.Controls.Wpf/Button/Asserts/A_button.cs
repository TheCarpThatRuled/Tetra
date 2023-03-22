using System.Windows;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class A_button
{
   /* ------------------------------------------------------------ */
   // Assert Functions
   /* ------------------------------------------------------------ */

   public static IAssert<ButtonAsserts<T>, ButtonAsserts<T>> IsEnabled_is<T>(bool   expected,
                                                                             string characterisationHeader)
      where T : IAsserts
      => AtomicAssert<ButtonAsserts<T>, ButtonAsserts<T>>
        .Create(asserts => asserts.IsEnabled_is(expected),
                $"{characterisationHeader}.{nameof(IsEnabled_is)}: {expected}");

   /* ------------------------------------------------------------ */

   public static IAssert<ButtonAsserts<T>, T> Matches<T>(Expected_button expected,
                                                         string          characterisationHeader)
      where T : IAsserts
      => IsEnabled_is<T>(expected.IsEnabled(),
                         characterisationHeader)
        .And(Visibility_is<T>(expected.Visibility(),
                              characterisationHeader))
        .And(ReturnToParent<T>());

   /* ------------------------------------------------------------ */

   public static IAssert<ButtonAsserts<T>, T> ReturnToParent<T>()
      where T : IAsserts
      => SilentAssert<ButtonAsserts<T>, T>
        .Create(asserts => asserts.ReturnToParent());

   /* ------------------------------------------------------------ */

   public static IAssert<ButtonAsserts<T>, ButtonAsserts<T>> Visibility_is<T>(Visibility expected,
                                                                              string     characterisationHeader)
      where T : IAsserts
      => AtomicAssert<ButtonAsserts<T>, ButtonAsserts<T>>
        .Create(asserts => asserts.Visibility_is(expected),
                $"{characterisationHeader}.{nameof(Visibility_is)}: {expected.ToHumanReadable()}");

   /* ------------------------------------------------------------ */
}
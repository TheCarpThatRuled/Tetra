using System.Windows;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class A_button
{
   /* ------------------------------------------------------------ */
   // Assert Functions
   /* ------------------------------------------------------------ */

   public static AAA_test<TActions, TAsserts>.IAssert IsEnabled_is<TActions, TAsserts>
   (
      string                                  characterisationHeader,
      bool                                    expected,
      Func<TAsserts, ButtonAsserts<TAsserts>> getAsserts
   )
      where TActions : ITestEnvironment<TAsserts>
      => AAA_test<TActions, TAsserts>
        .AtomicAssert
        .Create($"{characterisationHeader}.{nameof(IsEnabled_is)}: {expected}",
                asserts => getAsserts(asserts)
                          .IsEnabled_is(expected)
                          .Next());

   /* ------------------------------------------------------------ */

   public static AAA_test<TActions, TAsserts>.IAssert Matches<TActions, TAsserts>
   (
      Expected_button                         expected,
      string                                  characterisationHeader,
      Func<TAsserts, ButtonAsserts<TAsserts>> getAsserts
   )
      where TActions : ITestEnvironment<TAsserts>
      => IsEnabled_is<TActions,TAsserts>(characterisationHeader,
                                         expected.IsEnabled(),
                                         getAsserts)
        .And(Visibility_is<TActions, TAsserts>(characterisationHeader,
                                               expected.Visibility(),
                                               getAsserts));

   /* ------------------------------------------------------------ */

   public static AAA_test<TActions, TAsserts>.IAssert Visibility_is<TActions, TAsserts>
   (
      string                                  characterisationHeader,
      Visibility                              expected,
      Func<TAsserts, ButtonAsserts<TAsserts>> getAsserts
   )
      where TActions : ITestEnvironment<TAsserts>
      => AAA_test<TActions, TAsserts>
        .AtomicAssert
        .Create($"{characterisationHeader}.{nameof(Visibility_is)}: {expected}",
                asserts => getAsserts(asserts)
                          .Visibility_is(expected)
                          .Next());

   /* ------------------------------------------------------------ */
}
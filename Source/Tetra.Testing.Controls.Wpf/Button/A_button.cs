using System.Windows;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class A_button
{
   /* ------------------------------------------------------------ */
   // ArrangeAct Functions
   /* ------------------------------------------------------------ */

   public static AAA_test<TActions, TAsserts>.IArrangeAct is_Clicked<TActions, TAsserts>
   (
      uint                                    numberOfClicks,
      string                                  actor,
      string                                  buttonCharacterisation,
      Func<TActions, ButtonActions<TActions>> getActions
   )
      where TActions : ITestEnvironment<TAsserts>
      => AAA_test<TActions, TAsserts>
        .AtomicArrangeAct
        .Create($"{actor}_clicks_{buttonCharacterisation}{(numberOfClicks != 1 ? $": {numberOfClicks} times" : string.Empty)}",
                actions => getActions(actions)
                          .Click(numberOfClicks)
                          .Next());

   /* ------------------------------------------------------------ */
   // Assert Functions
   /* ------------------------------------------------------------ */

   public static AAA_test<TActions, TAsserts>.IAssert Matches<TActions, TAsserts>
   (
      Expected_button                         expected,
      string                                  characterisationHeader,
      Func<TAsserts, ButtonAsserts<TAsserts>> getAsserts
   )
      where TActions : ITestEnvironment<TAsserts>
      => IsEnabled_is<TActions, TAsserts>(characterisationHeader,
                                          expected.IsEnabled(),
                                          getAsserts)
        .And(Visibility_is<TActions, TAsserts>(characterisationHeader,
                                               expected.Visibility(),
                                               getAsserts));

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
                          .IsEnabledEquals(expected)
                          .Next());

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
                          .VisibilityEquals(expected)
                          .Next());

   /* ------------------------------------------------------------ */
}
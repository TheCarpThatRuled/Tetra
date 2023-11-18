using System.Windows;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class A_label
{
    /* ------------------------------------------------------------ */
    // Assert Functions
    /* ------------------------------------------------------------ */

    public static AAA_test<TActions, TAsserts>.IAssert Matches<TActions, TAsserts>
    (
       Expected_label expected,
       string characterisationHeader,
       Func<TAsserts, LabelAsserts<TAsserts>> getAsserts
    )
       where TActions : ITestEnvironment<TAsserts>
       => Content_is<TActions, TAsserts>(expected.Content(),
                                         characterisationHeader,
                                         getAsserts)
         .And(Visibility_is<TActions, TAsserts>(expected.Visibility(),
                                                characterisationHeader,
                                                getAsserts));

    /* ------------------------------------------------------------ */

    public static AAA_test<TActions, TAsserts>.IAssert Content_is<TActions, TAsserts>
    (
       object expected,
       string characterisationHeader,
       Func<TAsserts, LabelAsserts<TAsserts>> getAsserts
    )
       where TActions : ITestEnvironment<TAsserts>
       => AAA_test<TActions, TAsserts>
         .AtomicAssert
         .Create($"{characterisationHeader}.{nameof(Content_is)}: {expected}",
                 asserts => getAsserts(asserts)
                           .ContentEquals(expected)
                           .Next());

    /* ------------------------------------------------------------ */

    public static AAA_test<TActions, TAsserts>.IAssert Visibility_is<TActions, TAsserts>
    (
       Visibility expected,
       string characterisationHeader,
       Func<TAsserts, LabelAsserts<TAsserts>> getAsserts
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
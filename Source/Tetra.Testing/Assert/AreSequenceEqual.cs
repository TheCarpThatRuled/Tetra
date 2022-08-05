
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Assert AreSequenceEqual<T>(this Assert     assert,
                                            string          description,
                                            IEnumerable<T>? expected,
                                            IEnumerable<T>? actual)
      => assert
        .AreSequenceEqual(description,
                          expected?.ToArray(),
                          actual?.ToArray());

   /* ------------------------------------------------------------ */

   public static Assert AreSequenceEqual<T>(this Assert       assert,
                                            string            description,
                                            IReadOnlyList<T>? expected,
                                            IReadOnlyList<T>? actual)
      => assert
        .AreSequenceEqual(description,
                          expected,
                          actual,
                          x => x?.ToString() ?? string.Empty,
                          x => x?.ToString() ?? string.Empty,
                          (e,
                           a,
                           d) => assert.AreEqual(d,
                                                 e,
                                                 a));

   /* ------------------------------------------------------------ */

   public static Assert AreSequenceEqual<T0, T1>(this Assert            assert,
                                                 string                 description,
                                                 IReadOnlyList<T0>?     expected,
                                                 IReadOnlyList<T1>?     actual,
                                                 Func<T0, string>       t0ToString,
                                                 Func<T1, string>       t1ToString,
                                                 Action<T0, T1, string> compareItem)
   {

      if (expected is null
       && actual is not null)
      {
         throw Failed.Assert($"{description} - the actual sequence was not null, when we expected it to be null");
      }

      if (actual is null)
      {
         throw Failed.Assert($"{description} - the actual sequence was null, when we expected it to be non-null");
      }

      var expectedAsString = expected
                            .Select(t0ToString)
                            .ToArray();
      var actualAsString = actual
                          .Select(t1ToString)
                          .ToArray();

      if (expected.Count != actual.Count)
      {
         throw Failed.Assert($"{description} - The sequences are unequal in length",
                             expectedAsString,
                             actualAsString);
      }

      foreach (var (expectedItem, index) in expected.WithIndices())
      {
         compareItem(expectedItem,
                     actual[index],
                     $"item at index {index}");
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
}
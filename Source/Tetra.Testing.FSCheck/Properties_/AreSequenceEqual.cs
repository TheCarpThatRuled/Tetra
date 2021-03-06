using FsCheck;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property AreSequenceEqual<T>(IEnumerable<T>? expected,
                                              IEnumerable<T>? actual)
      => AreSequenceEqual(expected?.ToArray(),
                          actual?.ToArray());

   /* ------------------------------------------------------------ */

   public static Property AreSequenceEqual<T>(IReadOnlyCollection<T>? expected,
                                              IReadOnlyCollection<T>? actual)
      => AsProperty(() => expected is null
                             ? actual is null
                             : actual is not null
                            && expected.SequenceEqual(actual))
        .Label(Failed.ExpectedActual(expected,
                                     actual));

   /* ------------------------------------------------------------ */

   public static Property AreSequenceEqual<T>(IReadOnlyCollection<T>? expected,
                                              IReadOnlyCollection<T>? actual,
                                              string                  description)
      => AreSequenceEqual(expected,
                          actual,
                          x => x?.ToString() ?? string.Empty,
                          x => x?.ToString() ?? string.Empty,
                          (e,
                           a,
                           d) => AreEqual(d,
                                          e,
                                          a),
                          description);

   /* ------------------------------------------------------------ */

   public static Property AreSequenceEqual<T0, T1>(IReadOnlyCollection<T0>?       expected,
                                                   IReadOnlyCollection<T1>?       actual,
                                                   Func<T0, string>               t0ToString,
                                                   Func<T1, string>               t1ToString,
                                                   Func<T0, T1, string, Property> compareItem,
                                                   string                         description)
   {
      if (expected is null)
      {
         return actual is null
                   ? True()
                   : False($"{description} - the actual sequence was not null, when we expected it to be null");
      }

      if (actual is null)
      {
         return False($"{description} - the actual sequence was null, when we expected it to be non-null");
      }

      var expectedAsString = expected
                            .Select(t0ToString)
                            .ToArray();
      var actualAsString = actual
                          .Select(t1ToString)
                          .ToArray();

      if (expected.Count != actual.Count)
      {
         return False(Failed.Message($"{description} - The sequences are unequal in length",
                                     expectedAsString,
                                     actualAsString));
      }

      return expected
            .Zip(actual)
            .WithIndices()
            .Aggregate(True(Failed.Message(description,
                                           expectedAsString,
                                           actualAsString)),
                       (total,
                        next) => total.And(compareItem(next.item.First,
                                                       next.item.Second,
                                                       $"item at index {next.index}")));
   }

   /* ------------------------------------------------------------ */
}
namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property AreSetEqual<T>
   (
      string          description,
      IEnumerable<T>? expected,
      IEnumerable<T>? actual
   )
      => AreSetEqual(description,
                     expected?.Materialise(),
                     actual?.Materialise());

   /* ------------------------------------------------------------ */

   public static Property AreSetEqual<T>
   (
      string        description,
      ISequence<T>? expected,
      ISequence<T>? actual
   )
      => AreSetEqual(description,
                     expected,
                     actual,
                     x => x?.ToString() ?? string.Empty,
                     x => x?.ToString() ?? string.Empty,
                     (
                        e,
                        a
                     ) => Equals(e,
                                 a));

   /* ------------------------------------------------------------ */

   public static Property AreSetEqual<T0, T1>
   (
      string             description,
      ISequence<T0>?     expected,
      ISequence<T1>?     actual,
      Func<T0, string>   t0ToString,
      Func<T1, string>   t1ToString,
      Func<T0, T1, bool> compareItem
   )
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

      if (expected.Length() != actual.Length())
      {
         return False(Failed.InTheAsserts($"{description} - The sequences are unequal in length",
                                          Failed.Expected(expectedAsString),
                                          Failed.Actual(actualAsString)));
      }

      return actual
            .WithIndices()
            .Aggregate(True(),
                       (
                          total,
                          next
                       ) => total.And(IsTrue(Failed.InTheAsserts($"{description} - the item at {next.index} was not in the expected sequence",
                                                                 Failed.Actual(next.index)),
                                             expected.Any(e => compareItem(e,
                                                                           next.item)))));
   }

   /* ------------------------------------------------------------ */
}
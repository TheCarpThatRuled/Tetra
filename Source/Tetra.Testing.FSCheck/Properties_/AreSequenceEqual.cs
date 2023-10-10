using FsCheck;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property AreSequenceEqual<T>
   (
      string          description,
      IEnumerable<T>? expected,
      IEnumerable<T>? actual
   )
      => AreSequenceEqual(description,
                          expected?.Materialise(),
                          actual?.Materialise());

   /* ------------------------------------------------------------ */

   public static Property AreSequenceEqual<T>
   (
      string        description,
      ISequence<T>? expected,
      ISequence<T>? actual
   )
      => AreSequenceEqual(description,
                          expected,
                          actual,
                          x => x?.ToString() ?? string.Empty,
                          x => x?.ToString() ?? string.Empty,
                          (
                             e,
                             a,
                             d
                          ) => AreEqual(d,
                                        e,
                                        a));

   /* ------------------------------------------------------------ */

   public static Property AreSequenceEqual<T0, T1>
   (
      string                         description,
      ISequence<T0>?                 expected,
      ISequence<T1>?                 actual,
      Func<T0, string>               t0ToString,
      Func<T1, string>               t1ToString,
      Func<T0, T1, string, Property> compareItem
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
                       (
                          total,
                          next
                       ) => total.And(compareItem(next.item.First,
                                                  next.item.Second,
                                                  $"item at index {next.index}")));
   }

   /* ------------------------------------------------------------ */
}
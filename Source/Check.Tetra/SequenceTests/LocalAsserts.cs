using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.SequenceTests;

internal static class LocalAsserts
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static Assert TetraSequenceEquals<T>(this Assert    assert,
                                               IEnumerable<T> expected,
                                               ISequence<T>   actual)
   {
      var expectedAsArray = expected as T[]
                         ?? expected.ToArray();

      assert.AreEqual("Length",
                      expectedAsArray.Length,
                      actual.Length())
            .IsTrue("IEnumerable.SequenceEqual",
                    expectedAsArray.SequenceEqual(actual));

      foreach (var (expectedItem, index) in expectedAsArray.WithIndices())
      {
         assert.AreEqual($"Item {index} - [int]",
                         expectedItem,
                         actual[index]);
         assert.AreEqual($"Item {index} - [uint]",
                         expectedItem,
                         actual[(uint) index]);
         assert.AreEqual($"Item {index} - [Index]",
                         expectedItem,
                         actual[new Index(index)]);
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property TetraSequenceEquals<T>(IEnumerable<T> expected,
                                                 ISequence<T>   actual)
   {
      var expectedAsArray = expected as T[]
                         ?? expected.ToArray();

      return AreEqual("Length",
                      expectedAsArray.Length,
                      actual.Length())
            .And(IsTrue("IEnumerable.SequenceEqual",
                        expectedAsArray.SequenceEqual(actual)))
            .And(TetraSequenceAllIndicesMatch(expectedAsArray,
                                              actual));
   }

   /* ------------------------------------------------------------ */
   // Private Functions
   /* ------------------------------------------------------------ */

   private static Property TetraSequenceAllIndicesMatch<T>(T[]          expectedAsArray,
                                                          ISequence<T> actual)
      => expectedAsArray
        .WithIndices()
        .Aggregate(True(),
                   (total,
                    next) => total
                            .And(AreEqual($"Item {next.index} - [int]",
                                          next.item,
                                          actual[next.index]))
                            .And(AreEqual($"Item {next.index} - [uint]",
                                          next.item,
                                          actual[(uint) next.index]))
                            .And(AreEqual($"Item {next.index} - [Index]",
                                          next.item,
                                          actual[new Index(next.index)])));

   /* ------------------------------------------------------------ */
}
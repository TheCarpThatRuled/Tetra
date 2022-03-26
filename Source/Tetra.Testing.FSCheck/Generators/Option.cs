using System.Diagnostics;
using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<Option<T>> Option<T>(Gen<T> content)
      => Gen
        .Frequency(new Tuple<int, Gen<Option<T>>>(1,
                                                  Gen.Constant(Tetra
                                                              .Option<T>
                                                              .None())),
                   new Tuple<int, Gen<Option<T>>>(7,
                                                  SomeOption(content)));

   /* ------------------------------------------------------------ */

   public static Gen<Option<T>> SomeOption<T>(Gen<T> content)
      => content
        .Select(Tetra
               .Option
               .Some);

   /* ------------------------------------------------------------ */

   public static Gen<(Option<T>, Option<T>)> TwoUniqueOptions<T>(Gen<T> content)
      => Option(content)
        .Two()
        .Where(tuple => tuple
                       .Item1
                       .Reduce(() => tuple
                                    .Item2
                                    .Reduce(() => false,
                                            _ => true),
                               i1 => tuple
                                    .Item2
                                    .Reduce(() => true,
                                            i2 => !Equals(i1,
                                                          i2))))
        .Select(tuple => (tuple.Item1, tuple.Item2));

   /* ------------------------------------------------------------ */

   public static Gen<(Option<T>, T, T)> TransitiveOptionAndT<T>(Gen<T> content,
                                                                Gen<(T, T)> twoUniqueContents)
      where T : notnull
      => Gen
        .Frequency(new Tuple<int, Gen<(Option<T>, T, T)>>(1,
                                                          content.Select(value => (Tetra.Option<T>.None(), value, value))),
                   new Tuple<int, Gen<(Option<T>, T, T)>>(4,
                                                          Transitive(twoUniqueContents,
                                                                     Tetra.Option.Some)));

   /* ------------------------------------------------------------ */
}
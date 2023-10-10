using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<IOption<T>> Option<T>
   (
      Gen<T> content
   )
      => Gen
        .Frequency(new Tuple<int, Gen<IOption<T>>>(1,
                                                   Gen.Constant(Tetra.Option<T>
                                                                     .None())),
                   new Tuple<int, Gen<IOption<T>>>(7,
                                                   SomeOption(content)));

   /* ------------------------------------------------------------ */

   public static Gen<IOption<T>> SomeOption<T>
   (
      Gen<T> content
   )
      => content
        .Select(Tetra.Option
                     .Some);

   /* ------------------------------------------------------------ */

   public static Gen<(IOption<T>, IOption<T>)> TwoUniqueOptions<T>
   (
      Gen<T> content
   )
      => Option(content)
        .TwoValueTuples()
        .Where(tuple => tuple
                       .first
                       .Unify(i1 => tuple
                                   .second
                                   .Unify(i2 => !Equals(i1,
                                                        i2),
                                          () => true),
                              () => tuple
                                   .second
                                   .IsASome()));

   /* ------------------------------------------------------------ */

   public static Gen<(IOption<T>, T, T)> TransitiveOptionAndT<T>
   (
      Gen<T>      content,
      Gen<(T, T)> twoUniqueContents
   )
      where T : notnull
      => Gen
        .Frequency(new Tuple<int, Gen<(IOption<T>, T, T)>>(1,
                                                           content.Select(value => (Tetra.Option<T>.None(), value, value))),
                   new Tuple<int, Gen<(IOption<T>, T, T)>>(4,
                                                           Transitive(twoUniqueContents,
                                                                      Tetra.Option.Some)));

   /* ------------------------------------------------------------ */
}
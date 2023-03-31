using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<IResult<T>> Result<T>(Gen<T> content)
      => Gen
        .Frequency(new Tuple<int, Gen<IResult<T>>>(1,
                                                   Gen.Constant(Tetra
                                                               .Result<T>
                                                               .Success())),
                   new Tuple<int, Gen<IResult<T>>>(7,
                                                   FailureResult(content)));

   /* ------------------------------------------------------------ */

   public static Gen<IResult<T>> FailureResult<T>(Gen<T> content)
      => content
        .Select(Tetra
               .Result
               .Failure);

   /* ------------------------------------------------------------ */

   public static Gen<(IResult<T>, IResult<T>)> TwoUniqueResults<T>(Gen<T> content)
      => Result(content)
        .TwoValueTuples()
        .Where(tuple => tuple
                       .first
                       .Reduce(() => tuple
                                    .second
                                    .IsAFailure(),
                               i1 => tuple
                                    .second
                                    .Reduce(() => true,
                                            i2 => !Equals(i1,
                                                          i2))));

   /* ------------------------------------------------------------ */

   public static Gen<(IResult<T>, T, T)> TransitiveResultsAndT<T>(Gen<T>      content,
                                                                  Gen<(T, T)> twoUniqueContents)
      where T : notnull
      => Gen
        .Frequency(new Tuple<int, Gen<(IResult<T>, T, T)>>(1,
                                                           content.Select(value => (Tetra.Result<T>.Success(), value, value))),
                   new Tuple<int, Gen<(IResult<T>, T, T)>>(4,
                                                           Transitive(twoUniqueContents,
                                                                      Tetra.Result.Failure)));

   /* ------------------------------------------------------------ */
}
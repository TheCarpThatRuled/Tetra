using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<IResult<T>> FailureResult<T>()
      => FailureResult<T>(Message());

   /* ------------------------------------------------------------ */

   public static Gen<IResult<T>> FailureResult<T>(Gen<Message> content)
      => content
        .Select(Tetra
               .Result<T>
               .Failure);

   /* ------------------------------------------------------------ */

   public static Gen<IResult<T>> Result<T>(Gen<T> content)
      => Result(content,
                Message());

   /* ------------------------------------------------------------ */

   public static Gen<IResult<T>> Result<T>(Gen<T>       successContent,
                                           Gen<Message> failureContent)
      => Gen
        .Frequency(new Tuple<int, Gen<IResult<T>>>(1,
                                                   FailureResult<T>(failureContent)),
                   new Tuple<int, Gen<IResult<T>>>(7,
                                                   SuccessResult(successContent)));

   /* ------------------------------------------------------------ */

   public static Gen<IResult<T>> SuccessResult<T>(Gen<T> content)
      => content
        .Select(Tetra
               .Result
               .Success);

   /* ------------------------------------------------------------ */

   public static Gen<(IResult<T>, IResult<T>)> TwoUniqueResults<T>(Gen<T> content)
      => TwoUniqueResults(content,
                          Message());

   /* ------------------------------------------------------------ */

   public static Gen<(IResult<T>, IResult<T>)> TwoUniqueResults<T>(Gen<T>       successContent,
                                                                   Gen<Message> failureContent)
      => Result(successContent,
                failureContent)
        .TwoValueTuples()
        .Where(tuple => tuple
                       .first
                       .Reduce(i1 => tuple
                                    .second
                                    .Reduce(i2 => !Equals(i1,
                                                          i2),
                                            _ => true),
                               i1 => tuple
                                    .second
                                    .Reduce(_ => true,
                                            i2 => !Equals(i1,
                                                          i2))));

   /* ------------------------------------------------------------ */

   public static Gen<(IResult<T>, T, T)> TransitiveResultAndT<T>(Gen<T>      content,
                                                                Gen<(T, T)> twoUniqueContents)
      where T : notnull
      => TransitiveResultAndT(content,
                              twoUniqueContents,
                              Message());

   /* ------------------------------------------------------------ */

   public static Gen<(IResult<T>, T, T)> TransitiveResultAndT<T>(Gen<T>       successContent,
                                                                Gen<(T, T)>  twoUniqueSuccessContents,
                                                                Gen<Message> failureContent)
      where T : notnull
      => Gen
        .Frequency(new Tuple<int, Gen<(IResult<T>, T, T)>>(1,
                                                          FailureResult<T>(failureContent)
                                                            .Zip(successContent)
                                                            .Select(tuple => (tuple.Item1, tuple.Item2, tuple.Item2))),
                   new Tuple<int, Gen<(IResult<T>, T, T)>>(4,
                                                          Transitive(twoUniqueSuccessContents,
                                                                     Tetra.Result
                                                                          .Success)));

   /* ------------------------------------------------------------ */
}
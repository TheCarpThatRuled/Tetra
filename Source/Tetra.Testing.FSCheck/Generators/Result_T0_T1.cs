using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<IResult<TSuccess, TFailure>> FailureResult<TSuccess, TFailure>(Gen<TFailure> content)
      => content
        .Select(Tetra
               .Result<TSuccess, TFailure>
               .Failure);

   /* ------------------------------------------------------------ */

   public static Gen<IResult<TSuccess, TFailure>> Result<TSuccess, TFailure>(Gen<TSuccess> successContent,
                                                                             Gen<TFailure> failureContent)
      => Gen
        .Frequency(new Tuple<int, Gen<IResult<TSuccess, TFailure>>>(1,
                                                                    FailureResult<TSuccess, TFailure>(failureContent)),
                   new Tuple<int, Gen<IResult<TSuccess, TFailure>>>(7,
                                                                    SuccessResult<TSuccess, TFailure>(successContent)));

   /* ------------------------------------------------------------ */

   public static Gen<IResult<TSuccess, TFailure>> SuccessResult<TSuccess, TFailure>(Gen<TSuccess> content)
      => content
        .Select(Tetra
               .Result<TSuccess, TFailure>
               .Success);

   /* ------------------------------------------------------------ */

   public static Gen<(IResult<TSuccess, TFailure>, IResult<TSuccess, TFailure>)> TwoUniqueResults<TSuccess, TFailure>(Gen<TSuccess> successContent,
                                                                                                                      Gen<TFailure> failureContent)
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

   public static Gen<(IResult<TSuccess, TFailure>, TSuccess, TSuccess)> TransitiveResultAndT<TSuccess, TFailure>(Gen<TSuccess>             successContent,
                                                                                                                 Gen<(TSuccess, TSuccess)> twoUniqueSuccessContents,
                                                                                                                 Gen<TFailure>             failureContent)
      where TSuccess : notnull
      => Gen
        .Frequency(new Tuple<int, Gen<(IResult<TSuccess, TFailure>, TSuccess, TSuccess)>>(1,
                                                                                          FailureResult<TSuccess, TFailure>(failureContent)
                                                                                            .Zip(successContent)
                                                                                            .Select(tuple => (tuple.Item1, tuple.Item2, tuple.Item2))),
                   new Tuple<int, Gen<(IResult<TSuccess, TFailure>, TSuccess, TSuccess)>>(4,
                                                                                          Transitive(twoUniqueSuccessContents,
                                                                                                     Tetra.Result<TSuccess, TFailure>
                                                                                                          .Success)));

   /* ------------------------------------------------------------ */
}
using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<Result<T>> FailureResult<T>()
      => FailureResult<T>(Message());

   /* ------------------------------------------------------------ */

   public static Gen<Result<T>> FailureResult<T>(Gen<Message> content)
      => content
        .Select(Tetra
               .Result<T>
               .Failure);

   /* ------------------------------------------------------------ */

   public static Gen<Result<T>> Result<T>(Gen<T> content)
      => Result(content,
                Message());

   /* ------------------------------------------------------------ */

   public static Gen<Result<T>> Result<T>(Gen<T>       successContent,
                                          Gen<Message> failureContent)
      => Gen
        .Frequency(new Tuple<int, Gen<Result<T>>>(1,
                                                  FailureResult<T>(failureContent)),
                   new Tuple<int, Gen<Result<T>>>(7,
                                                  SuccessResult(successContent)));

   /* ------------------------------------------------------------ */

   public static Gen<Result<T>> SuccessResult<T>(Gen<T> content)
      => content
        .Select(Tetra
               .Result
               .Success);

   /* ------------------------------------------------------------ */

   public static Gen<(Result<T>, Result<T>)> TwoUniqueResults<T>(Gen<T> content)
      => TwoUniqueResults(content,
                          Message());

   /* ------------------------------------------------------------ */

   public static Gen<(Result<T>, Result<T>)> TwoUniqueResults<T>(Gen<T>       successContent,
                                                                 Gen<Message> failureContent)
      => Result(successContent,
                failureContent)
        .Two()
        .Where(tuple => tuple
                       .Item1
                       .Reduce(i1 => tuple
                                    .Item2
                                    .Reduce(i2 => !Equals(i1,
                                                          i2),
                                            _ => true),
                               i1 => tuple
                                    .Item2
                                    .Reduce(i2 => true,
                                            i2 => !Equals(i1,
                                                          i2))))
        .Select(tuple => (tuple.Item1, tuple.Item2));

   /* ------------------------------------------------------------ */
}
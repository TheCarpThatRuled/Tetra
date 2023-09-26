using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<IEither<TLeft, TRight>> LeftEither<TLeft, TRight>(Gen<TLeft> content)
      => content
        .Select(Tetra
               .Either<TLeft, TRight>
               .Left);

   /* ------------------------------------------------------------ */

   public static Gen<IEither<TLeft, TRight>> Either<TLeft, TRight>(Gen<TLeft>  leftContent,
                                                                  Gen<TRight> rightContent)
      => Gen
        .OneOf(LeftEither<TLeft, TRight>(leftContent),
               RightEither<TLeft, TRight>(rightContent));

   /* ------------------------------------------------------------ */

   public static Gen<IEither<TLeft, TRight>> RightEither<TLeft, TRight>(Gen<TRight> content)
      => content
        .Select(Tetra
               .Either<TLeft, TRight>
               .Right);

   /* ------------------------------------------------------------ */

   public static Gen<(IEither<TLeft, TRight>, IEither<TLeft, TRight>)> TwoUniqueEithers<TLeft, TRight>(Gen<TLeft>  leftContent,
                                                                                                     Gen<TRight> rightContent)
      => Either(leftContent,
                rightContent)
        .TwoValueTuples()
        .Where(tuple => tuple
                       .first
                       .Unify(i1 => tuple
                                    .second
                                    .Unify(i2 => !Equals(i1,
                                                          i2),
                                            _ => true),
                               i1 => tuple
                                    .second
                                    .Unify(i2 => true,
                                            i2 => !Equals(i1,
                                                          i2))));

   /* ------------------------------------------------------------ */
}
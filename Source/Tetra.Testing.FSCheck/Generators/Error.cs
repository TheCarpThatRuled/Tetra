using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<Error> Error()
      => Error(Message());

   /* ------------------------------------------------------------ */

   public static Gen<Error> Error(Gen<Message> content)
      => Gen
        .Frequency(new Tuple<int, Gen<Error>>(1,
                                              Gen.Constant(Tetra
                                                          .Error
                                                          .None())),
                   new Tuple<int, Gen<Error>>(7,
                                              SomeError(content)));

   /* ------------------------------------------------------------ */

   public static Gen<Error> SomeError()
      => SomeError(Message());

   /* ------------------------------------------------------------ */

   public static Gen<Error> SomeError(Gen<Message> content)
      => content
        .Select(Tetra
               .Error
               .Some);

   /* ------------------------------------------------------------ */

   public static Gen<(Error, Error)> TwoUniqueErrors()
      => TwoUniqueErrors(Message());

   /* ------------------------------------------------------------ */

   public static Gen<(Error, Error)> TwoUniqueErrors(Gen<Message> content)
      => Error(content)
        .TwoValueTuples()
        .Where(tuple => tuple
                       .first
                       .Reduce(() => tuple
                                    .second
                                    .Reduce(() => false,
                                            _ => true),
                               i1 => tuple
                                    .second
                                    .Reduce(() => true,
                                            i2 => !Equals(i1,
                                                          i2))));

   /* ------------------------------------------------------------ */

   public static Gen<(Error, Message, Message)> TransitiveErrorAndMessages(Gen<Message> content,
                                                                           Gen<(Message, Message)> twoUniqueContents)
      => Gen
        .Frequency(new Tuple<int, Gen<(Error, Message, Message)>>(1,
                                                                  content.Select(value => (Tetra.Error.None(), value, value))),
                   new Tuple<int, Gen<(Error, Message, Message)>>(4,
                                                                  Transitive(twoUniqueContents,
                                                                             Tetra.Error.Some)));

   /* ------------------------------------------------------------ */
}
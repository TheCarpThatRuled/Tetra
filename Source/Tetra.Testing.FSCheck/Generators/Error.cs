using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<IError> Error()
      => Error(Message());

   /* ------------------------------------------------------------ */

   public static Gen<IError> Error(Gen<Message> content)
      => Gen
        .Frequency(new Tuple<int, Gen<IError>>(1,
                                              Gen.Constant(Tetra
                                                          .Error
                                                          .None())),
                   new Tuple<int, Gen<IError>>(7,
                                              SomeError(content)));

   /* ------------------------------------------------------------ */

   public static Gen<IError> SomeError()
      => SomeError(Message());

   /* ------------------------------------------------------------ */

   public static Gen<IError> SomeError(Gen<Message> content)
      => content
        .Select(Tetra
               .Error
               .Some);

   /* ------------------------------------------------------------ */

   public static Gen<(IError, IError)> TwoUniqueErrors()
      => TwoUniqueErrors(Message());

   /* ------------------------------------------------------------ */

   public static Gen<(IError, IError)> TwoUniqueErrors(Gen<Message> content)
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

   public static Gen<(IError, Message, Message)> TransitiveErrorAndMessages(Gen<Message> content,
                                                                           Gen<(Message, Message)> twoUniqueContents)
      => Gen
        .Frequency(new Tuple<int, Gen<(IError, Message, Message)>>(1,
                                                                  content.Select(value => (Tetra.Error.None(), value, value))),
                   new Tuple<int, Gen<(IError, Message, Message)>>(4,
                                                                  Transitive(twoUniqueContents,
                                                                             Tetra.Error.Some)));

   /* ------------------------------------------------------------ */
}
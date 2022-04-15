using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<Message> Message()
      => Message(NonNullString());

   /* ------------------------------------------------------------ */

   public static Gen<Message> Message(Gen<string> @string)
      => @string
        .Select(Tetra
               .Message
               .Create);

   /* ------------------------------------------------------------ */

   public static Gen<(Message, Message, Message)> ThreeUniqueMessages()
      => ThreeUniqueMessages(NonNullString());

   /* ------------------------------------------------------------ */

   public static Gen<(Message, Message, Message)> ThreeUniqueMessages(Gen<string> @string)
      => @string
        .Three()
        .Where(tuple => tuple.Item1 != tuple.Item2
                     && tuple.Item1 != tuple.Item3
                     && tuple.Item2 != tuple.Item3)
        .Select(tuple => (Tetra.Message.Create(tuple.Item1),
                          Tetra.Message.Create(tuple.Item2),
                          Tetra.Message.Create(tuple.Item3)));

   /* ------------------------------------------------------------ */

   public static Gen<(Message, Message)> TwoUniqueMessages()
      => TwoUniqueMessages(NonNullString());

   /* ------------------------------------------------------------ */

   public static Gen<(Message, Message)> TwoUniqueMessages(Gen<string> @string)
      => @string
        .Two()
        .Where(tuple => tuple.Item1 != tuple.Item2)
        .Select(tuple => (Tetra.Message.Create(tuple.Item1),
                          Tetra.Message.Create(tuple.Item2)));

   /* ------------------------------------------------------------ */
}
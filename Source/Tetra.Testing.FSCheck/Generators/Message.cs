namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<Message> Message()
      => Message(NonNullString());

   /* ------------------------------------------------------------ */

   public static Gen<Message> Message
   (
      Gen<string> @string
   )
      => @string
        .Select(Tetra.Message
                     .Create);

   /* ------------------------------------------------------------ */

   public static Gen<(Message, Message, Message)> ThreeUniqueMessages()
      => ThreeUniqueMessages(NonNullString());

   /* ------------------------------------------------------------ */

   public static Gen<(Message, Message, Message)> ThreeUniqueMessages
   (
      Gen<string> @string
   )
      => Message(@string)
        .ThreeValueTuples()
        .Where(tuple => tuple.first.Content()  != tuple.second.Content()
                     && tuple.first.Content()  != tuple.third.Content()
                     && tuple.second.Content() != tuple.third.Content());

   /* ------------------------------------------------------------ */

   public static Gen<(Message, Message)> TwoUniqueMessages()
      => TwoUniqueMessages(NonNullString());

   /* ------------------------------------------------------------ */

   public static Gen<(Message, Message)> TwoUniqueMessages
   (
      Gen<string> @string
   )
      => Message(@string)
        .TwoValueTuples()
        .Where(tuple => tuple.first.Content() != tuple.second.Content());

   /* ------------------------------------------------------------ */
}
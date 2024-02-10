namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property IsFalse
   (
      string description,
      bool   actual
   )
      => (!actual)
        .Label($"{description}: The boolean was true when we expected it to be false");

   /* ------------------------------------------------------------ */

   public static Property IsTrue
   (
      string description,
      bool   actual
   )
      => actual
        .Label($"{description}: The boolean was false when we expected it to be true");

   /* ------------------------------------------------------------ */
}
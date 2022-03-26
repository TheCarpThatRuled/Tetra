using System.Diagnostics;
using FsCheck;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property IsFalse(bool actual)
      => (!actual)
        .Label("The boolean was true when we expected it to be false");

   /* ------------------------------------------------------------ */

   public static Property IsTrue(bool actual)
      => actual
        .Label("The boolean was false when we expected it to be true");

   /* ------------------------------------------------------------ */
}
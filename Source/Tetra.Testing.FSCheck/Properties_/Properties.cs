using FsCheck;

namespace Tetra.Testing;

public static partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property AsProperty(Func<bool> property)
      => property
        .ToProperty();

   /* ------------------------------------------------------------ */

   public static Property False()
      => false
        .ToProperty();

   /* ------------------------------------------------------------ */

   public static Property False(string message)
      => false
        .Label(message);

   /* ------------------------------------------------------------ */

   public static Property True()
      => true
        .ToProperty();

   /* ------------------------------------------------------------ */

   public static Property True(string message)
      => true
        .Label(message);

   /* ------------------------------------------------------------ */
}
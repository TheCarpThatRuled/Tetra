using System.Text;

namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class String_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static bool IsAValidPathComponent(this string component)
      => !component.IsNotAValidPathComponent();

   /* ------------------------------------------------------------ */

   public static bool IsNotAValidPathComponent(this string component)
      => component
        .Any(character => Path
                         .GetInvalidFileNameChars()
                         .Contains(character));

   /* ------------------------------------------------------------ */

   public static string ToLiteral(this string value)
   {
      var literal = new StringBuilder();

      foreach (var character in value)
      {
         literal.Append(character.ToLiteral());
      }

      return literal.ToString();
   }

   /* ------------------------------------------------------------ */
}
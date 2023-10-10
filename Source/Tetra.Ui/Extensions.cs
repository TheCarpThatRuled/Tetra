using System.Diagnostics.CodeAnalysis;

namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class Visibility_Extensions
{
   /* ------------------------------------------------------------ */
   // Visibility Extensions
   /* ------------------------------------------------------------ */

   [ExcludeFromCodeCoverage]
   public static ArgumentOutOfRangeException OutOfRange
   (
      this Visibility visibility,
      string          argumentName
   )
      => new(argumentName,
             visibility,
             $"Unrecognised {typeof(Visibility).FullName}");

   /* ------------------------------------------------------------ */

   public static string ToHumanReadable
   (
      this Visibility value
   )
      => value switch
         {
            Visibility.Visible   => "Visible",
            Visibility.Collapsed => "Collapse",
            Visibility.Hidden    => "Hidden",
            //Code Coverage - Development guard
            _ => $"Unknown {typeof(Visibility).FullName} ({value})",
         };

   /* ------------------------------------------------------------ */
   // String Extensions
   /* ------------------------------------------------------------ */

   public static Visibility HumanReadableToTetraVisibility
   (
      this string value
   )
      => value switch
         {
            "Visible"  => Visibility.Visible,
            "Collapse" => Visibility.Collapsed,
            "Hidden"   => Visibility.Hidden,
            _ => throw new ArgumentOutOfRangeException(nameof(value),
                                                       value,
                                                       $"Not a recognised {typeof(Visibility).FullName}"),
         };

   /* ------------------------------------------------------------ */
}
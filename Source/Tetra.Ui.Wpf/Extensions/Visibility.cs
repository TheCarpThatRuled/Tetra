using System.Diagnostics.CodeAnalysis;

namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class Visibility_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   [ExcludeFromCodeCoverage]
   public static ArgumentOutOfRangeException OutOfRange
   (
      this System.Windows.Visibility visibility,
      string                         argumentName
   )
      => new(argumentName,
             visibility,
             $"Unrecognised {typeof(System.Windows.Visibility).FullName}");

   /* ------------------------------------------------------------ */

   public static string ToHumanReadable
   (
      this System.Windows.Visibility visibility
   )
      => visibility switch
         {
            System.Windows.Visibility.Collapsed => "Collapsed",
            System.Windows.Visibility.Hidden    => "Hidden",
            System.Windows.Visibility.Visible   => "Visible",
            //Code Coverage - Development guard
            _ => $"Unrecognised {typeof(System.Windows.Visibility).FullName} ({visibility})",
         };

   /* ------------------------------------------------------------ */

   public static Visibility ToTetra
   (
      this System.Windows.Visibility visibility
   )
      => visibility switch
         {
            System.Windows.Visibility.Collapsed => Visibility.Collapsed,
            System.Windows.Visibility.Hidden    => Visibility.Hidden,
            System.Windows.Visibility.Visible   => Visibility.Visible,
            //Code Coverage - Development guard
            _ => throw visibility.OutOfRange(nameof(visibility)),
         };

   /* ------------------------------------------------------------ */

   public static System.Windows.Visibility ToWpf
   (
      this Visibility visibility
   )
      => visibility switch
         {
            Visibility.Collapsed => System.Windows.Visibility.Collapsed,
            Visibility.Hidden    => System.Windows.Visibility.Hidden,
            Visibility.Visible   => System.Windows.Visibility.Visible,
            //Code Coverage - Development guard
            _ => throw visibility.OutOfRange(nameof(visibility)),
         };

   /* ------------------------------------------------------------ */
}
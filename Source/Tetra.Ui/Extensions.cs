namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class Visibility_Extensions
{
   /* ------------------------------------------------------------ */
   // Visibility Extensions
   /* ------------------------------------------------------------ */

   public static string ToHumanReadable(this Visibility value)
      => value switch
         {
            Visibility.Visible   => "Visible",
            Visibility.Collapsed => "Collapse",
            Visibility.Hidden    => "Hidden",
            _                    => $"Unknown visibility ({value})",
         };

   /* ------------------------------------------------------------ */
   // String Extensions
   /* ------------------------------------------------------------ */

   public static Visibility HumanReadableToTetraVisibility(this string value)
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
namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class Visibility_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static ArgumentOutOfRangeException OutOfRange(this Visibility visibility,
                                                        string          argumentName)
      => new(argumentName,
             visibility,
             $"Unrecognised {typeof(Visibility).FullName}");

   /* ------------------------------------------------------------ */

   public static ArgumentOutOfRangeException OutOfRange(this System.Windows.Visibility visibility,
                                                        string                         argumentName)
      => new(argumentName,
             visibility,
             $"Unrecognised {typeof(System.Windows.Visibility).FullName}");

   /* ------------------------------------------------------------ */

   public static System.Windows.Visibility ToWpf(this Visibility visibility)
      => visibility switch
         {
            Visibility.Collapsed => System.Windows.Visibility.Collapsed,
            Visibility.Hidden    => System.Windows.Visibility.Hidden,
            Visibility.Visible   => System.Windows.Visibility.Visible,
            _                    => throw visibility.OutOfRange(nameof(visibility)),
         };

   /* ------------------------------------------------------------ */

   public static Visibility ToTetra(this System.Windows.Visibility visibility)
      => visibility switch
         {
            System.Windows.Visibility.Collapsed => Visibility.Collapsed,
            System.Windows.Visibility.Hidden    => Visibility.Hidden,
            System.Windows.Visibility.Visible   => Visibility.Visible,
            _                                   => throw visibility.OutOfRange(nameof(visibility)),
         };

   /* ------------------------------------------------------------ */
}
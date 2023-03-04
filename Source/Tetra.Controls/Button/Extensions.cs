namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class Button_Extensions
{
   /* ------------------------------------------------------------ */
   // Factory Extensions
   /* ------------------------------------------------------------ */

   public static Button.DefineVisibility IsAlwaysEnabled(this Button.DefineIsEnabled factory)
      => factory
        .IsEnabled(Bind.Invariant(true));

   /* ------------------------------------------------------------ */

   public static Button IsAlwaysVisible(this Button.DefineVisibility factory)
      => factory
        .Visibility(Bind.Invariant(Visibility.Visible));

   /* ------------------------------------------------------------ */
}
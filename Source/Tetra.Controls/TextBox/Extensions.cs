namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class TextBox_Extensions
{
   /* ------------------------------------------------------------ */
   // Factory Extensions
   /* ------------------------------------------------------------ */

   public static TextBox.DefineVisibility IsAlwaysEnabled
   (
      this TextBox.DefineIsEnabled factory
   )
      => factory
        .IsEnabled(Bind.Invariant(true));

   /* ------------------------------------------------------------ */

   public static TextBox IsAlwaysVisible
   (
      this TextBox.DefineVisibility factory
   )
      => factory
        .Visibility(Bind.Invariant(Visibility.Visible));

   /* ------------------------------------------------------------ */
}
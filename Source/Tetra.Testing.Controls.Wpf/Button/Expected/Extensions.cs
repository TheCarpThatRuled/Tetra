// ReSharper disable InconsistentNaming

using System.Windows;

namespace Tetra.Testing;

public static class Expected_button_Extensions
{
   /* ------------------------------------------------------------ */
   // Factory Extensions
   /* ------------------------------------------------------------ */

   public static Expected_button.DefineVisibility IsEnabled_is_enabled(this Expected_button.DefineIsEnabled factory)
      => factory
        .IsEnabled_is(true);

   /* ------------------------------------------------------------ */

   public static Expected_button.DefineVisibility IsEnabled_is_disabled(this Expected_button.DefineIsEnabled factory)
      => factory
        .IsEnabled_is(false);

   /* ------------------------------------------------------------ */

   public static Expected_button Visibility_is_collapsed(this Expected_button.DefineVisibility factory)
      => factory
        .Visibility_is(Visibility.Collapsed);

   /* ------------------------------------------------------------ */

   public static Expected_button Visibility_is_hidden(this Expected_button.DefineVisibility factory)
      => factory
        .Visibility_is(Visibility.Hidden);

   /* ------------------------------------------------------------ */

   public static Expected_button Visibility_is_visible(this Expected_button.DefineVisibility factory)
      => factory
        .Visibility_is(Visibility.Visible);

   /* ------------------------------------------------------------ */
}
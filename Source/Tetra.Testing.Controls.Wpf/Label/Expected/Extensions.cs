// ReSharper disable InconsistentNaming

using System.Windows;

namespace Tetra.Testing;

public static class Expected_label_Extensions
{
   /* ------------------------------------------------------------ */
   // Except Extensions
   /* ------------------------------------------------------------ */

   public static T Visibility_is_collapsed<T>(this Expected_label.ExceptCarrier<T> except)
      => except
        .Visibility_is(Visibility.Collapsed);

   /* ------------------------------------------------------------ */

   public static T Visibility_is_hidden<T>(this Expected_label.ExceptCarrier<T> except)
      => except
        .Visibility_is(Visibility.Hidden);

   /* ------------------------------------------------------------ */

   public static T Visibility_is_visible<T>(this Expected_label.ExceptCarrier<T> except)
      => except
        .Visibility_is(Visibility.Visible);

   /* ------------------------------------------------------------ */
   // Factory Extensions
   /* ------------------------------------------------------------ */

   public static Expected_label Visibility_is_collapsed(this Expected_label.DefineVisibility factory)
      => factory
        .Visibility_is(Visibility.Collapsed);

   /* ------------------------------------------------------------ */

   public static Expected_label Visibility_is_hidden(this Expected_label.DefineVisibility factory)
      => factory
        .Visibility_is(Visibility.Hidden);

   /* ------------------------------------------------------------ */

   public static Expected_label Visibility_is_visible(this Expected_label.DefineVisibility factory)
      => factory
        .Visibility_is(Visibility.Visible);

   /* ------------------------------------------------------------ */
}
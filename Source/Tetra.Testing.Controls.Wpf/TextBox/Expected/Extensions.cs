// ReSharper disable InconsistentNaming

using System.Windows;

namespace Tetra.Testing;

public static class Expected_text_box_Extensions
{
   /* ------------------------------------------------------------ */
   // Except Extensions
   /* ------------------------------------------------------------ */

   public static T IsEnabled_is_enabled<T>
   (
      this Expected_text_box.ExceptCarrier<T> except
   )
      => except
        .IsEnabled_is(true);

   /* ------------------------------------------------------------ */

   public static T IsEnabled_is_disabled<T>
   (
      this Expected_text_box.ExceptCarrier<T> except
   )
      => except
        .IsEnabled_is(false);

   /* ------------------------------------------------------------ */

   public static T Visibility_is_collapsed<T>
   (
      this Expected_text_box.ExceptCarrier<T> except
   )
      => except
        .Visibility_is(Visibility.Collapsed);

   /* ------------------------------------------------------------ */

   public static T Visibility_is_hidden<T>
   (
      this Expected_text_box.ExceptCarrier<T> except
   )
      => except
        .Visibility_is(Visibility.Hidden);

   /* ------------------------------------------------------------ */

   public static T Visibility_is_visible<T>
   (
      this Expected_text_box.ExceptCarrier<T> except
   )
      => except
        .Visibility_is(Visibility.Visible);

   /* ------------------------------------------------------------ */
   // Factory Extensions
   /* ------------------------------------------------------------ */

   public static Expected_text_box.DefineVisibility IsEnabled_is_enabled
   (
      this Expected_text_box.DefineIsEnabled factory
   )
      => factory
        .IsEnabled_is(true);

   /* ------------------------------------------------------------ */

   public static Expected_text_box.DefineVisibility IsEnabled_is_disabled
   (
      this Expected_text_box.DefineIsEnabled factory
   )
      => factory
        .IsEnabled_is(false);

   /* ------------------------------------------------------------ */

   public static Expected_text_box Visibility_is_collapsed
   (
      this Expected_text_box.DefineVisibility factory
   )
      => factory
        .Visibility_is(Visibility.Collapsed);

   /* ------------------------------------------------------------ */

   public static Expected_text_box Visibility_is_hidden
   (
      this Expected_text_box.DefineVisibility factory
   )
      => factory
        .Visibility_is(Visibility.Hidden);

   /* ------------------------------------------------------------ */

   public static Expected_text_box Visibility_is_visible
   (
      this Expected_text_box.DefineVisibility factory
   )
      => factory
        .Visibility_is(Visibility.Visible);

   /* ------------------------------------------------------------ */
}
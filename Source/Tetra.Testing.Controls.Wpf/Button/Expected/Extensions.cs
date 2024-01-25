// ReSharper disable InconsistentNaming

using System.Windows;

namespace Tetra.Testing;

public static class Expected_button_Extensions
{
   /* ------------------------------------------------------------ */
   // Except Extensions
   /* ------------------------------------------------------------ */

   public static T IsEnabled_is_enabled<T>
   (
      this ExpectedButton.ExceptCarrier<T> except
   )
      => except
        .IsEnabled_is(true);

   /* ------------------------------------------------------------ */

   public static T IsEnabled_is_disabled<T>
   (
      this ExpectedButton.ExceptCarrier<T> except
   )
      => except
        .IsEnabled_is(false);

   /* ------------------------------------------------------------ */

   public static T Visibility_is_collapsed<T>
   (
      this ExpectedButton.ExceptCarrier<T> except
   )
      => except
        .Visibility_is(Visibility.Collapsed);

   /* ------------------------------------------------------------ */

   public static T Visibility_is_hidden<T>
   (
      this ExpectedButton.ExceptCarrier<T> except
   )
      => except
        .Visibility_is(Visibility.Hidden);

   /* ------------------------------------------------------------ */

   public static T Visibility_is_visible<T>
   (
      this ExpectedButton.ExceptCarrier<T> except
   )
      => except
        .Visibility_is(Visibility.Visible);

   /* ------------------------------------------------------------ */
   // Factory Extensions
   /* ------------------------------------------------------------ */

   public static ExpectedButton.DefineVisibility IsEnabled_is_enabled
   (
      this ExpectedButton.DefineIsEnabled factory
   )
      => factory
        .IsEnabled_is(true);

   /* ------------------------------------------------------------ */

   public static ExpectedButton.DefineVisibility IsEnabled_is_disabled
   (
      this ExpectedButton.DefineIsEnabled factory
   )
      => factory
        .IsEnabled_is(false);

   /* ------------------------------------------------------------ */

   public static ExpectedButton Visibility_is_collapsed
   (
      this ExpectedButton.DefineVisibility factory
   )
      => factory
        .Visibility_is(Visibility.Collapsed);

   /* ------------------------------------------------------------ */

   public static ExpectedButton Visibility_is_hidden
   (
      this ExpectedButton.DefineVisibility factory
   )
      => factory
        .Visibility_is(Visibility.Hidden);

   /* ------------------------------------------------------------ */

   public static ExpectedButton Visibility_is_visible
   (
      this ExpectedButton.DefineVisibility factory
   )
      => factory
        .Visibility_is(Visibility.Visible);

   /* ------------------------------------------------------------ */
}
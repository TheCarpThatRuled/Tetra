namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class Label_Extensions
{
   /* ------------------------------------------------------------ */
   // Factory Extensions
   /* ------------------------------------------------------------ */

   public static Label IsAlwaysVisible
   (
      this Label.DefineVisibility factory
   )
      => factory
        .Visibility(Bind.Invariant(Visibility.Visible));

   /* ------------------------------------------------------------ */
}
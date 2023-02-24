using Tetra;

namespace Check;

internal static class Data
{
   /* ------------------------------------------------------------ */
   // Constants
   /* ------------------------------------------------------------ */

   public static readonly ISequence<bool> TrueAndFalse = Sequence.From(true,
                                                                       false);

   /* ------------------------------------------------------------ */

   public static readonly ISequence<(Visibility tetra, System.Windows.Visibility wpf)> Visibilities
      = Sequence.From((Visibility.Collapsed, System.Windows.Visibility.Collapsed),
                      (Visibility.Hidden, System.Windows.Visibility.Hidden),
                      (Visibility.Visible, System.Windows.Visibility.Visible));

   /* ------------------------------------------------------------ */
}
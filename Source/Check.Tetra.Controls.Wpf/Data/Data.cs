using Tetra;

// ReSharper disable InconsistentNaming

namespace Check;

internal static class Data
{
   /* ------------------------------------------------------------ */
   // Constants
   /* ------------------------------------------------------------ */

   public static readonly ISequence<bool> True_and_false = Sequence.From(true,
                                                                         false);

   /* ------------------------------------------------------------ */

   public static readonly ISequence<(Tetra.Visibility tetra, System.Windows.Visibility wpf)> Visibilities
      = Sequence.From((Tetra.Visibility.Collapsed, System.Windows.Visibility.Collapsed),
                      (Tetra.Visibility.Hidden, System.Windows.Visibility.Hidden),
                      (Tetra.Visibility.Visible, System.Windows.Visibility.Visible));

   /* ------------------------------------------------------------ */
}
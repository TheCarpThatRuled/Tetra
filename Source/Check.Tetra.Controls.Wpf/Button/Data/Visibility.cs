namespace Check.Button;

internal static class Visibility
{
    /* ------------------------------------------------------------ */
    // Functions
    /* ------------------------------------------------------------ */

    public static Tetra.Visibility Tetra
    (
       string visibility
    )
       => visibility switch
       {
           "collapsed" => global::Tetra.Visibility.Collapsed,
           "hidden" => global::Tetra.Visibility.Hidden,
           "visible" => global::Tetra.Visibility.Visible,
           _ => throw new ArgumentOutOfRangeException(nameof(visibility),
                                                     visibility,
                                                     "The value is not a recognised visibility")
       };

    /* ------------------------------------------------------------ */

    public static System.Windows.Visibility Windows
    (
       string visibility
    )
       => visibility switch
       {
           "collapsed" => System.Windows.Visibility.Collapsed,
           "hidden" => System.Windows.Visibility.Hidden,
           "visible" => System.Windows.Visibility.Visible,
           _ => throw new ArgumentOutOfRangeException(nameof(visibility),
                                                     visibility,
                                                     "The value is not a recognised visibility")
       };

    /* ------------------------------------------------------------ */
}
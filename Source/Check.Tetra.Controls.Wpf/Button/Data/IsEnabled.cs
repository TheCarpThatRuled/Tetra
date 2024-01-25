namespace Check.Button;

internal static class IsEnabled
{
    /* ------------------------------------------------------------ */
    // Functions
    /* ------------------------------------------------------------ */

    public static bool From
    (
       string isEnabled
    )
       => isEnabled switch
       {
           "enabled" => true,
           "disabled" => false,
           _ => throw new ArgumentOutOfRangeException(nameof(isEnabled),
                                                     isEnabled,
                                                     "The value is not a recognised visibility")
       };

    /* ------------------------------------------------------------ */
}
namespace Check;

public static partial class Steps
{
    /* ------------------------------------------------------------ */
    // Properties
    /* ------------------------------------------------------------ */

    // ReSharper disable once InconsistentNaming
    public static TheClient the_Client { get; } = new();

   /* ------------------------------------------------------------ */

   // ReSharper disable once InconsistentNaming
   public static TheReturnValue the_return_value { get; } = new();

   /* ------------------------------------------------------------ */

   // ReSharper disable once InconsistentNaming
   public static WhenNone whenNone { get; } = new();

   /* ------------------------------------------------------------ */

   // ReSharper disable once InconsistentNaming
   public static WhenSome whenSome { get; } = new();

   /* ------------------------------------------------------------ */
}
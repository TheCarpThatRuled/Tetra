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
   public static TheWhenNoneAction the_whenNone_Action { get; } = new();

   /* ------------------------------------------------------------ */

   // ReSharper disable once InconsistentNaming
   public static TheWhenSomeAction the_whenSome_Action { get; } = new();

   /* ------------------------------------------------------------ */

   // ReSharper disable once InconsistentNaming
   public static TheWhenSomeFunc the_whenSome_Func { get; } = new();

   /* ------------------------------------------------------------ */
}
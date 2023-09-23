namespace Check;

partial class Steps
{
   public sealed partial class TheWhenSome
   {
      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public ForOption for_Option { get; } = new();

      /* ------------------------------------------------------------ */
      // Private Properties
      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      private Action action { get; } = new();

      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      private Function function { get; } = new();

      /* ------------------------------------------------------------ */
   }
}
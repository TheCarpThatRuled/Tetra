namespace Check;

partial class Steps
{
   public sealed partial class TheWhenLeft
   {
      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public ForDo for_Do { get; } = new();

      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public ForDoWithExternalState for_Do_with_externalState { get; } = new();

      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public ForMap for_Map { get; } = new();

      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public ForMapWithExternalState for_Map_with_externalState { get; } = new();

      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public ForUnify for_Unify { get; } = new();

      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public ForUnifyWithExternalState for_Unify_with_externalState { get; } = new();

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
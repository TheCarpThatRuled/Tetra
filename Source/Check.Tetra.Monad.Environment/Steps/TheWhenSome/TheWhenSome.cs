namespace Check;

partial class Steps
{
   public sealed partial class TheWhenSome
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
      public ForMapWithFuncToOption for_Map_with_func_to_IOption { get; } = new();

      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public ForMapWithFuncToOptionAndExternalState for_Map_with_func_to_IOption_and_externalState { get; } = new();

      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public ForReduce for_Reduce { get; } = new();

      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public ForReduceWithExternalState for_Reduce_with_externalState { get; } = new();

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
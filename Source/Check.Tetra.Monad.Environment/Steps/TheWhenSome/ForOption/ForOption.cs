namespace Check;

partial class Steps
{
   partial class TheWhenSome
   {
      public sealed partial class ForOption
      {
         /* ------------------------------------------------------------ */
         // Properties
         /* ------------------------------------------------------------ */

         // ReSharper disable once InconsistentNaming
         public ForDo Do { get; } = new();

         /* ------------------------------------------------------------ */

         // ReSharper disable once InconsistentNaming
         public ForDoWithExternalState Do_with_externalState { get; } = new();

         /* ------------------------------------------------------------ */

         // ReSharper disable once InconsistentNaming
         public ForMap Map { get; } = new();

         /* ------------------------------------------------------------ */

         // ReSharper disable once InconsistentNaming
         public ForMapWithExternalState Map_with_externalState { get; } = new();

         /* ------------------------------------------------------------ */

         // ReSharper disable once InconsistentNaming
         public ForMapWithFuncToOption Map_with_func_to_IOption { get; } = new();

         /* ------------------------------------------------------------ */

         // ReSharper disable once InconsistentNaming
         public ForMapWithFuncToOptionAndExternalState Map_with_func_to_IOption_and_externalState { get; } = new();

         /* ------------------------------------------------------------ */

         // ReSharper disable once InconsistentNaming
         public ForReduce Reduce { get; } = new();

         /* ------------------------------------------------------------ */

         // ReSharper disable once InconsistentNaming
         public ForReduceWithExternalState Reduce_with_externalState { get; } = new();

         /* ------------------------------------------------------------ */
      }
   }
}
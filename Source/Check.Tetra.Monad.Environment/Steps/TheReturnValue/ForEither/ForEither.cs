namespace Check;

partial class Steps
{
   partial class TheReturnValue
   {
      public sealed partial class ForEither
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
         public ForMapToEither Map_with_funcs_to_IEither { get; } = new();

         /* ------------------------------------------------------------ */

         // ReSharper disable once InconsistentNaming
         public ForMapToEitherWithExternalState Map_with_funcs_to_IEither_and_externalState { get; } = new();

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
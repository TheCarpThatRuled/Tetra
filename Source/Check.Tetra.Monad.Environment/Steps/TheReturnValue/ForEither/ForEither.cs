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
         public ForUnify Unify { get; } = new();

         /* ------------------------------------------------------------ */

         // ReSharper disable once InconsistentNaming
         public ForUnifyWithExternalState Unify_with_externalState { get; } = new();

         /* ------------------------------------------------------------ */
      }
   }
}
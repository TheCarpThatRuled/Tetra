namespace Tetra;

public static partial class Condition
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static ICondition False()
      => _false;

   /* ------------------------------------------------------------ */

   public static ICondition True()
      => _true;

   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   // ReSharper disable once InconsistentNaming
   private static readonly ICondition _false = new FalseCondition();
   // ReSharper disable once InconsistentNaming
   private static readonly ICondition _true = new TrueCondition();

   /* ------------------------------------------------------------ */
}
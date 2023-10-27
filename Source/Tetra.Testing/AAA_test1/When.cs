namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test1
{
   public sealed class When
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Then Act()
      {
         Log.When();
         return new(_act());
      }

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal When
      (
         Func<Action> act
      )
         => _act = act;

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Func<Action> _act;

      /* ------------------------------------------------------------ */
   }
}
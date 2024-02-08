namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test1
{
   public sealed class Then
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Action _assert;

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal Then
      (
         Action assert
      )
         => _assert = assert;

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public void Assert()
      {
         Log.Then();
         _assert();
      }

      /* ------------------------------------------------------------ */
   }
}
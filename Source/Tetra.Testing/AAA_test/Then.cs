namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test
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

      public Then
      (
         Action assert
      )
         => _assert = assert;
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public void Assert()
         => _assert();

      /* ------------------------------------------------------------ */
   }
}
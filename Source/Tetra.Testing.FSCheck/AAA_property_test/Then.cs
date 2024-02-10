namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test
{
   public sealed class Then
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Func<Property> _assert;

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      public Then
      (
         Func<Property> assert
      )
         => _assert = assert;

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Property Assert()
         => _assert();

      /* ------------------------------------------------------------ */
   }
}
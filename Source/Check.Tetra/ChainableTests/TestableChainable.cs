namespace Check.ChainableTests;

internal sealed class TestableChainable<T> : Chainable<T>
{
   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private TestableChainable
   (
      Func<T> next
   ) : base(next) { }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static TestableChainable<T> Create
   (
      Func<T> next
   )
      => new(next);

   /* ------------------------------------------------------------ */
}
using Tetra.Testing;

namespace Check.Check_Label;

public sealed class ActInstance<T>
   where T : IAssertsInstance
{
   /* ------------------------------------------------------------ */
   // Internal Constructors
   /* ------------------------------------------------------------ */

   internal ActInstance(Func<T> asserts)
      => _asserts = asserts;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   // ReSharper disable once InconsistentNaming
   public T THEN()
      => _asserts();

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Func<T> _asserts;

   /* ------------------------------------------------------------ */
}
using Tetra.Testing;

namespace Check.Check_Button;

public sealed class ActInstance<T>
   where T : IAssertsInstance
{
   /* ------------------------------------------------------------ */
   // Internal Constructors
   /* ------------------------------------------------------------ */

   internal ActInstance(Func<T> act)
      => _act = act;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   // ReSharper disable once InconsistentNaming
   public T THEN()
      => _act();

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Func<T> _act;

   /* ------------------------------------------------------------ */
}
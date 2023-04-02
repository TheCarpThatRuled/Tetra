using Tetra.Testing;

namespace Check.Check_Label;

public sealed class Act<T>
   where T : AAA_test.IAsserts
{
   /* ------------------------------------------------------------ */
   // Internal Constructors
   /* ------------------------------------------------------------ */

   internal Act(Func<T> act)
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
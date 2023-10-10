using Tetra.Testing;

namespace Check.Check_TextBox;

public sealed class Act<T>
   where T : IAsserts
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Func<T> _act;
   /* ------------------------------------------------------------ */
   // Internal Constructors
   /* ------------------------------------------------------------ */

   internal Act
   (
      Func<T> act
   )
      => _act = act;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   // ReSharper disable once InconsistentNaming
   public T THEN()
      => _act();

   /* ------------------------------------------------------------ */
}
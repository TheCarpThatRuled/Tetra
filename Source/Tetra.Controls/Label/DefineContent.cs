namespace Tetra;

partial class Label
{
   public sealed class DefineContent
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public DefineVisibility Content(IOneWayBinding<object> content)
         => new(content);

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineContent() { }

      /* ------------------------------------------------------------ */
   }
}
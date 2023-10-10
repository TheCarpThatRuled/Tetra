namespace Tetra;

partial class Label
{
   public sealed class DefineContent
   {
      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineContent() { }
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public DefineVisibility Content
      (
         IOneWayBinding<object> content
      )
         => new(content);

      /* ------------------------------------------------------------ */
   }
}
namespace Tetra;

partial class Label
{
   public sealed class DefineVisibility
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IOneWayBinding<object> _content;

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineVisibility
      (
         IOneWayBinding<object> content
      )
         => _content = content;
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Label Visibility
      (
         IOneWayBinding<Visibility> visibility
      )
         => new(_content,
                visibility);

      /* ------------------------------------------------------------ */
   }
}
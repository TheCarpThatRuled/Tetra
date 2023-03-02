namespace Tetra;

partial class Label
{
   public sealed class DefineVisibility
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Label Visibility(IOneWayBinding<Visibility> visibility)
         => new(_content,
                visibility);

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineVisibility(IOneWayBinding<object> content)
         => _content = content;

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IOneWayBinding<object> _content;

      /* ------------------------------------------------------------ */
   }
}
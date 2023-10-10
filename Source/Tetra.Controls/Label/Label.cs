namespace Tetra;

public sealed partial class Label
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IOneWayBinding<object>     _content;
   private readonly IOneWayBinding<Visibility> _visibility;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private Label
   (
      IOneWayBinding<object>     content,
      IOneWayBinding<Visibility> visibility
   )
   {
      _content    = content;
      _visibility = visibility;
   }
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static DefineContent Factory()
      => new();

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public IOneWayBinding<object> Content()
      => _content;

   /* ------------------------------------------------------------ */

   public IOneWayBinding<Visibility> Visibility()
      => _visibility;

   /* ------------------------------------------------------------ */
}
using Tetra;

namespace Check.Check_Label;

internal sealed class FakeSystem
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FakeSystem Create(The_UI_creates_a_label args)
      => new(Bind.To(args.Content()),
             Bind.To(args.Visibility()));

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public ITwoWayBinding<object> Content()
      => _content;

   /* ------------------------------------------------------------ */

   public ITwoWayBinding<Visibility> Visibility()
      => _visibility;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly ITwoWayBinding<object>     _content;
   private readonly ITwoWayBinding<Visibility> _visibility;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FakeSystem(ITwoWayBinding<object>     content,
                      ITwoWayBinding<Visibility> visibility)
   {
      _content    = content;
      _visibility = visibility;
   }

   /* ------------------------------------------------------------ */
}
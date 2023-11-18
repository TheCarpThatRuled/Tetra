using Tetra;

namespace Check.Check_TextBox;

internal sealed class FakeSystem
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly ITwoWayBinding<bool>       _isEnabled;
   private readonly ITwoWayBinding<string>     _text;
   private readonly ITwoWayBinding<Visibility> _visibility;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FakeSystem
   (
      ITwoWayBinding<bool>       isEnabled,
      ITwoWayBinding<string>     text,
      ITwoWayBinding<Visibility> visibility
   )
   {
      _isEnabled  = isEnabled;
      _text       = text;
      _visibility = visibility;
   }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FakeSystem Create
   (
      The_UI_creates_a_text_box args
   )
      => new(Bind.To(args.IsEnabled()),
             Bind.To(args.Text()),
             Bind.To(args.Visibility()));

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public ITwoWayBinding<bool> IsEnabled()
      => _isEnabled;

   /* ------------------------------------------------------------ */

   public ITwoWayBinding<string> Text()
      => _text;

   /* ------------------------------------------------------------ */

   public ITwoWayBinding<Visibility> Visibility()
      => _visibility;

   /* ------------------------------------------------------------ */
}
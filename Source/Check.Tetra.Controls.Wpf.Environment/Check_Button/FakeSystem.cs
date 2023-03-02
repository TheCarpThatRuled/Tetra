using Tetra;
using Tetra.Testing;

namespace Check.Check_Button;

internal sealed class FakeSystem
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FakeSystem Create(The_UI_creates_a_button args)
      => new(Bind.To(args.IsEnabled()),
             Bind.To(args.Visibility()));

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public ITwoWayBinding<bool> IsEnabled()
      => _isEnabled;

   /* ------------------------------------------------------------ */

   public FakeAction OnClick()
      => _onClick;

   /* ------------------------------------------------------------ */

   public ITwoWayBinding<Visibility> Visibility()
      => _visibility;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly FakeAction _onClick = FakeAction.Create();

   private readonly ITwoWayBinding<bool>       _isEnabled;
   private readonly ITwoWayBinding<Visibility> _visibility;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FakeSystem(ITwoWayBinding<bool>       isEnabled,
                      ITwoWayBinding<Visibility> visibility)
   {
      _isEnabled  = isEnabled;
      _visibility = visibility;
   }

   /* ------------------------------------------------------------ */
}
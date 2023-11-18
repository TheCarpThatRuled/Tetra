using System.Windows;

namespace Tetra.Testing;

public sealed class FakeTextBox
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly FakeOneWayBinding<bool>       _isEnabled;
   private readonly FakeTwoWayBinding<string>     _text;
   private readonly FakeOneWayBinding<Visibility> _visibility;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FakeTextBox
   (
      TextBoxContext context
   )
   {
      _isEnabled = FakeOneWayBinding<bool>.Create(context,
                                                  nameof(TextBoxContext.IsEnabled),
                                                  () => context.IsEnabled);
      _text = FakeTwoWayBinding<string>.Create(context,
                                               nameof(TextBoxContext.Text),
                                               () => context.Text,
                                               value => context.Text = value);
      _visibility = FakeOneWayBinding<Visibility>.Create(context,
                                                         nameof(TextBoxContext.Visibility),
                                                         () => context.Visibility);
   }
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FakeTextBox Create
   (
      TextBoxContext context
   )
      => new(context);

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public bool IsEnabled()
      => _isEnabled
        .Get();

   /* ------------------------------------------------------------ */

   public string Text()
      => _text
        .Get();

   /* ------------------------------------------------------------ */

   public Visibility Visibility()
      => _visibility
        .Get();

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public void EnterText
   (
      string text
   )
      => _text
        .Set(text);

   /* ------------------------------------------------------------ */
}
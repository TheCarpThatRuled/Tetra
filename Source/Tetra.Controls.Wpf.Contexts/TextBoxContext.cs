namespace Tetra;

public sealed class TextBoxContext : DataContext
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static TextBoxContext Create(TextBox model)
      => new(model);

   /* ------------------------------------------------------------ */
   // Bindings
   /* ------------------------------------------------------------ */

   public bool IsEnabled
      => _isEnabled
        .Pull();

   /* ------------------------------------------------------------ */

   public string Text
   {
      get => _text.Pull();
      set => _text.Push(value);
   }

   /* ------------------------------------------------------------ */

   public System.Windows.Visibility Visibility
      => _visibility
        .Pull();

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly OneWayBinding<bool>                      _isEnabled;
   private readonly TwoWayBinding<string>                    _text;
   private readonly OneWayBinding<System.Windows.Visibility> _visibility;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private TextBoxContext(TextBox model)
   {
      _isEnabled = Bind(nameof(IsEnabled),
                        model.IsEnabled());
      _text = Bind(nameof(Text),
                   model.Text());
      _visibility = Bind(nameof(Visibility),
                         model.Visibility()
                              .Map(x => x.ToWpf()));
   }

   /* ------------------------------------------------------------ */
}
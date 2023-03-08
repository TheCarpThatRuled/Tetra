namespace Tetra;

public sealed class ButtonSandboxContext : DataContext,
                                           ISandboxContext
{
   /* ------------------------------------------------------------ */
   // Bindings
   /* ------------------------------------------------------------ */

   public ButtonContext Button { get; }

   /* ------------------------------------------------------------ */

   public bool IsEnabled
   {
      get => _isEnabled.Pull();
      set => _isEnabled.Push(value);
   }

   /* ------------------------------------------------------------ */

   public string Message
      => _message
        .Pull();

   /* ------------------------------------------------------------ */

   public int SelectedVisibility
   {
      get => _selectedVisibilities.Pull();
      set => _selectedVisibilities.Push(value);
   }

   /* ------------------------------------------------------------ */

   public ISequence<string> Visibilities { get; }

   /* ------------------------------------------------------------ */
   // Internal Factory Functions
   /* ------------------------------------------------------------ */

   internal static ButtonSandboxContext Create(ButtonSandbox model)
      => new(model);

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly TwoWayBinding<bool>   _isEnabled;
   private readonly OneWayBinding<string> _message;
   private readonly TwoWayBinding<int>    _selectedVisibilities;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private ButtonSandboxContext(ButtonSandbox model)
   {
      Visibilities = model.Visibilities();

      Button = ButtonContext.Create(model.Button());

      _isEnabled = Bind(nameof(IsEnabled),
                        model.IsEnabled());

      _message = Bind(nameof(Message),
                      model.Message());

      _selectedVisibilities = Bind(nameof(SelectedVisibility),
                                   model.VisibilitiesSelectedIndex());

   }

   /* ------------------------------------------------------------ */
}
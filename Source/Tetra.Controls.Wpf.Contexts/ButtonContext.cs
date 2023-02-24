using System.Windows.Input;

namespace Tetra;

public sealed class ButtonContext : DataContext
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static ButtonContext Create(Button model)
      => new(model);

   /* ------------------------------------------------------------ */
   // Bindings
   /* ------------------------------------------------------------ */

   public ICommand Command { get; }

   /* ------------------------------------------------------------ */

   public System.Windows.Visibility Visibility
      => _visibility
        .Pull();

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly OneWayBinding<System.Windows.Visibility> _visibility;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   public ButtonContext(Button model)
   {
      Command = BindingCommand.Create(model.Click,
                                      model.IsEnabled());
      _visibility = Bind(nameof(Visibility),
                         model.Visibility()
                              .Map(x => x.ToWpf()));
   }

   /* ------------------------------------------------------------ */
}
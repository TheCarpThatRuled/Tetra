using System.Windows.Input;

namespace Tetra;

public sealed class BindingCommand : ICommand
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IOneWayBinding<bool> _canExecute;
   private readonly Action               _execute;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private BindingCommand
   (
      IOneWayBinding<bool> canExecute,
      Action               execute
   )
   {
      _canExecute = canExecute;
      _execute    = execute;

      _canExecute.OnUpdated(InvokeCanExecuteChanged);
   }

   /* ------------------------------------------------------------ */
   // ICommand Events
   /* ------------------------------------------------------------ */

   public event EventHandler? CanExecuteChanged;

   /* ------------------------------------------------------------ */
   // ICommand Methods
   /* ------------------------------------------------------------ */

   public bool CanExecute
   (
      object? _
   )
      => _canExecute
        .Pull();

   /* ------------------------------------------------------------ */

   public void Execute
   (
      object? _
   )
      => _execute();
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static BindingCommand Create
   (
      Action               execute,
      IOneWayBinding<bool> canExecute
   )
      => new(canExecute,
             execute);

   /* ------------------------------------------------------------ */
   // Event Handlers
   /* ------------------------------------------------------------ */

   private void InvokeCanExecuteChanged()
      => CanExecuteChanged
       ?.Invoke(this,
                EventArgs.Empty);

   /* ------------------------------------------------------------ */
}
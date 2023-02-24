using System.Windows.Input;

namespace Tetra;


public sealed class BindingCommand : ICommand
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static BindingCommand Create(Action               execute,
                                       IOneWayBinding<bool> canExecute)
      => new(canExecute,
             execute);

   /* ------------------------------------------------------------ */
   // ICommand EventHandlers
   /* ------------------------------------------------------------ */

   public event EventHandler? CanExecuteChanged;

   /* ------------------------------------------------------------ */
   // ICommand Methods
   /* ------------------------------------------------------------ */

   public bool CanExecute(object? _)
      => _canExecute
        .Pull();

   /* ------------------------------------------------------------ */

   public void Execute(object? _)
      => _execute();

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public void ChangeCanExecute()
      => CanExecuteChanged
       ?.Invoke(this,
                EventArgs.Empty);

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IOneWayBinding<bool> _canExecute;
   private readonly Action               _execute;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private BindingCommand(IOneWayBinding<bool> canExecute,
                          Action               execute)
   {
      _canExecute = canExecute;
      _execute    = execute;
   }

   /* ------------------------------------------------------------ */
}
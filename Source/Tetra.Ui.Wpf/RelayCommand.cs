using System.Windows.Input;

namespace Tetra;

public sealed class RelayCommand : ICommand
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Func<object?, bool> _canExecute;
   private readonly Action<object?>     _execute;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private RelayCommand
   (
      Func<object?, bool> canExecute,
      Action<object?>     execute
   )
   {
      _canExecute = canExecute;
      _execute    = execute;
   }

   /* ------------------------------------------------------------ */
   // ICommand EventHandlers
   /* ------------------------------------------------------------ */

   public event EventHandler? CanExecuteChanged;

   /* ------------------------------------------------------------ */
   // ICommand Methods
   /* ------------------------------------------------------------ */

   public bool CanExecute
   (
      object? parameter
   )
      => _canExecute(parameter);

   /* ------------------------------------------------------------ */

   public void Execute
   (
      object? parameter
   )
      => _execute(parameter);
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static RelayCommand Create
   (
      Action execute
   )
      => new(Function.True,
             _ => execute());

   /* ------------------------------------------------------------ */

   public static RelayCommand Create
   (
      Action<object?> execute
   )
      => new(Function.True,
             execute);

   /* ------------------------------------------------------------ */

   public static RelayCommand Create
   (
      Action     execute,
      Func<bool> canExecute
   )
      => new(_ => canExecute(),
             _ => execute());

   /* ------------------------------------------------------------ */

   public static RelayCommand Create
   (
      Action<object?>     execute,
      Func<object?, bool> canExecute
   )
      => new(canExecute,
             execute);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public void ChangeCanExecute()
      => CanExecuteChanged
       ?.Invoke(this,
                EventArgs.Empty);

   /* ------------------------------------------------------------ */
}
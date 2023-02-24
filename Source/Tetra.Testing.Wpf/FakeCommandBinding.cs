using System.Windows.Input;

namespace Tetra.Testing;

public sealed class FakeCommandBinding
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FakeCommandBinding Create(DataContext    context,
                                           string         propertyName,
                                           Func<ICommand> get)
      => new(context,
             get,
             propertyName);

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public bool CanExecute()
      => _canExecute;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public void Execute()
      => _command!.Execute(null);

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Func<ICommand> _get;
   private readonly string         _propertyName;

   private bool      _canExecute;
   private ICommand? _command;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FakeCommandBinding(DataContext    context,
                              Func<ICommand> get,
                              string         propertyName)
   {
      _get          = get;
      _propertyName = propertyName;

      context.PropertyChanged += ContextOnPropertyChanged;

      SetCommand(get());
   }

   /* ------------------------------------------------------------ */
   // Private Methods
   /* ------------------------------------------------------------ */

   private void SetCommand(ICommand command)
   {
      if (_command is not null)
      {
         _command.CanExecuteChanged -= CommandOnCanExecuteChanged;
      }

      _command    = command;
      _canExecute = command.CanExecute(null);

      _command.CanExecuteChanged += CommandOnCanExecuteChanged;
   }

   /* ------------------------------------------------------------ */

   private void ContextOnPropertyChanged(object?                                        sender,
                                         System.ComponentModel.PropertyChangedEventArgs e)
   {
      if (e.PropertyName == _propertyName)
      {
         SetCommand(_get());
      }
   }

   /* ------------------------------------------------------------ */

   private void CommandOnCanExecuteChanged(object?   sender,
                                           EventArgs e)
      => _canExecute = _command!.CanExecute(null);

   /* ------------------------------------------------------------ */
}
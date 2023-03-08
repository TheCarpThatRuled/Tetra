namespace Tetra;

public sealed class SelectSandboxScreenContext : DataContext
{
   /* ------------------------------------------------------------ */
   // Bindings
   /* ------------------------------------------------------------ */

   public ISandboxContext? CurrentSandbox
      => _currentSandbox
        .Pull();

   /* ------------------------------------------------------------ */

   public ISequence<string> Sandboxes
      => _sandboxes
        .Pull();

   /* ------------------------------------------------------------ */

   public int SelectedSandbox
   {
      get => _selectedSandbox.Pull();
      set => _selectedSandbox.Push(value);
   }

   /* ------------------------------------------------------------ */
   // Internal Factory Functions
   /* ------------------------------------------------------------ */

   internal static SelectSandboxScreenContext Create()
      => new();

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Binding<ISandboxContext?>        _currentSandbox;
   private readonly OneWayBinding<ISequence<string>> _sandboxes;
   private readonly TwoWayBinding<int>               _selectedSandbox;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private SelectSandboxScreenContext()
   {
      _currentSandbox = Bind(nameof(CurrentSandbox),
                             default(ISandboxContext));

      var model = SelectSandboxScreen.Create(Tetra
                                            .CurrentSandbox
                                            .Create(_currentSandbox.Push));

      _sandboxes = Bind(nameof(Sandboxes),
                        model.Sandboxes());

      _selectedSandbox = Bind(nameof(SelectedSandbox),
                              model.SelectedSandbox());
   }

   /* ------------------------------------------------------------ */
}
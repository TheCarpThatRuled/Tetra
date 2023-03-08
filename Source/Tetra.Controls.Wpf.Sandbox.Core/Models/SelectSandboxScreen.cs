namespace Tetra;

internal sealed class SelectSandboxScreen
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static SelectSandboxScreen Create(CurrentSandbox currentSandbox)
      => new(currentSandbox);

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public IOneWayBinding<ISequence<string>> Sandboxes()
      => _sandboxes;

   /* ------------------------------------------------------------ */

   public ITwoWayBinding<int> SelectedSandbox()
      => _selectedSandbox;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly CurrentSandbox                    _currentSandbox;
   private readonly IOneWayBinding<ISequence<string>> _sandboxes;
   private readonly ITwoWayBinding<int>               _selectedSandbox;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private SelectSandboxScreen(CurrentSandbox currentSandbox)
   {
      _currentSandbox = currentSandbox;

      _sandboxes = Bind.Invariant(Sequence.From("Button"));
      _selectedSandbox = Bind
                        .To(-1)
                        .OnOuterPush(ChangeSandbox);
   }

   /* ------------------------------------------------------------ */
   // Private Methods
   /* ------------------------------------------------------------ */

   private void ChangeSandbox(int index)
   {
      var sandboxes = _sandboxes.Pull();

      if (index            < 0
       || index            >= sandboxes.Length()
       || sandboxes[index] != "Button")
      {
         _currentSandbox.ChangeToNoSandbox();

         return;
      }

      _currentSandbox.ChangeToTheButtonSandbox();
   }

   /* ------------------------------------------------------------ */
}
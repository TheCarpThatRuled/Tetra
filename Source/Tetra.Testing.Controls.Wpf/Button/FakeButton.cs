using System.Windows;

namespace Tetra.Testing;

public sealed class FakeButton
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FakeButton Create(ButtonContext context)
      => new(context);

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public bool IsEnabled()
      => _command
        .CanExecute();

   /* ------------------------------------------------------------ */

   public Visibility Visibility()
      => _visibility
        .Get();

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public void Click(uint numberOfClicks = 1)
   {
      for (var i = 0; i < numberOfClicks; ++i)
      {
         _command.Execute();
      }
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly FakeCommandBinding            _command;
   private readonly FakeOneWayBinding<Visibility> _visibility;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FakeButton(ButtonContext context)
   {
      _command = FakeCommandBinding.Create(context,
                                           nameof(ButtonContext.Command),
                                           () => context.Command);
      _visibility = FakeOneWayBinding<Visibility>.Create(context,
                                                         nameof(ButtonContext.Visibility),
                                                         () => context.Visibility);
   }

   /* ------------------------------------------------------------ */
}
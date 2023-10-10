using System.Windows;
using Tetra.Views;

namespace Tetra;

public partial class App
{
   /* ------------------------------------------------------------ */
   // Overridden Application Methods
   /* ------------------------------------------------------------ */

   protected override void OnStartup
   (
      StartupEventArgs e
   )
   {
      new ApplicationWindow {DataContext = ApplicationWindowContext.Start(),}.Show();

      base.OnStartup(e);
   }

   /* ------------------------------------------------------------ */
}
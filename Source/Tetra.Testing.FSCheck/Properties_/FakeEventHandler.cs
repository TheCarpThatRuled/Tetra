using FsCheck;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property WasFireOnce(string           description,
                                      FakeEventHandler fakeEventHandler)
      => AsProperty(() => fakeEventHandler.NumberOfTimesFired() == 1)
        .Label(Failed.Message($"{description}: The event was not fire the expected number of times",
                              1,
                              fakeEventHandler.NumberOfTimesFired()));

   /* ------------------------------------------------------------ */
}
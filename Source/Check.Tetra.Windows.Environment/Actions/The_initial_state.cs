// ReSharper disable InconsistentNaming

using Tetra.Testing;

namespace Check;

public static class The_initial_state
{
   /* ------------------------------------------------------------ */
   // Given Functions
   /* ------------------------------------------------------------ */

   public static AAA_test.IArrange<Arranges> Is_unmodified()
      => AAA_test
        .AtomicArrange<Arranges>
        .Create($"{nameof(The_initial_state)}",
                Arranges.Create);

   /* ------------------------------------------------------------ */

   public static AAA_test.IArrange<Arranges> Is_a_clean_sandbox(string pathToTheSandbox)
      => Is_unmodified()
        .And(The_file_system.Creates_a_sandbox(pathToTheSandbox))
        .Recharacterise($"{nameof(The_initial_state)}{nameof(Is_a_clean_sandbox)}");

   /* ------------------------------------------------------------ */
}
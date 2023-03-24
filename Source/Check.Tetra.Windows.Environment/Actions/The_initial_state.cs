// ReSharper disable InconsistentNaming

using Tetra.Testing;

namespace Check;

public static class The_initial_state
{
   /* ------------------------------------------------------------ */
   // Given Functions
   /* ------------------------------------------------------------ */

   public static IArrange<Arranges> Is_unmodified()
      => AtomicArrange<Arranges>
        .Create(Arranges.Create,
                $"{nameof(The_initial_state)}");

   /* ------------------------------------------------------------ */

   public static IArrange<Arranges> Is_a_clean_sandbox(string pathToTheSandbox)
      => Is_unmodified()
        .And(The_file_system.Creates_a_sandbox(pathToTheSandbox))
        .Recharacterise($"{nameof(The_initial_state)}{nameof(Is_a_clean_sandbox)}");

   /* ------------------------------------------------------------ */
}
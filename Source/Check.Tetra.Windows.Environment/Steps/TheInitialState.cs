// ReSharper disable InconsistentNaming

using Tetra.Testing;
using static Tetra.Testing.AAA_test<Check.Actions, Check.Asserts>;

namespace Check;

partial class Steps
{
   public sealed class TheInitialState
   {
      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal TheInitialState() { }

      /* ------------------------------------------------------------ */
      // Givens
      /* ------------------------------------------------------------ */

      public IInitialAction Is_unmodified()
         => AtomicInitialAction
           .Create($"{nameof(the_initial_state)}.{nameof(Is_unmodified)}",
                   Actions.Create);

      /* ------------------------------------------------------------ */

      public IInitialAction Is_a_clean_sandbox
      (
         string pathToTheSandbox
      )
         => Is_unmodified()
           .And(the_file_system.Creates_a_sandbox(pathToTheSandbox))
           .Recharacterise($"{nameof(the_initial_state)}.{nameof(Is_a_clean_sandbox)}");

      /* ------------------------------------------------------------ */
   }
}
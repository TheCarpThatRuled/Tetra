// ReSharper disable InconsistentNaming

using Tetra.Testing;

namespace Check;

public static class A_directory
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static AAA_test.IArrange<Arranges, Arranges> Does_not_exists(string path)
      => AAA_test
        .AtomicArrange<Arranges, Arranges>
        .Create(environment => environment.A_directory_does_not_exist(path),
                $"{nameof(A_directory)}.{nameof(Does_not_exists)}: <{path}>");

   /* ------------------------------------------------------------ */

   public static AAA_test.IArrange<Arranges, Arranges> Exists(string path)
      => AAA_test
        .AtomicArrange<Arranges, Arranges>
        .Create(environment => environment.A_directory_exists(path),
                $"{nameof(A_directory)}.{nameof(Exists)}: <{path}>");

   /* ------------------------------------------------------------ */
}
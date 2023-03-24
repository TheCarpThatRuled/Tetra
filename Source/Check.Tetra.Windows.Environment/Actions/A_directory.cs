// ReSharper disable InconsistentNaming

using Tetra.Testing;

namespace Check;

public static class A_directory
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static IArrange<Arranges, Arranges> Does_not_exists(string path)
      => AtomicArrange<Arranges, Arranges>
        .Create(environment => environment.A_directory_does_not_exist(path),
                $"{nameof(A_directory)}.{nameof(Does_not_exists)}: <{path}>");

   /* ------------------------------------------------------------ */

   public static IArrange<Arranges, Arranges> Exists(string path)
      => AtomicArrange<Arranges, Arranges>
        .Create(environment => environment.A_directory_exists(path),
                $"{nameof(A_directory)}.{nameof(Exists)}: <{path}>");

   /* ------------------------------------------------------------ */
}
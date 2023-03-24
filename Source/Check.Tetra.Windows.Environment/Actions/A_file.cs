// ReSharper disable InconsistentNaming

using Tetra.Testing;

namespace Check;

public static class A_file
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static IArrange<Arranges, Arranges> Does_not_exists(string path)
      => AtomicArrange<Arranges, Arranges>
        .Create(environment => environment.A_file_does_not_exist(path),
                $"{nameof(A_file)}.{nameof(Does_not_exists)}: <{path}>");

   /* ------------------------------------------------------------ */

   public static IArrange<Arranges, Arranges> Exists(string path)
      => AtomicArrange<Arranges, Arranges>
        .Create(environment => environment.A_file_exists(path),
                $"{nameof(A_file)}.{nameof(Exists)}: <{path}>");

   /* ------------------------------------------------------------ */
}
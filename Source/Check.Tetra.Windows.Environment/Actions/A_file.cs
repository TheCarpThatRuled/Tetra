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

   public static IArrange<Arranges, Arranges> Is_locked(string path)
      => AtomicArrange<Arranges, Arranges>
        .Create(environment => environment.A_file_is_locked(path),
                $"{nameof(A_file)}.{nameof(Is_locked)}: <{path}>");

   /* ------------------------------------------------------------ */

   public static IArrange<Arranges, Arranges> Exists_and_is_locked(string path)
      => Exists(path)
        .And(Is_locked(path))
        .Recharacterise($"{nameof(A_file)}.{nameof(Exists_and_is_locked)}: <{path}>");

   /* ------------------------------------------------------------ */

   public static IArrange<Arranges, Arranges> Is_unlocked(string path)
      => AtomicArrange<Arranges, Arranges>
        .Create(environment => environment.A_file_is_unlocked(path),
                $"{nameof(A_file)}.{nameof(Is_unlocked)}: <{path}>");

   /* ------------------------------------------------------------ */
}
// ReSharper disable InconsistentNaming
using static Tetra.Testing.AAA_test<Check.Actions, Check.Asserts>;

using Tetra.Testing;

namespace Check;

partial class Steps
{
   public sealed class AFile
   {
      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal AFile() { }

      /* ------------------------------------------------------------ */
      // Actions
      /* ------------------------------------------------------------ */

      public IAction Does_not_exists
      (
         string path
      )
         => AtomicAction
           .Create($"{nameof(a_file)}.{nameof(Does_not_exists)}: <{path}>",
                   environment => environment
                                 .SystemIoApi
                                 .EnsureAFileDoesNotExists(path)
                                 .Next());

      /* ------------------------------------------------------------ */

      public IAction Exists
      (
         string path
      )
         => AtomicAction
           .Create($"{nameof(a_file)}.{nameof(Exists)}: <{path}>",
                   environment => environment
                                 .SystemIoApi
                                 .EnsureAFileExists(path)
                                 .Next());

      /* ------------------------------------------------------------ */

      public IAction Is_locked
      (
         string path
      )
         => AtomicAction
           .Create($"{nameof(a_file)}.{nameof(Is_locked)}: <{path}>",
                   environment => environment
                                 .SystemIoApi
                                 .LockFile(path)
                                 .Next());

      /* ------------------------------------------------------------ */

      public IAction Exists_and_is_locked
      (
         string path
      )
         => Exists(path)
           .And(Is_locked(path))
           .Recharacterise($"{nameof(a_file)}.{nameof(Exists_and_is_locked)}: <{path}>");

      /* ------------------------------------------------------------ */

      public IAction Is_unlocked
      (
         string path
      )
         => AtomicAction
           .Create($"{nameof(a_file)}.{nameof(Is_unlocked)}: <{path}>",
                   environment => environment
                                 .SystemIoApi
                                 .UnlockFile(path)
                                 .Next());

      /* ------------------------------------------------------------ */
   }
}
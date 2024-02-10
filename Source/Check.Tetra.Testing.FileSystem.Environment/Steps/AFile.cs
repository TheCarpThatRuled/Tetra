// ReSharper disable InconsistentNaming
using static Tetra.Testing.AAA_property_test<Check.Actions, Check.Asserts>;

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
      /* ------------------------------------------------------------ * /

      public IAction Does_not_exists
      (
         string path
      )
         => AtomicAction
           .Create($"{nameof(a_file)}.{nameof(Does_not_exists)}: <{path}>",
                   (_, environment) => environment
                                      .ExternalFileSystem
                                      .EnsureAFileDoesNotExists(path)
                                      .ReturnToParent());

      /* ------------------------------------------------------------ * /

      public IAction Exists
      (
         string path
      )
         => AtomicAction
           .Create($"{nameof(a_file)}.{nameof(Exists)}: <{path}>",
                   (_, environment) => environment
                                      .ExternalFileSystem
                                      .EnsureAFileExists(path)
                                      .ReturnToParent());

      /* ------------------------------------------------------------ * /

      public IAction Is_locked
      (
         string path
      )
         => AtomicAction
           .Create($"{nameof(a_file)}.{nameof(Is_locked)}: <{path}>",
                   (_, environment) => environment
                                      .ExternalFileSystem
                                      .LockFile(path)
                                      .ReturnToParent());

      /* ------------------------------------------------------------ * /

      public IAction Exists_and_is_locked
      (
         string path
      )
         => Exists(path)
           .And(Is_locked(path))
           .Recharacterise($"{nameof(a_file)}.{nameof(Exists_and_is_locked)}: <{path}>");

      /* ------------------------------------------------------------ * /

      public IAction Is_unlocked
      (
         string path
      )
         => AtomicAction
           .Create($"{nameof(a_file)}.{nameof(Is_unlocked)}: <{path}>",
                   (_, environment) => environment
                                      .ExternalFileSystem
                                      .UnlockFile(path)
                                      .ReturnToParent());

      /* ------------------------------------------------------------ */
   }
}
using Tetra;
using Tetra.Testing;

// ReSharper disable InconsistentNaming

namespace Check;

public sealed class Actions : TestEnvironment<Actions, Asserts>
{
   /* ------------------------------------------------------------ */
   // Fields
   /* ------------------------------------------------------------ */

   public readonly SystemIoActions               SystemIoApi;
   public readonly FileSystemApiActions<Actions> TetraApi;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IFileSystem _fileSystem = FileSystem.Create();

   //Mutable
   private object? _lastReturnedValue;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private Actions
   (
      AAA_test.Disposables disposables,
      LockedFiles          lockedFiles
   )
   {
      SystemIoApi = SystemIoActions.Create("System.IO API",
                                           disposables,
                                           lockedFiles,
                                           () => this);
      TetraApi = FileSystemApiActions<Actions>.Create("Tetra.IFileSystem API",
                                                      returnValue => _lastReturnedValue = returnValue,
                                                      _fileSystem,
                                                      () => this);
   }

   /* ------------------------------------------------------------ */
   // Internal Factory Functions
   /* ------------------------------------------------------------ */

   internal static Actions Create
   (
      AAA_test.Disposables disposables
   )
   {
      var lockedFiles = LockedFiles.Create();
      disposables.Register(lockedFiles);
      disposables.Register(SetTheCurrentDirectory.Create(ExternalFileSystem.GetTheCurrentDirectory()));

      return new(disposables,
                 lockedFiles);
   }

   /* ------------------------------------------------------------ */
   //  TestEnvironment<Actions,Asserts> Methods
   /* ------------------------------------------------------------ */

   protected override Asserts CreateAsserts()
      => Check
        .Asserts
        .Create(_lastReturnedValue);

   /* ------------------------------------------------------------ */

   protected override Actions PerformFinalise()
      => this;

   /* ------------------------------------------------------------ */
}
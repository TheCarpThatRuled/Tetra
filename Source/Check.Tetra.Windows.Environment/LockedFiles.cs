using Tetra.Testing;

namespace Check;

internal sealed class LockedFiles : IDisposable
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Dictionary<CaseInsensitiveString, Stream> _lockedFiles = new();

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private LockedFiles() { }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static LockedFiles Create()
      => new();

   /* ------------------------------------------------------------ */
   // IDisposable Methods
   /* ------------------------------------------------------------ */

   public void Dispose()
   {
      foreach (var file in _lockedFiles.Values)
      {
         file.Dispose();
      }
   }

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public void LockFile
   (
      string file
   )
   {
      var caseInsensitiveFile = CaseInsensitiveString.Create(file);

      if (_lockedFiles.ContainsKey(caseInsensitiveFile))
      {
         throw Failed
              .InTheActions($"The file {file} is already locked")
              .ToAssertFailedException();
      }

      _lockedFiles.Add(caseInsensitiveFile,
                       ExternalFileSystem.OpenAFile(file));
   }

   /* ------------------------------------------------------------ */

   public void UnlockFile
   (
      string file
   )
   {
      var caseInsensitiveFile = CaseInsensitiveString.Create(file);

      if (!_lockedFiles.Remove(caseInsensitiveFile,
                               out var lockedFile))
      {
         throw Failed
              .InTheActions($"The file {file} is not locked")
              .ToAssertFailedException();
      }

      lockedFile.Dispose();
   }

   /* ------------------------------------------------------------ */
   // Private Classes
   /* ------------------------------------------------------------ */

   private class CaseInsensitiveString
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly string _value;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private CaseInsensitiveString
      (
         string value
      )
         => _value = value;

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static CaseInsensitiveString Create
      (
         string value
      )
         => new(value);

      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Equals
      (
         object? obj
      )
         => obj is string s
         && _value.Equals(s,
                          StringComparison.OrdinalIgnoreCase);

      /* ------------------------------------------------------------ */

      public override int GetHashCode()
         => _value
           .GetHashCode(StringComparison.OrdinalIgnoreCase);

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}
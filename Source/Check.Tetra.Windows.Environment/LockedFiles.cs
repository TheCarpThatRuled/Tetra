﻿using Tetra.Testing;

namespace Check;

internal class LockedFiles : IDisposable
{
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

   public void LockFile(string file)
   {
      var caseInsensitiveFile = CaseInsensitiveString.Create(file);

      if (_lockedFiles.ContainsKey(caseInsensitiveFile))
      {
         throw Failed.InTestSetup($"The file {file} is already locked");
      }

      _lockedFiles.Add(caseInsensitiveFile,
                       ExternalFileSystem.OpenAFile(file));
   }

   /* ------------------------------------------------------------ */

   public void UnlockFile(string file)
   {
      var caseInsensitiveFile = CaseInsensitiveString.Create(file);

      if (!_lockedFiles.ContainsKey(caseInsensitiveFile))
      {
         throw Failed.InTestSetup($"The file {file} is not locked");
      }

      _lockedFiles[caseInsensitiveFile].Dispose();
      _lockedFiles.Remove(caseInsensitiveFile);
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Dictionary<CaseInsensitiveString, Stream> _lockedFiles = new();

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private LockedFiles() { }

   /* ------------------------------------------------------------ */
   // Private Classes
   /* ------------------------------------------------------------ */

   private class CaseInsensitiveString
   {
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static CaseInsensitiveString Create(string value)
         => new(value);

      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(object? obj)
         => obj is string s
         && _value.Equals(s,
                          StringComparison.OrdinalIgnoreCase);

      /* ------------------------------------------------------------ */

      public override int GetHashCode()
         => _value
           .GetHashCode(StringComparison.OrdinalIgnoreCase);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly string _value;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private CaseInsensitiveString(string value)
         => _value = value;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}
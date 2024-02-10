using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // object.Equals Extensions
   /* ------------------------------------------------------------ */

   public static Assert EqualsIsReflexive<T>
   (
      this Assert assert,
      T           original,
      T           copy
   )
      where T : notnull
   {
      if (!original.Equals(original))
      {
         throw Failed
              .InTheAsserts("object.Equals is not reflexive: Comparing against the same instance is not equal")
              .ToAssertFailedException();
      }

      if (!original.Equals(copy))
      {
         throw Failed
              .InTheAsserts("object.Equals is not reflexive: Comparing against an identical instance is not equal")
              .ToAssertFailedException();
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
   // IEquatable<T> Extensions
   /* ------------------------------------------------------------ */

   // ReSharper disable once InconsistentNaming
   public static Assert IEquatableIsReflexive<T>
   (
      this Assert assert,
      T           original,
      T           copy
   )
      where T : IEquatable<T>
   {
      if (!original.Equals(original))
      {
         throw Failed
              .InTheAsserts("object.Equals is not reflexive: Comparing against the same instance is not equal")
              .ToAssertFailedException();
      }

      if (!original.Equals(copy))
      {
         throw Failed
              .InTheAsserts("object.Equals is not reflexive: Comparing against an identical instance is not equal")
              .ToAssertFailedException();
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
}
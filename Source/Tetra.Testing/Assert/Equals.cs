using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // object.Equals Extensions
   /* ------------------------------------------------------------ */

   public static Assert EqualsIsReflexive<T>(this Assert assert,
                                             T original,
                                             T copy)
      where T : notnull
   {
      if (!((object)original).Equals(original))
      {
         throw Failed.Assert("object.Equals is not reflexive: Comparing against the same instance is not equal");
      }

      if (!((object)original).Equals(copy))
      {
         throw Failed.Assert("object.Equals is not reflexive: Comparing against an identical instance is not equal");
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
   // IEquatable<T> Extensions
   /* ------------------------------------------------------------ */

   // ReSharper disable once InconsistentNaming
   public static Assert IEquatableIsReflexive<T>(this Assert assert,
                                                 T original,
                                                 T copy)
      where T : notnull, IEquatable<T>
   {
      if (!original.Equals(original))
      {
         throw Failed.Assert("object.Equals is not reflexive: Comparing against the same instance is not equal");
      }

      if (!original.Equals(copy))
      {
         throw Failed.Assert("object.Equals is not reflexive: Comparing against an identical instance is not equal");
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
}
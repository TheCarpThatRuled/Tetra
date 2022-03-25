using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static Assert IsANone<T>(this Assert assert,
                                   Option<T> option)
   {
      if (option.Reduce(() => false,
                        _ => true))
      {
         throw Failed.Assert(TheOptionIsNone<T>());
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsANone<T>(this Assert assert,
                                   Option<T> option,
                                   string name)
   {
      if (option.Reduce(() => false,
                        _ => true))
      {
         throw Failed.Assert(TheOptionIsNone<T>(name));
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
}
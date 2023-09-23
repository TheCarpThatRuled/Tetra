﻿using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheWhenNone 
   {
      public sealed class ForDo
      {
         /* ------------------------------------------------------------ */
         // Assert
         /* ------------------------------------------------------------ */

         public IAssert<DoWasCalled.Asserts, DoWasCalled.Asserts> was_invoked_once()
            => the_whenNone.action.was_invoked_once<DoWasCalled.Asserts>();

         /* ------------------------------------------------------------ */

         public IAssert<DoWasCalled.Asserts, DoWasCalled.Asserts> was_not_invoked()
            => the_whenNone.action.was_not_invoked<DoWasCalled.Asserts>();

         /* ------------------------------------------------------------ */
      }
   }
}
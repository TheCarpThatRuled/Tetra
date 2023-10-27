using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public abstract class TestEnvironment<T> : ITestEnvironment<T>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private bool _finalised = false;

   /* ------------------------------------------------------------ */
   // ITestEnvironment<Asserts> Methods
   /* ------------------------------------------------------------ */

   public T Asserts()
   {
      if (!_finalised)
      {
         throw Failed.InTest("The Test Environment was not finalised before the asserts were accessed");
      }

      return CreateAsserts();
   }

   /* ------------------------------------------------------------ */

   public void FinishArrange()
   {
      Finalise();
      _finalised = true;
   }

   /* ------------------------------------------------------------ */
   // Protected Methods
   /* ------------------------------------------------------------ */

   protected abstract T CreateAsserts();

   /* ------------------------------------------------------------ */

   protected abstract void Finalise();

   /* ------------------------------------------------------------ */
}
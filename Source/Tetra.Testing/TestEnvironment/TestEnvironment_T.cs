namespace Tetra.Testing;

public abstract class TestEnvironment<TActions, TAsserts>
   where TActions : TestEnvironment<TActions, TAsserts>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private bool _finalised = false;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TAsserts Asserts()
   {
      if (!_finalised)
      {
         throw Failed.InTestSetup("The Test Environment was not finalised before the asserts were accessed");
      }

      return CreateAsserts();
   }

   /* ------------------------------------------------------------ */

   public TActions Finalise()
   {
      if (_finalised)
      {
         throw Failed.InTestSetup("The Test Environment cannot be finalised; it has already been finalised");
      }

      _finalised = true;
      return PerformFinalise();
   }

   /* ------------------------------------------------------------ */
   // Protected Methods
   /* ------------------------------------------------------------ */

   protected abstract TAsserts CreateAsserts();

   /* ------------------------------------------------------------ */

   protected abstract TActions PerformFinalise();

   /* ------------------------------------------------------------ */
}
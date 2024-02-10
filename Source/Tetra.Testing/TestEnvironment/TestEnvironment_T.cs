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
         throw Failed
              .CannotProgressToTheAsserts("the test environment was not finalised")
              .ToAssertFailedException();
      }

      return CreateAsserts();
   }

   /* ------------------------------------------------------------ */

   public TActions Finalise()
   {
      if (_finalised)
      {
         throw Failed
              .CannotPerformAnAction("finalise the test environment",
                                     "it has already been finalised")
              .ToAssertFailedException();
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
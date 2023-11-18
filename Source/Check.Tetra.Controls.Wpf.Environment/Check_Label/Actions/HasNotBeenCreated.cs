using Tetra;
using Tetra.Testing;

namespace Check.Check_Label;

partial class Actions
{
   private sealed class HasNotBeenCreated : Actions
   {
      /* ------------------------------------------------------------ */
      // ITestEnvironment<Asserts> Methods
      /* ------------------------------------------------------------ */

      public override Asserts Asserts()
         => throw Failed.Assert("Cannot progress to the asserts; no actions have been performed.");

      /* ------------------------------------------------------------ */

      public override void FinishArrange() { }

      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      public override TwoWayBindingActions<object, Actions> Content
         => throw Failed.Assert("Cannot perform an action on Content; the label has not been created.");

      /* ------------------------------------------------------------ */

      public override TwoWayBindingActions<Visibility, Actions> Visibility
         => throw Failed.Assert("Cannot perform an action on Visibility; the label has not been created.");

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public override Actions CreateLabel
      (
         The_UI_creates_a_label args
      )
      {
         var system = FakeSystem.Create(args);
         var label = FakeLabel.Create(LabelContext.Create(Label
                                                         .Factory()
                                                         .Content(system.Content())
                                                         .Visibility(system.Visibility())));

         return new HasBeenCreated(label,
                                   system);
      }

      /* ------------------------------------------------------------ */
   }
}
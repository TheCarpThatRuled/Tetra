using Check.Check_Button;
using TechTalk.SpecFlow;

namespace Check.Button;

[Binding]
internal sealed class TestEnvironment
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Actions _actions = Actions.Start();

   /* ------------------------------------------------------------ */
   // Given
   /* ------------------------------------------------------------ */

   [Given("the UI has not created the button")]
   public void TheUIHasNotCreatedTheButton()
   {
      //NoOp
   }

   /* ------------------------------------------------------------ */

   [Given("the UI has created an enabled, visible button")]
   public void TheUIHasCreatedAnEnabledVisibleButton()
      => _actions
        .CreateButton(The_UI_creates_a_button
                     .Factory()
                     .IsEnabled_is_enabled()
                     .Visibility_is_visible());

   /* ------------------------------------------------------------ */

   [Given("the UI has created a button that is {string} and {string}")]
   public void TheUIHasCreatedAButtonThatIs
   (
      string isEnabled,
      string visibility
   )
      => _actions
        .CreateButton(The_UI_creates_a_button
                     .Factory()
                     .IsEnabled_is(IsEnabled.From(isEnabled))
                     .Visibility_is(Visibility.Tetra(visibility)));

   /* ------------------------------------------------------------ */
   // When
   /* ------------------------------------------------------------ */

   [When("the system updates IsEnabled to {string}")]
   public void TheSystemUpdatesIsEnabledTo
   (
      string isEnabled
   )
      => _actions
        .Finalise()
        .IsEnabled
        .Push(IsEnabled.From(isEnabled))
        .Next();

   /* ------------------------------------------------------------ */

   [When("the system updates Visibility to {string}")]
   public void TheSystemUpdatesVisibilityTo
   (
      string visibility
   )
      => _actions
        .Finalise()
        .Visibility
        .Push(Visibility.Tetra(visibility))
        .Next();

   /* ------------------------------------------------------------ */

   [When("the UI creates a button that is {string} and {string}")]
   public void TheUICreatesAButtonThatIs
   (
      string isEnabled,
      string visibility
   )
      => _actions
        .Finalise()
        .CreateButton(The_UI_creates_a_button
                     .Factory()
                     .IsEnabled_is(IsEnabled.From(isEnabled))
                     .Visibility_is(Visibility.Tetra(visibility)));

   /* ------------------------------------------------------------ */

   [When("the user clicks the button")]
   public void TheUserClicksTheButton()
      => _actions
        .Finalise()
        .Button
        .Click()
        .Next();

   /* ------------------------------------------------------------ */
   // Then
   /* ------------------------------------------------------------ */

   [Then("the button is {string} and {string}")]
   public void TheButtonIs
   (
      string expectedIsEnabled,
      string expectedVisibility
   )
      => _actions
        .Asserts()
        .Button
        .Matches(Expected_button
                .Factory()
                .IsEnabled_is(IsEnabled.From(expectedIsEnabled))
                .Visibility_is(Visibility.Windows(expectedVisibility)));

   /* ------------------------------------------------------------ */

   [Then("the click callback was invoked once")]
   public void TheClickCallbackWasInvokedOnce()
      => _actions
        .Asserts()
        .OnClick
        .WasInvokedOnce();

   /* ------------------------------------------------------------ */

   [Then("the system contains {string} and {string}")]
   public void TheSystemContains
   (
      string expectedIsEnabled,
      string expectedVisibility
   )
      => _actions
        .Asserts()
        .IsEnabled.Contains(IsEnabled.From(expectedIsEnabled))
        .Next()
        .Visibility.Contains(Visibility.Tetra(expectedVisibility));

   /* ------------------------------------------------------------ */
}
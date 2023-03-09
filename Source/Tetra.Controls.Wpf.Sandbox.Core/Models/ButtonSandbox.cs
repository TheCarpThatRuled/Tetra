namespace Tetra;

internal sealed class ButtonSandbox
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static ButtonSandbox Create()
      => new();

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public Button Button()
      => _button;

   /* ------------------------------------------------------------ */

   public ITwoWayBinding<bool> IsEnabled()
      => _isEnabled;

   /* ------------------------------------------------------------ */

   public IOneWayBinding<string> Message()
      => _message;

   /* ------------------------------------------------------------ */

   public ISequence<string> Visibilities()
      => _visibilities;

   /* ------------------------------------------------------------ */

   public ITwoWayBinding<int> VisibilitiesSelectedIndex()
      => _visibilitiesSelectedIndex;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly ISequence<string> _visibilities = Sequence.From(Visibility.Visible.ToHumanReadable(),
                                                                    Visibility.Collapsed.ToHumanReadable(),
                                                                    Visibility.Hidden.ToHumanReadable());

   private readonly Count<int> _count = Count<int>.FromZero();

   private readonly Button                     _button;
   private readonly ITwoWayBinding<Visibility> _buttonVisibility;
   private readonly ITwoWayBinding<bool>       _isEnabled;
   private readonly ITwoWayBinding<string>     _message;
   private readonly ITwoWayBinding<int>        _visibilitiesSelectedIndex;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private ButtonSandbox()
   {
      var buttonIsEnabled = Bind.To(true);
      _buttonVisibility = Bind.To(Visibility.Visible);

      _button = Tetra
               .Button
               .Factory()
               .OnClick(OnClick)
               .IsEnabled(buttonIsEnabled)
               .Visibility(_buttonVisibility);

      _isEnabled = Bind
                  .To(buttonIsEnabled.Pull())
                  .OnOuterPush(buttonIsEnabled.Push);

      _visibilitiesSelectedIndex = Bind
                                  .To(_visibilities
                                     .WithIndices()
                                     .First(x => x
                                                .item
                                                .Equals(_buttonVisibility
                                                       .Pull()
                                                       .ToHumanReadable()))
                                     .index)
                                  .OnOuterPush(UpdateVisibility);

      _message = Bind.To(CreateMessage(_count));
   }

   /* ------------------------------------------------------------ */
   // Private Methods
   /* ------------------------------------------------------------ */

   private void OnClick()
   {
      _count.Increment();

      _message.Push(CreateMessage(_count));
   }

   /* ------------------------------------------------------------ */

   private void UpdateVisibility(int index)
   {
      _buttonVisibility.Push(_visibilities[index]
                               .HumanReadableToTetraVisibility());
   }

   /* ------------------------------------------------------------ */
   // Private Functions
   /* ------------------------------------------------------------ */

   private static string CreateMessage(Count<int> count)
      => $@"The button has been clicked {count.Value()} time(s)";

   /* ------------------------------------------------------------ */
}
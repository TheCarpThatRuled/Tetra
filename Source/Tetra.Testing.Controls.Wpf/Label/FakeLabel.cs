using System.Windows;

namespace Tetra.Testing;

public sealed class FakeLabel
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FakeLabel Create(LabelContext context)
      => new(context);

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public object Content()
      => _content
        .Get();

   /* ------------------------------------------------------------ */

   public Visibility Visibility()
      => _visibility
        .Get();

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly FakeOneWayBinding<object>     _content;
   private readonly FakeOneWayBinding<Visibility> _visibility;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FakeLabel(LabelContext context)
   {
      _content = FakeOneWayBinding<object>.Create(context,
                                                  nameof(LabelContext.Content),
                                                  () => context.Content);
      _visibility = FakeOneWayBinding<Visibility>.Create(context,
                                                         nameof(LabelContext.Visibility),
                                                         () => context.Visibility);
   }

   /* ------------------------------------------------------------ */
}
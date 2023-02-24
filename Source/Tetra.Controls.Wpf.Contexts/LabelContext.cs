namespace Tetra;

public sealed class LabelContext : DataContext
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static LabelContext Create(Label model)
      => new(model);

   /* ------------------------------------------------------------ */
   // Bindings
   /* ------------------------------------------------------------ */

   public object Content
      => _content
        .Pull();

   /* ------------------------------------------------------------ */

   public System.Windows.Visibility Visibility
      => _visibility
        .Pull();

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly OneWayBinding<object>                    _content;
   private readonly OneWayBinding<System.Windows.Visibility> _visibility;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private LabelContext(Label model)
   {
      _content = Bind(nameof(Content),
                      model.Content());
      _visibility = Bind(nameof(Visibility),
                         model.Visibility()
                              .Map(x => x.ToWpf()));
   }

   /* ------------------------------------------------------------ */
}
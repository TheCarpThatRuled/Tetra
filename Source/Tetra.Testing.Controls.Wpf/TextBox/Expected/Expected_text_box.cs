using System.Windows;

namespace Tetra.Testing;

public sealed partial class Expected_text_box
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static DefineText Factory()
      => new();

   /* ------------------------------------------------------------ */
   // ICharacterisable Properties
   /* ------------------------------------------------------------ */

   public string BriefCharacterisation()
      => _briefCharacterisation;

   /* ------------------------------------------------------------ */

   public string FullCharacterisation()
      => _fullCharacterisation;

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public bool IsEnabled()
      => _isEnabled;

   /* ------------------------------------------------------------ */

   public string Text()
      => _text;

   /* ------------------------------------------------------------ */

   public Visibility Visibility()
      => _visibility;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public ExceptCarrier<Expected_text_box> Except()
      => new(Function.PassThrough,
             this);

   /* ------------------------------------------------------------ */

   public ExceptCarrier<T> Except<T>(Func<Expected_text_box, T> createParent)
      => new(createParent,
             this);

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string     _briefCharacterisation;
   private readonly string     _fullCharacterisation;
   private readonly bool       _isEnabled;
   private readonly string     _text;
   private readonly Visibility _visibility;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private Expected_text_box(string     briefCharacterisation,
                           string     fullCharacterisation,
                           bool       isEnabled,
                           string     text,
                           Visibility visibility)
   {
      _briefCharacterisation = briefCharacterisation;
      _isEnabled             = isEnabled;
      _fullCharacterisation  = fullCharacterisation;
      _text                  = text;
      _visibility            = visibility;
   }

   /* ------------------------------------------------------------ */
}
// ReSharper disable InconsistentNaming

using Tetra;

namespace Check.Check_TextBox;

public sealed partial class The_UI_creates_a_text_box
{
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

   private The_UI_creates_a_text_box
   (
      string     briefCharacterisation,
      string     fullCharacterisation,
      bool       isEnabled,
      string     text,
      Visibility visibility
   )
   {
      _briefCharacterisation = briefCharacterisation;
      _text                  = text;
      _fullCharacterisation  = fullCharacterisation;
      _isEnabled             = isEnabled;
      _visibility            = visibility;
   }
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static DefineText Factory()
      => new();

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public string BriefCharacterisation()
      => _briefCharacterisation;

   /* ------------------------------------------------------------ */

   public bool IsEnabled()
      => _isEnabled;

   /* ------------------------------------------------------------ */

   public string FullCharacterisation()
      => _fullCharacterisation;

   /* ------------------------------------------------------------ */

   public string Text()
      => _text;

   /* ------------------------------------------------------------ */

   public Visibility Visibility()
      => _visibility;

   /* ------------------------------------------------------------ */
}
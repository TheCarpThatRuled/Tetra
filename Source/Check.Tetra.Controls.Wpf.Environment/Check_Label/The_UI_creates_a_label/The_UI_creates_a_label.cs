// ReSharper disable InconsistentNaming

using Tetra;

namespace Check.Check_Label;

public sealed partial class The_UI_creates_a_label
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static DefineVisibility Content_is(object content)
      => new(content);

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public string BriefCharacterisation()
      => _briefCharacterisation;

   /* ------------------------------------------------------------ */

   public object Content()
      => _content;

   /* ------------------------------------------------------------ */

   public string FullCharacterisation()
      => _fullCharacterisation;

   /* ------------------------------------------------------------ */

   public Visibility Visibility()
      => _visibility;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string     _briefCharacterisation;
   private readonly object     _content;
   private readonly string     _fullCharacterisation;
   private readonly Visibility _visibility;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private The_UI_creates_a_label(string     briefCharacterisation,
                                  object     content,
                                  string     fullCharacterisation,
                                  Visibility visibility)
   {
      _briefCharacterisation = briefCharacterisation;
      _content               = content;
      _fullCharacterisation  = fullCharacterisation;
      _visibility            = visibility;
   }

   /* ------------------------------------------------------------ */
}
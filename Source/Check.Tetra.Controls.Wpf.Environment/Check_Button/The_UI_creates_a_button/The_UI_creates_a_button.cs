// ReSharper disable InconsistentNaming

using Tetra;

namespace Check.Check_Button;

public sealed partial class The_UI_creates_a_button
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string     _briefCharacterisation;
   private readonly string     _fullCharacterisation;
   private readonly bool       _isEnabled;
   private readonly Visibility _visibility;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private The_UI_creates_a_button
   (
      string     briefCharacterisation,
      string     fullCharacterisation,
      bool       isEnabled,
      Visibility visibility
   )
   {
      _briefCharacterisation = briefCharacterisation;
      _fullCharacterisation  = fullCharacterisation;
      _isEnabled             = isEnabled;
      _visibility            = visibility;
   }
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static DefineIsEnabled Factory()
      => new();

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public string BriefCharacterisation()
      => _briefCharacterisation;

   /* ------------------------------------------------------------ */

   public string FullCharacterisation()
      => _fullCharacterisation;

   /* ------------------------------------------------------------ */

   public bool IsEnabled()
      => _isEnabled;

   /* ------------------------------------------------------------ */

   public Visibility Visibility()
      => _visibility;

   /* ------------------------------------------------------------ */
}
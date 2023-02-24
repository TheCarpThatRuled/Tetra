using System.Windows;

namespace Tetra.Testing;

public sealed class ExpectedTextBox
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static ExpectedTextBox Create(string     text,
                                        bool       isEnabled,
                                        Visibility visibility)
      => new(string.Empty,
             string.Empty,
             isEnabled,
             text,
             visibility);

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

   private ExpectedTextBox(string     briefCharacterisation,
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
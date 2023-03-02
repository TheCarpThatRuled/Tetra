using System.Windows;

namespace Tetra.Testing;

public sealed class Expected_label
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static Expected_label Create(object     content,
                                      Visibility visibility)
      => new(string.Empty,
             content,
             string.Empty,
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

   public object Content()
      => _content;

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

   private Expected_label(string     briefCharacterisation,
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
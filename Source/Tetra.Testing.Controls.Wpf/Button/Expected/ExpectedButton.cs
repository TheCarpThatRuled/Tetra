using System.Windows;

namespace Tetra.Testing;

public sealed class ExpectedButton : ICharacterisable
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static ExpectedButton Create(bool       isEnabled,
                                       Visibility visibility)
      => new(string.Empty,
             isEnabled,
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

   public bool IsEnabled()
      => _isEnabled;

   /* ------------------------------------------------------------ */

   public Visibility Visibility()
      => _visibility;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string     _briefCharacterisation;
   private readonly bool       _isEnabled;
   private readonly string     _fullCharacterisation;
   private readonly Visibility _visibility;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private ExpectedButton(string     briefCharacterisation,
                          bool       isEnabled,
                          string     fullCharacterisation,
                          Visibility visibility)
   {
      _briefCharacterisation = briefCharacterisation;
      _isEnabled             = isEnabled;
      _fullCharacterisation  = fullCharacterisation;
      _visibility            = visibility;
   }

   /* ------------------------------------------------------------ */
}
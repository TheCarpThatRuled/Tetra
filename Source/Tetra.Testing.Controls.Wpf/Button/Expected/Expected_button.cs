using System.Windows;

// ReSharper disable InconsistentNaming

namespace Tetra.Testing;

public sealed partial class Expected_button : ICharacterisable
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

   private Expected_button
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
   // ICharacterisable Properties
   /* ------------------------------------------------------------ */

   public string BriefCharacterisation()
      => _briefCharacterisation;

   /* ------------------------------------------------------------ */

   public string FullCharacterisation()
      => _fullCharacterisation;
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static DefineIsEnabled Factory()
      => new();

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public bool IsEnabled()
      => _isEnabled;

   /* ------------------------------------------------------------ */

   public Visibility Visibility()
      => _visibility;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public ExceptCarrier<Expected_button> Except()
      => new(Function.PassThrough,
             this);

   /* ------------------------------------------------------------ */

   public ExceptCarrier<T> Except<T>
   (
      Func<Expected_button, T> createParent
   )
      => new(createParent,
             this);

   /* ------------------------------------------------------------ */
}
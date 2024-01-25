// ReSharper disable InconsistentNaming

using Tetra;

namespace Check.Check_Button;

public sealed partial class The_UI_creates_a_button
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly bool       _isEnabled;
   private readonly Visibility _visibility;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private The_UI_creates_a_button
   (
      bool       isEnabled,
      Visibility visibility
   )
   {
      _isEnabled  = isEnabled;
      _visibility = visibility;
   }

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
}
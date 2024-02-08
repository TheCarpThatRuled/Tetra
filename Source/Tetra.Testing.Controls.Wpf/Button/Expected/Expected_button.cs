using System.Windows;

// ReSharper disable InconsistentNaming

namespace Tetra.Testing;

public sealed partial class Expected_button
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly bool       _isEnabled;
   private readonly Visibility _visibility;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private Expected_button
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
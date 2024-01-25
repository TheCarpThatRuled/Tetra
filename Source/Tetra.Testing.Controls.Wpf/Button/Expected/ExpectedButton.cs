using System.Windows;

// ReSharper disable InconsistentNaming

namespace Tetra.Testing;

public sealed partial class ExpectedButton
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly bool       _isEnabled;
   private readonly Visibility _visibility;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private ExpectedButton
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

   public ExceptCarrier<ExpectedButton> Except()
      => new(Function.PassThrough,
             this);

   /* ------------------------------------------------------------ */

   public ExceptCarrier<T> Except<T>
   (
      Func<ExpectedButton, T> createParent
   )
      => new(createParent,
             this);

   /* ------------------------------------------------------------ */
}
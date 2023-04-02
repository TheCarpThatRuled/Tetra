using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class LabelAsserts<T> : AAA_test.IAsserts
   where T : AAA_test.IAsserts
{
   /* ------------------------------------------------------------ */
   // Constructors
   /* ------------------------------------------------------------ */

   public LabelAsserts(string    descriptionHeader,
                       FakeLabel label,
                       T         parent)
   {
      _label             = label;
      _descriptionHeader = descriptionHeader;
      _parent            = parent;
   }

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public LabelAsserts<T> Content_is(object expected)
   {
      Assert.That
            .AreEqual($"{_descriptionHeader}: Content",
                      expected,
                      _label.Content());

      return this;
   }

   /* ------------------------------------------------------------ */

   public LabelAsserts<T> Visibility_is(Visibility expected)
   {
      Assert.That
            .AreEqual($"{_descriptionHeader}: Visibility",
                      expected,
                      _label.Visibility());

      return this;
   }

   /* ------------------------------------------------------------ */
   public T ReturnToParent()
      => _parent;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly FakeLabel _label;
   private readonly string    _descriptionHeader;
   private readonly T         _parent;

   /* ------------------------------------------------------------ */
}
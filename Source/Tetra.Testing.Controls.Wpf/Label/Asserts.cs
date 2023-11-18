using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class LabelAsserts<T> : IAsserts
{
    /* ------------------------------------------------------------ */
    // Private Fields
    /* ------------------------------------------------------------ */

    private readonly FakeLabel _actual;
    private readonly string _descriptionHeader;
    private readonly Func<T> _next;

    /* ------------------------------------------------------------ */
    // Private Constructors
    /* ------------------------------------------------------------ */

    private LabelAsserts
    (
       FakeLabel actual,
       string descriptionHeader,
       Func<T> next
    )
    {
        _actual = actual;
        _descriptionHeader = descriptionHeader;
        _next = next;
    }

    /* ------------------------------------------------------------ */
    // Factory Functions
    /* ------------------------------------------------------------ */

    public static LabelAsserts<T> Create
    (
       string descriptionHeader,
       FakeLabel actual,
       Func<T> next
    )
       => new(actual,
              descriptionHeader,
              next);

    /* ------------------------------------------------------------ */
    // Methods
    /* ------------------------------------------------------------ */

    public LabelAsserts<T> ContentEquals
    (
       object expected
    )
    {
        Assert.That
              .AreEqual($"{_descriptionHeader}: Content",
                        expected,
                        _actual.Content());

        return this;
    }

    /* ------------------------------------------------------------ */

    public LabelAsserts<T> VisibilityEquals
    (
       Visibility expected
    )
    {
        Assert.That
              .AreEqual($"{_descriptionHeader}: Visibility",
                        expected,
                        _actual.Visibility());

        return this;
    }

    /* ------------------------------------------------------------ */

    public T Next()
       => _next();

    /* ------------------------------------------------------------ */
}
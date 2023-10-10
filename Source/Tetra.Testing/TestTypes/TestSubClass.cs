using System.Diagnostics.CodeAnalysis;

namespace Tetra.Testing;

[ExcludeFromCodeCoverage]
public sealed class TestSubClass : TestClass,
                                   IEquatable<TestSubClass>
{
   /* -------------------------------------------------- */
   // Fields
   /* -------------------------------------------------- */

   public readonly bool Value3;

   /* -------------------------------------------------- */
   // Constructors
   /* -------------------------------------------------- */

   public TestSubClass
   (
      int    value1,
      double value2,
      bool   value3
   )
      : base(value1,
             value2)
      => Value3 = value3;

   /* -------------------------------------------------- */
   // IEquatable<TestSubClass> Methods
   /* -------------------------------------------------- */

   public bool Equals
   (
      TestSubClass? other
   )
      => other is not null
      && (ReferenceEquals(this,
                          other)
       || Equivalent(other));

   /* -------------------------------------------------- */
   // Factory Functions
   /* -------------------------------------------------- */

   public static TestSubClass Create
   (
      int    value1,
      double value2,
      bool   value3
   )
      => new(value1,
             value2,
             value3);

   /* -------------------------------------------------- */

   public static TestSubClass Create
   (
      TestClass other,
      bool      value3
   )
      => new(other.Value1,
             other.Value2,
             value3);

   /* -------------------------------------------------- */
   // object Overridden Methods
   /* -------------------------------------------------- */

   public override bool Equals
   (
      object? obj
   )
      => ReferenceEquals(this,
                         obj)
      || obj switch
         {
            TestSubClass other => Equivalent(other),
            TestClass other    => Equivalent(other),
            _                  => false,
         };

   /* -------------------------------------------------- */

   public override int GetHashCode()
      => HashCode
        .Combine(base.GetHashCode(),
                 Value3);

   /* -------------------------------------------------- */

   public override string ToString()
      => $"subclass({Value1}, {Value2}, {Value3})";

   /* -------------------------------------------------- */
   // IEquatable<TestClass> Operators
   /* -------------------------------------------------- */

   public static bool operator ==
   (
      TestSubClass? left,
      TestSubClass? right
   )
      => Equals(left,
                right);

   /* -------------------------------------------------- */

   public static bool operator !=
   (
      TestSubClass? left,
      TestSubClass? right
   )
      => !Equals(left,
                 right);

   /* -------------------------------------------------- */
   // Methods
   /* -------------------------------------------------- */

   public bool Equivalent
   (
      TestSubClass other
   )
      => Equivalent(other as TestClass)
      && Value3 == other.Value3;

   /* -------------------------------------------------- */
}
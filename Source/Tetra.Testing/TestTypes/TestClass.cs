namespace Tetra.Testing;

public class TestClass : IEquatable<TestClass>
{
   /* -------------------------------------------------- */
   // Fields
   /* -------------------------------------------------- */

   public readonly int    Value1;
   public readonly double Value2;

   /* -------------------------------------------------- */
   // Constructors
   /* -------------------------------------------------- */

   public TestClass(int value1,
                    double value2)
   {
      Value1 = value1;
      Value2 = value2;
   }

   /* -------------------------------------------------- */
   // Factory Functions
   /* -------------------------------------------------- */

   public static TestClass Create(int value1,
                                  double value2)
      => new(value1,
             value2);

   /* -------------------------------------------------- */
   // object Overridden Methods
   /* -------------------------------------------------- */

   public override bool Equals(object? obj)
      => ReferenceEquals(this,
                         obj)
      || obj is TestClass other
      && Equivalent(other);

   /* -------------------------------------------------- */

   public override int GetHashCode()
      => HashCode
        .Combine(Value1,
                 Value2);

   /* -------------------------------------------------- */

   public override string ToString()
      => $"class({Value1}, {Value2})";

   /* -------------------------------------------------- */
   // IEquatable<TestClass> Methods
   /* -------------------------------------------------- */

   public bool Equals(TestClass? other)
      => other is not null
      && (ReferenceEquals(this,
                          other)
       || Equivalent(other));

   /* -------------------------------------------------- */
   // IEquatable<TestClass> Operators
   /* -------------------------------------------------- */

   public static bool operator ==(TestClass? left,
                                  TestClass? right)
      => Equals(left,
                right);

   /* -------------------------------------------------- */

   public static bool operator !=(TestClass? left,
                                  TestClass? right)
      => !Equals(left,
                 right);

   /* -------------------------------------------------- */
   // Methods
   /* -------------------------------------------------- */

   public bool Equivalent(TestClass other)
      => Value1.Equals(other.Value1)
      && Value2.Equals(other.Value2);

   /* -------------------------------------------------- */
}
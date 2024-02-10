namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test
{
   public sealed class Parameter<T>
   {
      /* ------------------------------------------------------------ */
      // Internal Fields
      /* ------------------------------------------------------------ */

      internal readonly IOption<T> Value;

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly string _name;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private Parameter
      (
         string     name,
         IOption<T> value
      )
      {
         _name = name;
         Value = value;
      }

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static Parameter<T> Create
      (
         string name
      )
         => new($"{name}<{typeof(T).Name}>",
                Option<T>.None());

      /* ------------------------------------------------------------ */
      // Factory Operators
      /* ------------------------------------------------------------ */

      public static implicit operator Parameter<T>
      (
         T value
      )
         => new(value?.ToString() ?? "null",
                Option.Some(value));

      /* ------------------------------------------------------------ */
      // Overridden object Methods
      /* ------------------------------------------------------------ */

      public override string ToString()
         => _name;

      /* ------------------------------------------------------------ */
   }
}
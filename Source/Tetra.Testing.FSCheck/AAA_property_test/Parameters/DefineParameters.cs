namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test
{
   partial class Parameters
   {
      public sealed class DefineParameters
      {
         /* ------------------------------------------------------------ */
         // Private Fields
         /* ------------------------------------------------------------ */

         private readonly Dictionary<object, object?> _parameters = new();

         /* ------------------------------------------------------------ */
         // Internal Constructors
         /* ------------------------------------------------------------ */

         internal DefineParameters() { }

         /* ------------------------------------------------------------ */
         // Methods
         /* ------------------------------------------------------------ */

         public Parameters Create()
            => new(_parameters);

         /* ------------------------------------------------------------ */

         public DefineParameters Register<T>
         (
            Parameter<T> parameter,
            T            value
         )
         {
            _parameters.Add(parameter,
                            value);

            return this;
         }

         /* ------------------------------------------------------------ */
      }
   }
}
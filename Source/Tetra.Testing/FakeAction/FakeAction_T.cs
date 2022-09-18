﻿namespace Tetra.Testing;

public sealed class FakeAction<T>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a <c>FakeAction</c>.
   /// </summary>
   /// <returns>A <c>FakeAction</c>.</returns>
   public static FakeAction<T> Create()
      => new();

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   /// <summary>
   /// A list of the parameters this <c>FakeAction</c> has been invoked with
   /// </summary>
   public IReadOnlyList<T> Invocations()
      => _invocations;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   /// <summary>
   /// The method that should be passed into the argument that should be faked.
   /// </summary>
   public void Action(T arg)
      => _invocations
        .Add(arg);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Resets the invocation trace.
   /// </summary>
   public void PrepareForAct()
      => _invocations
        .Clear();

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly List<T> _invocations = new();

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FakeAction() { }

   /* ------------------------------------------------------------ */
}

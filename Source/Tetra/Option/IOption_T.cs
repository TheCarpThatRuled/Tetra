﻿namespace Tetra;

/// <summary>
/// An implementation of the "option" (Aka "maybe") monad.
/// An <c>IOption</c> may be in one of two states:
/// <list type="bullet">
/// <item>
/// <description>Some, representing an instance of the contained type;</description>
/// </item>
/// <item>
/// <description>None, representing the absence of an instance of the contained type;</description>
/// </item>
/// </list>
/// </summary>
/// <typeparam name="T">The type of the contained object</typeparam>
public interface IOption<out T>
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Casts the content of this <c>IOption</c> to the new type.
   /// </summary>
   /// <typeparam name="TNew">The type the content of this <c>IOption</c> shall be cast into.</typeparam>
   /// <returns>
   /// If <c>IOption</c> is a some and the cast was successful, a some of the new type;
   /// otherwise a none.
   /// </returns>
   public IOption<TNew> Cast<TNew>();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Identifies if this <c>IOption</c> is in the none state.
   /// </summary>
   /// <returns>
   /// <c>true</c> if this <c>IOption</c> is a none;
   /// <c>false</c> if it is a some.
   /// </returns>
   public bool IsANone();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Identifies if this <c>IOption</c> is in the some state.
   /// </summary>
   /// <returns>
   /// <c>true</c> if this <c>IOption</c> is a some;
   /// <c>false</c> if it is a none.
   /// </returns>
   public bool IsASome();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the contents of the <c>IOption</c> into a new form.
   /// </summary>
   /// <typeparam name="TNew">The type the content of this <c>IOption</c> shall be transformed into, if it is a some.</typeparam>
   /// <param name="whenSome">A mapping function that shall be applied to the content of the <c>IOption</c>, if it is a some.</param>
   /// <returns>
   /// A some containing the content of this <c>IOption</c> mapped through <c>whenSome</c> if it is a some;
   /// otherwise a none.
   /// </returns>
   public IOption<TNew> Map<TNew>(Func<T, TNew> whenSome);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the contents of the <c>IOption</c> into a new form.
   /// </summary>
   /// <typeparam name="TNew">The type the content of this <c>IOption</c> shall be transformed into, if it is a some.</typeparam>
   /// <param name="whenSome">A mapping function that shall be applied to the content of the <c>IOption</c>, if it is a some.</param>
   /// <returns>
   /// The content of this <c>IOption</c> mapped through <c>whenSome</c> if it is a some;
   /// otherwise a none.
   /// </returns>
   public IOption<TNew> Map<TNew>(Func<T, IOption<TNew>> whenSome);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Converts this <c>IOption</c> into a <c>IResult</c>, that is a success containing the contents if this is a some.
   /// </summary>
   /// <param name="whenNone">The value to populate the failure with, if it is a none.</param>
   /// <returns>
   /// A success containing the content of this <c>IOption</c> if it is a some;
   /// otherwise a failure containing the return value of <c>whenNone</c>.
   /// </returns>
   public IResult<T> MapToResult(Message whenNone);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Converts this <c>IOption</c> into a <c>IResult</c>, that is a success containing the contents if this is a some.
   /// </summary>
   /// <param name="whenNone">A function that creates a value to populate the failure with, if it is a none.</param>
   /// <returns>
   /// A success containing the content of this <c>IOption</c> if it is a some;
   /// otherwise a failure containing the return value of <c>whenNone</c>.
   /// </returns>
   public IResult<T> MapToResult(Func<Message> whenNone);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>IOption</c> via a mapping function.
   /// </summary>
   /// <typeparam name="TNew">The type this <c>IOption</c> shall be unified as.</typeparam>
   /// <param name="whenNone">A value to use, if the <c>IOption</c> is a none.</param>
   /// <param name="whenSome">A mapping function that shall be applied to the content of the <c>IOption</c>, if it is a some.</param>
   /// <returns>
   /// The content of this <c>IOption</c> mapped through <c>whenSome</c> if it is a some;
   /// otherwise <c>whenNone</c>.
   /// </returns>
   public TNew Reduce<TNew>(TNew          whenNone,
                            Func<T, TNew> whenSome);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>IOption</c> via mapping functions.
   /// </summary>
   /// <typeparam name="TNew">The type this <c>IOption</c> shall be unified as.</typeparam>
   /// <param name="whenNone">A function that will return the value to use, if the <c>IOption</c> is a none.</param>
   /// <param name="whenSome">A mapping function that shall be applied to the content of the <c>IOption</c>, if it is a some.</param>
   /// <returns>
   /// The content of this <c>IOption</c> mapped through <c>whenSome</c> if it is a some;
   /// otherwise the return value of <c>whenNone</c>.
   /// </returns>
   public TNew Reduce<TNew>(Func<TNew>    whenNone,
                            Func<T, TNew> whenSome);

   /* ------------------------------------------------------------ */
}
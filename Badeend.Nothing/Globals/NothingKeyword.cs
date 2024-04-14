namespace Badeend.Globals;

#pragma warning disable SA1307 // Accessible fields should begin with upper-case letter
#pragma warning disable SA1311 // Static readonly fields should begin with upper-case letter

/// <summary>
/// Contains the `nothing` field.
/// </summary>
public static class NothingKeyword
{
	/// <summary>
	/// The one and only <see cref="Nothing"><c>nothing</c></see> value.
	/// </summary>
	public static readonly Nothing nothing = Nothing.Value;
}

using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Badeend;

/// <summary>
/// An empty struct. This type only exists because C# does not allow
/// <see cref="System.Void"><c>void</c></see> to be used as a type parameter.
/// </summary>
[StructLayout(LayoutKind.Auto)]
public readonly struct Nothing : IEquatable<Nothing>, IComparable<Nothing>, IComparable
{
	private static readonly Nothing Singleton = default;

	/// <summary>
	/// The one and only <see cref="Nothing"><c>nothing</c></see> value.
	/// </summary>
	[Pure]
	public static ref readonly Nothing Value
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => ref Singleton;
	}

	/// <summary>
	/// Returns an empty string.
	/// </summary>
	[Pure]
	public override string? ToString() => string.Empty;

	/// <summary>
	/// Check for equality.
	/// </summary>
	[Pure]
	[Obsolete("Comparison is always true.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static bool operator ==(Nothing left, Nothing right) => true;

	/// <summary>
	/// Check for inequality.
	/// </summary>
	[Pure]
	[Obsolete("Comparison is always false.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static bool operator !=(Nothing left, Nothing right) => false;

#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
	/// <inheritdoc/>
	[Pure]
	[Obsolete("Use pattern matching instead. Example: `x is Nothing`")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override bool Equals(object? obj) => obj is Nothing;
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member

	/// <inheritdoc/>
	[Pure]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	bool IEquatable<Nothing>.Equals(Nothing other) => true;

	/// <inheritdoc/>
	[Pure]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int GetHashCode() => 0;

	/// <inheritdoc/>
	[Pure]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	int IComparable<Nothing>.CompareTo(Nothing other) => 0;

	/// <inheritdoc/>
	[Pure]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	int IComparable.CompareTo(object? other) => other switch
	{
		null => 1,
		Nothing => 0,
		_ => throw new ArgumentException("Comparison with incompatible type", nameof(other)),
	};
}

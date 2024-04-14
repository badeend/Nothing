using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Badeend;

namespace Badeend.Tests;

#pragma warning disable CS1718 // Comparison made to same variable
#pragma warning disable CS0183 // 'is' expression's given expression is always of the provided type
#pragma warning disable CS0618 // Type or member is obsolete

public class Tests
{
	private static readonly object nothingObject = (object)nothing;
	private static readonly IEquatable<Nothing> nothingEquatableT = (IEquatable<Nothing>)nothing;
	private static readonly IComparable nothingComparable = (IComparable)nothing;
	private static readonly IComparable<Nothing> nothingComparableT = (IComparable<Nothing>)nothing;

	[Fact]
	public void TheTests()
	{
		Assert.True(nothing is Nothing);
		Assert.True(nothingObject is Nothing);
		Assert.True(nothing == nothing);
		Assert.False(nothing != nothing);
		Assert.True(nothing == default);
		Assert.False(nothing != default);
		Assert.True(nothing == Nothing.Value);
		Assert.False(nothing != Nothing.Value);
		Assert.True(nothingEquatableT.Equals(nothing));
		Assert.True(nothingObject.Equals(nothing));

		Assert.True(nothing.GetHashCode() == 0);

		Assert.True(nothing.ToString() == "");

		Assert.True(nothingComparable.CompareTo(null) == 1);
		Assert.True(nothingComparable.CompareTo(nothing) == 0);
		Assert.ThrowsAny<Exception>(() => nothingComparable.CompareTo("Bad"));
		Assert.True(nothingComparableT.CompareTo(nothing) == 0);

	}
}

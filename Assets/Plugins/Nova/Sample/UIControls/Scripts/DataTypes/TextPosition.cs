using Nova;
using System;
using TMPro;
using UnityEngine;

namespace NovaSamples.UIControls
{
    /// <summary>
    /// Represents a location in a <see cref="Nova.TextBlock"/> string as both an
    /// index into the string (char array), as well as a side (i.e., left or right
    /// of the character at <see cref="Index"/> in the string).<br/>
    /// </summary>
    /// <remarks>
    /// NOTE: <see cref="TextPosition"/> is intrinsically tied to a <see cref="Nova.TextBlock"/>
    /// because it represents a position in the <b>visible</b> string, which adds a number of nuances
    /// and requires some additional functionality beyond indexing into a raw string. For example:
    /// <list type="bullet">
    /// <item>
    /// Due to wrapping, a string which doesn't contain any newlines may be on multiple (visual) lines.
    /// </item>
    /// <item>
    /// Certain positions are not valid, such as being on the right side of a newline character.
    /// </item>
    /// <item>
    /// The left and right side of zero-width characters should be considered equivalent, since
    /// visually they are identical.
    /// </item>
    /// </list>
    /// </remarks>
    public struct TextPosition : IEquatable<TextPosition>
    {
        /// <summary>
        /// The <see cref="Nova.TextBlock"/> with which this <see cref="TextPosition"/>
        /// is associated.
        /// </summary>
        public TextBlock TextBlock { get; private set; }
        /// <summary>
        /// The current location in <see cref="TextInfo">TextInfo</see>.<see cref="TMP_TextInfo.characterInfo">characterInfo</see>,
        /// with the visible location depending on <see cref="IsRightSide"/>.
        /// </summary>
        public int Index { get; private set; }
        /// <summary>
        /// True if on the right side of the character at <see cref="Index"/>, false
        /// if on the left side.
        /// </summary>
        public bool IsRightSide { get; private set; }

        /// <summary>
        /// The current character at <see cref="Index"/>. 
        /// </summary>
        /// <remarks>
        /// Will throw an exception if not in bounds.
        /// </remarks>
        public TMP_CharacterInfo Char
        {
            get
            {
                if (IsPastBounds)
                {
                    throw new Exception($"Tried to get Char for position past bounds: {this}");
                }

                return TextInfo.characterInfo[Index];
            }
        }

        /// <summary>
        /// The line containing the current position.
        /// </summary>
        /// <remarks>
        /// Will throw an exception if not in bounds.
        /// </remarks>
        public TMP_LineInfo Line => TextInfo.lineInfo[LineNumber];

        /// <summary>
        /// The TMP TextInfo associated with this position.
        /// </summary>
        public TMP_TextInfo TextInfo => TextBlock.TMP.textInfo;

        /// <summary>
        /// True if the text mesh is empty.
        /// </summary>
        public bool TextMeshIsEmpty => TextInfo.characterCount == 0;

        /// <summary>
        /// The number of characters in the string.
        /// </summary>
        public int CharCount => TextInfo.characterCount;

        /// <summary>
        /// The line number of the current position.
        /// </summary>
        public int LineNumber => Char.lineNumber;

        /// <summary>
        /// The visual offset that needs to be applied to get correct block space positioning.
        /// </summary>
        private Vector2 VisualOffset => TextBlock.VisualOffset;

        /// <summary>
        /// Is the position outside of the bounds?
        /// </summary>
        public bool IsPastBounds => Index < 0 || Index >= CharCount;

        /// <summary>
        /// Not every position is valid, even if it is within bounds. E.g., the right side of a new line.
        /// </summary>
        public bool IsValid
        {
            get
            {
                if (IsPastBounds)
                {
                    // Not in bounds
                    return false;
                }

                if (Char.IsNewline() && IsRightSide)
                {
                    // Don't allow to be on the right side of a newline (since we always
                    // append empty spaces after newlines)
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// Throws an exception if position is not valid.
        /// </summary>
        private void ThrowIfInvalid()
        {
            if (!IsValid)
            {
                throw new Exception($"Invalid position: {this}");
            }
        }

        /// <summary>
        /// The height of the current character in <see cref="TextBlock"/> space.
        /// </summary>
        public float CharHeight
        {
            get
            {
                ThrowIfInvalid();
                var character = Char;
                return character.ascender - character.descender;
            }
        }

        /// <summary>
        /// The current y-position in <see cref="TextBlock"/> space.
        /// </summary>
        public float YPos
        {
            get
            {
                ThrowIfInvalid();

                if (TextInfo.textComponent.verticalAlignment == VerticalAlignmentOptions.Geometry)
                {
                    return 0f;
                }

                var character = Char;
                return .5f * (character.descender + character.ascender) + VisualOffset.y;
            }
        }

        /// <summary>
        /// The current x-position in <see cref="TextBlock"/> space.
        /// </summary>
        /// <remarks>
        /// NOTE: This is <b>NOT</b> the center position of the character, but will be its left
        /// or right edge, depending on the value of <see cref="IsRightSide"/>.
        /// </remarks>
        public float XPos
        {
            get
            {
                ThrowIfInvalid();
                return (IsRightSide ? Char.xAdvance : Char.origin) + VisualOffset.x;
            }
        }

        /// <summary>
        /// The height of the current line in <see cref="TextBlock"/> space.
        /// </summary>
        public float LineHeight
        {
            get
            {
                ThrowIfInvalid();
                return Line.lineHeight;
            }
        }

        /// <summary>
        /// The center of the current line in <see cref="TextBlock"/> space.
        /// </summary>
        public float LineYCenter
        {
            get
            {
                ThrowIfInvalid();
                return Line.descender + .5f * LineHeight + VisualOffset.y;
            }
        }

        /// <summary>
        /// The index of the current position in the raw string.
        /// </summary>
        public int StringIndex
        {
            get
            {
                if (TextMeshIsEmpty)
                {
                    return 0;
                }

                return IsRightSide ? Char.index + Char.stringLength : Char.index;
            }
        }

        /// <summary>
        /// For debugging
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Index}:{(IsRightSide ? "Right" : "Left")}";
        }

        #region Creation
        /// <summary>
        /// Creates a new <see cref="TextPosition"/> at the specified index and side.<br/>
        /// NOTE: Does not do any validation.
        /// </summary>
        public static TextPosition Create(TextBlock textBlock, int index, bool right = false)
        {
            return new TextPosition()
            {
                Index = index,
                TextBlock = textBlock,
                IsRightSide = right
            };
        }

        /// <summary>
        /// Tries to create a <see cref="TextPosition"/> from the provided <paramref name="worldSpaceRay"/>.
        /// If <paramref name="worldSpaceRay"/> is valid and intersects the plane of <paramref name="textBlock"/>, 
        /// this will return true with <paramref name="pos"/> being the nearest location to the intersection.
        /// If there is no valid intersection, will return false.
        /// </summary>
        public static bool TryCreate(TextBlock textBlock, Ray worldSpaceRay, out TextPosition pos)
        {
            if (string.IsNullOrEmpty(textBlock.Text))
            {
                // If the string is empty, just return a position at index 0
                pos = Create(textBlock, 0);
                return true;
            }

            // Convert the ray to a point in text block space
            Plane textBlockPlane = new Plane(-textBlock.transform.forward, textBlock.transform.position);
            if (!textBlockPlane.Raycast(worldSpaceRay, out float hitDistance))
            {
                // No valid intersection
                pos = default;
                return false;
            }

            Vector3 worldSpacePos = worldSpaceRay.GetPoint(hitDistance);
            pos = CreateAtWorldSpace(textBlock, worldSpacePos);
            return true;
        }

        /// <summary>
        /// Creates a <see cref="TextPosition"/> closest to the provided world-space position.
        /// </summary>
        public static TextPosition CreateAtWorldSpace(TextBlock textBlock, Vector3 worldSpacePosition)
        {
            if (string.IsNullOrEmpty(textBlock.Text))
            {
                // If the string is empty, just return a position at index 0
                return Create(textBlock, 0);
            }

            // Convert into the TextBlock's local space
            Vector3 localSpace = textBlock.transform.InverseTransformPoint(worldSpacePosition);
            return CreateAtLocalSpace(textBlock, localSpace);
        }

        /// <summary>
        /// Creates a <see cref="TextPosition"/> closest to the provided <paramref name="textBlock"/>-space position.
        /// </summary>
        public static TextPosition CreateAtLocalSpace(TextBlock textBlock, Vector3 blockSpacePosition)
        {
            if (string.IsNullOrEmpty(textBlock.Text))
            {
                // If the string is empty, just return a position at index 0
                return Create(textBlock, 0);
            }

            // Get the line closest to the position
            float lastDistance = float.MaxValue;
            int closestLine = 0;

            // Go through each line and compare the distance to the provided position
            // NOTE: We need to use YPos as we need to apply VisualOffset
            for (int i = 0; i < textBlock.TMP.textInfo.lineCount; i++)
            {
                // Get a position on the line
                TextPosition curr = CreateAtBeginningOfLine(textBlock, i);

                // Get the distance from the center of the line
                float distanceFromLineCenter = blockSpacePosition.y - curr.LineYCenter;
                float absDistance = Mathf.Abs(distanceFromLineCenter);

                if (absDistance > lastDistance)
                {
                    // We've passed the closest line, don't need to check the rest
                    // as they will all be larger
                    break;
                }

                // We got closer, so keep looking
                lastDistance = absDistance;
                closestLine = i;
            }

            return CreateOnLine(textBlock, closestLine, blockSpacePosition.x);
        }

        /// <summary>
        /// Creates a <see cref="TextPosition"/> at the beginning of the specified line.
        /// </summary>
        public static TextPosition CreateAtBeginningOfLine(TextBlock textBlock, int lineNumber)
        {
            if (lineNumber >= textBlock.TMP.textInfo.lineInfo.Length)
            {
                throw new Exception($"Tried to create a {nameof(TextPosition)} at line {lineNumber} when there were only {textBlock.TMP.textInfo.lineInfo.Length} lines.");
            }

            // Create a position on the left side of the first character on the line
            TextPosition pos = Create(textBlock, textBlock.TMP.textInfo.lineInfo[lineNumber].firstCharacterIndex, false);

            // Call MoveToStartOfLine to ensure it's in a valid position
            return pos.MoveToStartOfLine();
        }

        /// <summary>
        /// Creates a <see cref="TextPosition"/> on the specified <paramref name="lineNumber"/>, closest
        /// to <paramref name="blockSpaceXPos"/>.
        /// </summary>
        public static TextPosition CreateOnLine(TextBlock textBlock, int lineNumber, float blockSpaceXPos)
        {
            if (lineNumber >= textBlock.TMP.textInfo.lineInfo.Length)
            {
                throw new Exception($"Tried to create a {nameof(TextPosition)} at line {lineNumber} when there were only {textBlock.TMP.textInfo.lineInfo.Length} lines.");
            }

            // Start at the beginning of the line
            TextPosition curr = CreateAtBeginningOfLine(textBlock, lineNumber);
            TextPosition closestPos = default;

            // Track the distance of the last position we visited
            float lastDistance = float.MaxValue;

            while (true)
            {
                float distance = Mathf.Abs(curr.XPos - blockSpaceXPos);

                if (distance > lastDistance)
                {
                    // We've passed the closest position, don't need to check the rest
                    // as they will all be larger
                    break;
                }

                // Save off the closest position
                closestPos = curr;

                // Move to the right
                TextPosition next = curr.MoveRight();

                if (next.Equals(curr) || next.LineNumber != curr.LineNumber)
                {
                    // If they are equal, it means it's the end of the string, and
                    // if the line numbers differ it means we've reached the end of
                    // the line.
                    break;
                }

                // Save off the distance for this position
                lastDistance = distance;
                curr = next;
            }

            return closestPos;
        }
        #endregion

        #region Operators
        /// <summary>
        /// A value that can be used to compare two <see cref="TextPosition"/>s, but is otherwise
        /// meaningless.
        /// </summary>
        private int ComparisonValue => Index + (IsRightSide ? 1 : 0);

        public bool Equals(TextPosition other) => ComparisonValue == other.ComparisonValue;

        public static bool operator >(TextPosition a, TextPosition b) => a.ComparisonValue > b.ComparisonValue;

        public static bool operator <(TextPosition a, TextPosition b) => a.ComparisonValue < b.ComparisonValue;
        #endregion
    }

    public static class TextPositionExtensions
    {
        /// <summary>
        /// Moves <paramref name="pos"/> to the right <paramref name="count"/> times. Will
        /// move lines if necessary, and if there are no valid positions to the right, <paramref name="pos"/>
        /// will be returned.
        /// </summary>
        /// <remarks>
        /// If <paramref name="pos"/> is invalid, it will be returned.
        /// </remarks>
        public static TextPosition MoveRight(this TextPosition pos, int count = 1)
        {
            if (!pos.IsValid)
            {
                return pos;
            }

            for (int i = 0; i < count; ++i)
            {
                pos = pos.MoveOneVisiblePosition(1);
            }
            return pos;
        }

        /// <summary>
        /// Moves <paramref name="pos"/> to the left <paramref name="count"/> times. Will
        /// move lines if necessary, and if there are no valid positions to the left, <paramref name="pos"/>
        /// will be returned.
        /// </summary>
        /// <remarks>
        /// If <paramref name="pos"/> is invalid, it will be returned.
        /// </remarks>
        public static TextPosition MoveLeft(this TextPosition pos, int count = 1)
        {
            if (!pos.IsValid)
            {
                return pos;
            }

            for (int i = 0; i < count; ++i)
            {
                pos = pos.MoveOneVisiblePosition(-1);
            }
            return pos;
        }

        /// <summary>
        /// The characters used to denote a word boundaries. This can be modified based on
        /// preference.
        /// </summary>
        private static readonly char[] wordSeparators = { ' ', '.', ',', '\t', '\r', '\n' };

        /// <summary>
        /// Moves <paramref name="pos"/> to the right until it reaches the start of a word.
        /// If there are no valid positions to the left, <paramref name="pos"/> will be returned.
        /// </summary>
        /// <remarks>
        /// If <paramref name="pos"/> is invalid, it will be returned.
        /// </remarks>
        public static TextPosition MoveToEndOfWord(this TextPosition pos)
        {
            if (pos.IsPastBounds)
            {
                return pos;
            }

            // Find the first instance of a word separator to the right of the current position
            int spaceLoc = pos.TextBlock.Text.IndexOfAny(wordSeparators, pos.StringIndex);
            if (spaceLoc == -1)
            {
                // Didn't find any word separators, so just move to the end of the string
                return pos.MoveToEnd();
            }

            // Create a new position with the found index
            return TextPosition.Create(pos.TextBlock, spaceLoc - 1, true);
        }

        /// <summary>
        /// Moves <paramref name="pos"/> to the left until it reaches the start of a word.
        /// If there are no valid positions to the left, <paramref name="pos"/> will be returned.
        /// </summary>
        /// <remarks>
        /// If <paramref name="pos"/> is invalid, it will be returned.
        /// </remarks>
        public static TextPosition MoveToStartOfWord(this TextPosition pos)
        {
            if (pos.IsPastBounds || pos.StringIndex == 0)
            {
                // If we are at the beginning of the string or out of bounds,
                // nothing to do
                return pos;
            }

            // Find the first instance of a word separator to the left of the current position
            // NOTE: We start at pos.StringIndex - 1 since pos might already be at a word boundary.
            int spaceLoc = pos.TextBlock.Text.LastIndexOfAny(wordSeparators, pos.StringIndex - 1);
            if (spaceLoc == -1)
            {
                // Didn't find any word separators, so just move to the beginning of the string.
                return pos.MoveToStart();
            }

            // Create a new position with the found location
            return TextPosition.Create(pos.TextBlock, spaceLoc + 1, false);
        }

        /// <summary>
        /// Moves <paramref name="pos"/> to the last valid position on the line.
        /// </summary>
        /// <remarks>
        /// If <paramref name="pos"/> is invalid, it will be returned.
        /// </remarks>
        public static TextPosition MoveToEndOfLine(this TextPosition pos)
        {
            if (pos.IsPastBounds)
            {
                return pos;
            }

            // Create new position on the right side last character on line
            pos = TextPosition.Create(pos.TextBlock, pos.Line.lastCharacterIndex, true);

            // Move to the left until valid
            return pos.MoveUntilValid(-1);
        }

        /// <summary>
        /// Moves <paramref name="pos"/> to the first valid position on the line.
        /// </summary>
        /// <remarks>
        /// If <paramref name="pos"/> is invalid, it will be returned.
        /// </remarks>
        public static TextPosition MoveToStartOfLine(this TextPosition pos)
        {
            if (pos.IsPastBounds)
            {
                return pos;
            }

            // Create new position on the left side of first character on line
            pos = TextPosition.Create(pos.TextBlock, pos.Line.firstCharacterIndex, false);

            // Move to the right until valid
            return pos.MoveUntilValid(1);
        }

        /// <summary>
        /// Moves <paramref name="pos"/> to the first valid position.
        /// </summary>
        public static TextPosition MoveToStart(this TextPosition pos)
        {
            // Create new position at the left side of index 0,
            pos = TextPosition.Create(pos.TextBlock, 0, false);

            // Move to the right until valid
            return pos.MoveUntilValid(1);
        }

        /// <summary>
        /// Moves <paramref name="pos"/> to the last valid position.
        /// </summary>
        public static TextPosition MoveToEnd(this TextPosition pos)
        {
            // Create new position on the right side of the last character
            pos = TextPosition.Create(pos.TextBlock, pos.TextInfo.characterCount - 1, true);

            // Move left until valid
            return pos.MoveUntilValid(-1);
        }

        /// <summary>
        /// Moves <paramref name="pos"/> up one line, or to the beginning of the line if
        /// <paramref name="pos"/> is already on the first line.
        /// </summary>
        /// <remarks>
        /// If <paramref name="pos"/> is invalid, it will be returned.
        /// </remarks>
        public static TextPosition MoveUp(this TextPosition pos)
        {
            if (!pos.IsValid)
            {
                return pos;
            }

            if (pos.LineNumber == 0)
            {
                // Already on first line
                return pos.MoveToStartOfLine();
            }

            // Create a new position on the previous line
            return TextPosition.CreateOnLine(pos.TextBlock, pos.LineNumber - 1, pos.XPos);
        }

        /// <summary>
        /// Moves <paramref name="pos"/> down one line, or to the end of the line if
        /// <paramref name="pos"/> is already on the last line.
        /// </summary>
        /// <remarks>
        /// If <paramref name="pos"/> is invalid, it will be returned.
        /// </remarks>
        public static TextPosition MoveDown(this TextPosition pos)
        {
            if (!pos.IsValid)
            {
                return pos;
            }

            if (pos.LineNumber == pos.TextInfo.lineCount - 1)
            {
                // Already on the last line, move it to the end.
                return pos.MoveToEndOfLine();
            }

            // Create a new position on the next line
            return TextPosition.CreateOnLine(pos.TextBlock, pos.LineNumber + 1, pos.XPos);
        }

        /// <summary>
        /// Moves <paramref name="pos"/> in the specified direction until a valid position is reached.
        /// If <paramref name="pos"/> is already valid, just returns it.
        /// </summary>
        /// <remarks>
        /// If a valid position is not found, will throw an exception.
        /// </remarks>
        private static TextPosition MoveUntilValid(this TextPosition pos, int direction)
        {
            if (pos.IsValid)
            {
                // Already valid
                return pos;
            }

            if (pos.TextMeshIsEmpty)
            {
                // String is empty, so just return a position at 0
                return TextPosition.Create(pos.TextBlock, 0, false);
            }

            if (!pos.TryGetNextValid(direction, out TextPosition valid))
            {
                throw new Exception("Failed to get valid position");
            }

            return valid;
        }

        /// <summary>
        /// Moves <paramref name="pos"/> one <b>visible</b> position in the specified direction.
        /// </summary>
        private static TextPosition MoveOneVisiblePosition(this TextPosition pos, int direction)
        {
            TextPosition curr = pos;

            // While there are valid positions to check in the specified direction
            while (curr.TryGetNextValid(direction, out TextPosition potentialPos))
            {
                if (GetVisibleDifference(potentialPos, pos) > 0)
                {
                    // There is a visible difference between the two positions
                    return potentialPos;
                }

                // The two positions were visually the same, so keep trying the next position
                curr = potentialPos;
            }

            // If we got to here, didn't find one, so just return the input position
            return pos;
        }

        /// <summary>
        /// Gets the visible difference the two positions (i.e., zero-width characters would not contribute).
        /// </summary>
        private static int GetVisibleDifference(TextPosition rightPosition, TextPosition leftPosition)
        {
            if (leftPosition > rightPosition)
            {
                // Flip the arguments
                return GetVisibleDifference(leftPosition, rightPosition);
            }

            int diff = 0;

            // While the left and right positions are not equal
            while (!leftPosition.Equals(rightPosition))
            {
                if (!leftPosition.IsRightSide && (leftPosition.Char.HasWidth() || leftPosition.Char.IsNewline()))
                {
                    // If it is on the left side of the character, we will move it right so if
                    // the character has width or is a newline, bump the diff
                    diff += 1;
                }

                // Move the left position to the right by 1
                leftPosition = leftPosition.MoveUnsafe(1);
            }

            return diff;
        }

        /// <summary>
        /// Tries to get the first valid position in <paramref name="direction"/> from <paramref name="pos"/>.
        /// </summary>
        private static bool TryGetNextValid(this TextPosition pos, int direction, out TextPosition outPos)
        {
            outPos = pos;
            do
            {
                // Move one unit in direction
                outPos = outPos.MoveUnsafe(direction);

                if (outPos.IsValid)
                {
                    // It's a valid position
                    return true;
                }

            } while (!outPos.IsPastBounds);

            // We were not able to get a valid position
            return false;
        }

        /// <summary>
        /// Moves <paramref name="pos"/> one position in the specified direction, without doing 
        /// any bounds or validity checks.
        /// </summary>
        private static TextPosition MoveUnsafe(this TextPosition pos, int direction)
        {
            if (direction > 0)
            {
                // Moving right
                if (!pos.IsRightSide)
                {
                    // Currently on left side, so just move it to the right of the same index
                    return TextPosition.Create(pos.TextBlock, pos.Index, right: true);
                }
                else
                {
                    // Currently on right side, so move it to the left of the next index
                    return TextPosition.Create(pos.TextBlock, pos.Index + 1, right: false);
                }
            }
            else
            {
                // Moving left
                if (pos.IsRightSide)
                {
                    // Currently on the right side, so just move it to the left of the same index
                    return TextPosition.Create(pos.TextBlock, pos.Index, right: false);
                }
                else
                {
                    // Currently on left side, so move it to the right of the previous index
                    return TextPosition.Create(pos.TextBlock, pos.Index - 1, right: true);
                }
            }
        }
    }
}
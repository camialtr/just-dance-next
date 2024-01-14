// Copyright (c) Supernova Technologies LLC
using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace Nova
{
    /// <summary>
    /// A two-dimensional indexer
    /// </summary>
    /// <seealso cref="Row"/>
    /// <seealso cref="Column"/>
    public struct GridIndex : IEquatable<GridIndex>
    {
        /// <summary>
        /// The row index
        /// </summary>
        public int Row;
        /// <summary>
        /// The column index
        /// </summary>
        public int Column;

        /// <summary>
        /// Create a new grid index
        /// </summary>
        /// <param name="row">The value to assign to <see cref="Row"/></param>
        /// <param name="col">The value to assign to <see cref="Column"/></param>
        public GridIndex(int row, int col)
        {
            Row = row;
            Column = col;
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="lhs">Left hand side</param>
        /// <param name="rhs">Right hand side</param>
        /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.Row == <paramref name="rhs"/>.Row &amp;&amp; <paramref name="lhs"/>.Column == <paramref name="rhs"/>.Column</c></returns>
        public static bool operator ==(GridIndex lhs, GridIndex rhs)
        {
            return lhs.Column == rhs.Column &&
                   lhs.Row == rhs.Row;
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="lhs">Left hand side</param>
        /// <param name="rhs">Right hand side</param>
        /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.Row != <paramref name="rhs"/>.Row || <paramref name="lhs"/>.Column != <paramref name="rhs"/>.Column</c></returns>
        public static bool operator !=(GridIndex lhs, GridIndex rhs)
        {
            return lhs.Column != rhs.Column ||
                   lhs.Row != rhs.Row;
        }

        /// <summary>
        /// Equality compare
        /// </summary>
        /// <param name="other">The other <see cref="GridIndex"/> to compare</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c></returns>
        public bool Equals(GridIndex other)
        {
            return this == other;
        }

        /// <summary>
        /// Equality compare
        /// </summary>
        /// <param name="other">The other <see cref="GridIndex"/> to compare</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c></returns>
        public override bool Equals(object other)
        {
            switch (other)
            {
                case GridIndex index:
                    return this == index;
                default:
                    return false;
            }
        }

        /// <summary>
        /// The hashcode for this <see cref="GridIndex"/>
        /// </summary>
        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + Row.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Column.GetHashCode();
            return InternalVar_1;
        }

        /// <summary>
        /// Convert this <see cref="GridIndex"/> to a string
        /// </summary>
        /// <returns>The string representation of this <see cref="GridIndex"/></returns>
        public override string ToString()
        {
            return $"r: {Row}, c: {Column}";
        }
    }

    /// <summary>
    /// A read-only utility wrapper around an <see cref="IList{T}"/> (see <see cref="Source"/>) to simplify indexing into the list by rows and columns
    /// </summary>
    /// <typeparam name="T">The type of element in the underlying <see cref="Source"/></typeparam>
    public readonly struct GridList<T> : IEquatable<GridList<T>>
    {
        private readonly ref struct InternalType_30
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public readonly int InternalField_110;
            public readonly T this[int InternalParameter_188]
            {
                get
                {
                    if (InternalParameter_188 < 0 || InternalParameter_188 >= InternalField_110)
                    {
                        UnityEngine.Debug.LogError($"Column [{InternalParameter_188}] out of range [0, {InternalField_110})");
                        return default(T);
                    }

                    int InternalVar_1 = InternalField_111 + (InternalParameter_188 * InternalField_112);
                    return (T)InternalField_113[InternalVar_1];
                }
            }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private readonly int InternalField_111;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private readonly int InternalField_112;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private readonly IList<T> InternalField_113;
            internal InternalType_30(IList<T> InternalParameter_189, int InternalParameter_190, int InternalParameter_191, int InternalParameter_192)
            {
                this.InternalField_113 = InternalParameter_189;
                this.InternalField_111 = InternalParameter_190;
                this.InternalField_112 = InternalParameter_191;
                this.InternalField_110 = InternalParameter_192;
            }
        }

        private readonly ref struct InternalType_31
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public readonly int InternalField_114;
            public readonly T this[int InternalParameter_193]
            {
                get
                {
                    if (InternalParameter_193 < 0 || InternalParameter_193 >= InternalField_114)
                    {
                        UnityEngine.Debug.LogError($"Row [{InternalParameter_193}] out of range [0, {InternalField_114})");
                        return default(T);
                    }

                    int InternalVar_1 = InternalField_115 + (InternalParameter_193 * InternalField_116);
                    return (T)InternalField_117[InternalVar_1];
                }
            }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private readonly int InternalField_115;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private readonly int InternalField_116;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private readonly IList<T> InternalField_117;
            internal InternalType_31(IList<T> InternalParameter_194, int InternalParameter_195, int InternalParameter_196, int InternalParameter_197)
            {
                this.InternalField_117 = InternalParameter_194;
                this.InternalField_115 = InternalParameter_195;
                this.InternalField_116 = InternalParameter_196;
                this.InternalField_114 = InternalParameter_197;
            }
        }

        /// <summary>
        /// Indicates if this grid was configured to have a dynamic number of rows and a fixed number of columns
        /// </summary>
        public readonly bool InfiniteRows => InternalField_108 < 0;

        /// <summary>
        /// Indicates if this grid was configured to have a dynamic number of columns and a fixed number of rows
        /// </summary>
        public readonly bool InfiniteColumns => InternalField_109 < 0;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private readonly int InternalField_108;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private readonly int InternalField_109;

        /// <summary>
        /// The underlying list wrapped by this <see cref="GridList{T}"/>
        /// </summary>
        public readonly IList<T> Source;

        /// <summary>
        /// The number of rows in the grid
        /// </summary>
        public readonly int Rows
        {
            get
            {
                if (Source == null)
                {
                    return 0;
                }

                if (InfiniteRows)
                {
                    return GetRowIndex(Source.Count);
                }

                return math.min(Source.Count, InternalField_108);
            }
        }

        /// <summary>
        /// The number of columns in the grid
        /// </summary>
        public readonly int Columns
        {
            get
            {
                if (Source == null)
                {
                    return 0;
                }

                if (InfiniteColumns)
                {
                    return GetColumnIndex(Source.Count);
                }

                return math.min(Source.Count, InternalField_109);
            }
        }

        /// <summary>
        /// Get the element stored at the given <paramref name="row"/> and <paramref name="column"/>
        /// </summary>
        /// <param name="row">The row index</param>
        /// <param name="column">The column index</param>
        /// <returns>The element of type <typeparamref name="T"/> at the given <paramref name="row"/> and <paramref name="column"/></returns>
        /// <exception cref="InvalidOperationException">Thrown when the grid hasn't been constructed via <see cref="CreateWithRows(IList{T}, int)"/> or <see cref="CreateWithColumns(IList{T}, int)"/></exception>
        public readonly T this[int row, int column]
        {
            get
            {
                InternalMethod_245(this);

                return InfiniteRows ? InternalMethod_243(column)[row] : InternalMethod_242(row)[column];
            }
        }

        /// <summary>
        /// Get the element stored at the given <paramref name="index"/>
        /// </summary>
        /// <param name="index">The <see cref="GridIndex"/> of the element to access</param>
        /// <returns>The element of type <typeparamref name="T"/> at the given <paramref name="index"/></returns>
        /// <exception cref="InvalidOperationException">Thrown when the grid hasn't been constructed via <see cref="CreateWithRows(IList{T}, int)"/> or <see cref="CreateWithColumns(IList{T}, int)"/></exception>
        public readonly T this[GridIndex index]
        {
            get
            {
                InternalMethod_245(this);

                return InfiniteRows ? InternalMethod_243(index.Column)[index.Row] : InternalMethod_242(index.Row)[index.Column];
            }
        }

        /// <summary>
        /// Convert a 1D index into the underlying list, <see cref="Source"/>, into a 2D <see cref="GridIndex"/> for the current grid
        /// </summary>
        /// <param name="sourceIndex">The index into the underlying list, <see cref="Source"/></param>
        /// <returns>The <see cref="GridIndex"/> into this grid of the element at the <paramref name="sourceIndex"/> of the underlying list</returns>
        /// <seealso cref="ToSourceIndex(GridIndex)"/>
        /// <exception cref="InvalidOperationException">Thrown when the grid hasn't been constructed via <see cref="CreateWithRows(IList{T}, int)"/> or <see cref="CreateWithColumns(IList{T}, int)"/></exception>
        public GridIndex ToGridIndex(int sourceIndex)
        {
            InternalMethod_245(this);

            return new GridIndex()
            {
                Row = GetRowIndex(sourceIndex),
                Column = GetColumnIndex(sourceIndex),
            };
        }

        /// <summary>
        /// Convert a 2D <paramref name="gridIndex"/> into the current grid into a 1D index into <see cref="Source"/>
        /// </summary>
        /// <param name="gridIndex">The index into the current grid</param>
        /// <returns>The 1D index in the underlying list of the element at <paramref name="gridIndex"/> in this grid</returns>
        /// <exception cref="InvalidOperationException">Thrown when the grid hasn't been constructed via <see cref="CreateWithRows(IList{T}, int)"/> or <see cref="CreateWithColumns(IList{T}, int)"/></exception>
        public int ToSourceIndex(GridIndex gridIndex)
        {
            InternalMethod_245(this);

            return InfiniteRows ? (gridIndex.Row * InternalField_109) + gridIndex.Column : (gridIndex.Column * InternalField_108) + gridIndex.Row;
        }

        /// <summary>
        /// Get the grid row index of the element at <paramref name="sourceIndex"/>
        /// </summary>
        /// <param name="sourceIndex">A 1D index into <see cref="Source"/></param>
        /// <returns>The row into the grid of the element at <paramref name="sourceIndex"/> into <see cref="Source"/></returns>
        /// <exception cref="InvalidOperationException">Thrown when the grid hasn't been constructed via <see cref="CreateWithRows(IList{T}, int)"/> or <see cref="CreateWithColumns(IList{T}, int)"/></exception>
        public readonly int GetRowIndex(int sourceIndex)
        {
            InternalMethod_245(this);

            return InfiniteRows ? sourceIndex / InternalField_109 : sourceIndex % InternalField_108;
        }

        /// <summary>
        /// Get the grid column index of the element at <paramref name="sourceIndex"/>
        /// </summary>
        /// <param name="sourceIndex">A 1D index into <see cref="Source"/></param>
        /// <returns>The column into the grid of the element at <paramref name="sourceIndex"/> into <see cref="Source"/></returns>
        /// <exception cref="InvalidOperationException">Thrown when the grid hasn't been constructed via <see cref="CreateWithRows(IList{T}, int)"/> or <see cref="CreateWithColumns(IList{T}, int)"/></exception>
        public readonly int GetColumnIndex(int sourceIndex)
        {
            InternalMethod_245(this);

            return InfiniteColumns ? sourceIndex / InternalField_108 : sourceIndex % InternalField_109;
        }

        
        private readonly InternalType_30 InternalMethod_242(int InternalParameter_182)
        {
            int InternalVar_1 = InternalParameter_182 * Columns;
            int InternalVar_2 = InfiniteRows ? Columns : 1;
            int InternalVar_3 = InternalVar_1 + Columns <= Source.Count ? Columns : InternalVar_1 + Columns - Source.Count;
            return new InternalType_30(Source, InternalVar_1, InternalVar_2, InternalVar_3);
        }

        
        private readonly InternalType_31 InternalMethod_243(int InternalParameter_183)
        {
            int InternalVar_1 = InternalParameter_183 * Rows;
            int InternalVar_2 = InfiniteColumns ? Rows : 1;
            int InternalVar_3 = InternalVar_1 + Rows <= Source.Count ? Rows : InternalVar_1 + Rows - Source.Count;
            return new InternalType_31(Source, InternalVar_1, InternalVar_2, InternalVar_3);
        }

        /// <summary>
        /// Wraps the provided <paramref name="source"/> in a <see cref="GridList{T}"/> with a dynamic number of rows and a fixed number of <paramref name="columns"/>
        /// </summary>
        /// <param name="source">The underlying list to wrap in a in a <see cref="GridList{T}"/></param>
        /// <param name="columns">The number of columns in the grid</param>
        /// <returns>A new grid wrapping <paramref name="source"/> with a fixed number of <paramref name="columns"/></returns>
        public static GridList<T> CreateWithColumns(IList<T> source, int columns)
        {
            return new GridList<T>(source, -1, math.max(1, columns));
        }

        /// <summary>
        /// Wraps the provided <paramref name="source"/> in a <see cref="GridList{T}"/> with a dynamic number of columns and a fixed number of <paramref name="rows"/>
        /// </summary>
        /// <param name="source">The underlying list to wrap in a in a <see cref="GridList{T}"/></param>
        /// <param name="rows">The number of rows in the grid</param>
        /// <returns>A new grid wrapping <paramref name="source"/> with a fixed number of <paramref name="rows"/></returns>
        public static GridList<T> CreateWithRows(IList<T> source, int rows)
        {
            return new GridList<T>(source, math.max(1, rows), -1);
        }

        private GridList(IList<T> InternalParameter_184, int InternalParameter_185 = 1, int InternalParameter_186 = 1)
        {
            this.Source = InternalParameter_184;
            this.InternalField_108 = math.clamp(InternalParameter_185, -1, int.MaxValue);
            this.InternalField_109 = math.clamp(InternalParameter_186, -1, int.MaxValue);
        }

        
        private static void InternalMethod_245(GridList<T> InternalParameter_187)
        {
            if (InternalParameter_187.InternalField_108 != 0 && InternalParameter_187.InternalField_109 != 0)
            {
                return;
            }

            throw new InvalidOperationException($"{typeof(GridList<T>).Name} has not been initialized. Use {nameof(GridList<T>)}.{nameof(CreateWithRows)} or {nameof(GridList<T>)}.{nameof(CreateWithRows)} to initialize.");
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="lhs">Left hand side</param>
        /// <param name="rhs">Right hand side</param>
        /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.Source == <paramref name="rhs"/>.Source &amp;&amp; <paramref name="lhs"/>.Rows == <paramref name="rhs"/>.Rows &amp;&amp; <paramref name="lhs"/>.Columns == <paramref name="rhs"/>.Columns</c></returns>
        public static bool operator ==(GridList<T> lhs, GridList<T> rhs)
        {
            return lhs.Source == rhs.Source && lhs.InternalField_108 == rhs.InternalField_108 && lhs.InternalField_109 == rhs.InternalField_109;
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="lhs">Left hand side</param>
        /// <param name="rhs">Right hand side</param>
        /// <returns><see langword="true"/> if <c><paramref name="lhs"/>.Source != <paramref name="rhs"/>.Source || <paramref name="lhs"/>.Rows != <paramref name="rhs"/>.Rows || <paramref name="lhs"/>.Columns != <paramref name="rhs"/>.Columns</c></returns>
        public static bool operator !=(GridList<T> lhs, GridList<T> rhs)
        {
            return lhs.Source != rhs.Source && lhs.InternalField_108 != rhs.InternalField_108 && lhs.InternalField_109 != rhs.InternalField_109;
        }

        /// <summary>
        /// The hashcode for this <see cref="GridList{T}"/>
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + InternalField_108.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + InternalField_109.GetHashCode();

            if (Source != null)
            {
                InternalVar_1 = (InternalVar_1 * 7) + Source.GetHashCode();
            }

            return InternalVar_1;
        }

        /// <summary>
        /// Equality compare
        /// </summary>
        /// <param name="other">The other <see cref="GridList{T}"/> to compare</param>
        /// <returns>
        /// <see langword="true"/> if <c>this == <paramref name="other"/></c>
        /// </returns>
        public override bool Equals(object other)
        {
            if (other is GridList<T> grid)
            {
                return this == grid;
            }

            return false;
        }

        /// <summary>
        /// Equality compare
        /// </summary>
        /// <param name="other">The other <see cref="GridList{T}"/> to compare</param>
        /// <returns>
        /// <see langword="true"/> if <c>this == <paramref name="other"/></c>
        /// </returns>
        public bool Equals(GridList<T> other)
        {
            return this == other;
        }
    }


    
    internal readonly ref struct InternalType_32
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public readonly int InternalProperty_59
        {
            get
            {
                if (InternalProperty_61)
                {
                    return InternalMethod_254(InternalField_120);
                }

                return math.min(InternalField_120, InternalField_118);
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public readonly int InternalProperty_60
        {
            get
            {
                if (InternalProperty_62)
                {
                    return InternalMethod_255(InternalField_120);
                }

                return math.min(InternalField_120, InternalField_119);
            }
        }

        public GridIndex InternalMethod_252(int InternalParameter_198)
        {
            return new GridIndex()
            {
                Row = InternalMethod_254(InternalParameter_198),
                Column = InternalMethod_255(InternalParameter_198),
            };
        }

        public int InternalMethod_253(GridIndex InternalParameter_199)
        {
            return InternalProperty_61 ? (InternalParameter_199.Row * InternalField_119) + InternalParameter_199.Column : (InternalParameter_199.Column * InternalField_118) + InternalParameter_199.Row;
        }

        public readonly int InternalMethod_254(int InternalParameter_200)
        {
            return InternalProperty_61 ? InternalParameter_200 / InternalField_119 : InternalParameter_200 % InternalField_118;
        }

        public readonly int InternalMethod_255(int InternalParameter_201)
        {
            return InternalProperty_62 ? InternalParameter_201 / InternalField_118 : InternalParameter_201 % InternalField_119;
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public readonly bool InternalProperty_61 => InternalField_118 < 0;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public readonly bool InternalProperty_62 => InternalField_119 < 0;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private readonly int InternalField_118;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private readonly int InternalField_119;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private readonly int InternalField_120;

        public static InternalType_32 InternalMethod_258(int InternalParameter_202, int InternalParameter_203)
        {
            return new InternalType_32(InternalParameter_202, InternalParameter_206: InternalParameter_203);
        }

        private InternalType_32(int InternalParameter_204, int InternalParameter_205 = -1, int InternalParameter_206 = -1)
        {
            this.InternalField_120 = InternalParameter_204;
            this.InternalField_118 = math.clamp(InternalParameter_205, -1, int.MaxValue);
            this.InternalField_119 = math.clamp(InternalParameter_206, -1, int.MaxValue);
        }
    }
}

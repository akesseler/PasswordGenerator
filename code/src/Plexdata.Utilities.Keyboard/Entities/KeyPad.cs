/*
 * MIT License
 * 
 * Copyright (c) 2022 plexdata.de
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using Plexdata.Utilities.Keyboard.Defines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plexdata.Utilities.Keyboard.Entities
{
    /// <summary>
    /// A class representing the physical position of all assigned key maps 
    /// on a keyboard.
    /// </summary>
    public class KeyPad
    {
        #region Private Fields

        private readonly List<List<KeyMap>> values;

        #endregion

        #region Construction

        private KeyPad()
            : base()
        {
            this.values = Enumerable.Empty<List<KeyMap>>().ToList();
        }

        private KeyPad(IEnumerable<IEnumerable<KeyMap>> values)
            : this()
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            this.values = new List<List<KeyMap>>();

            foreach (IEnumerable<KeyMap> value in values)
            {
                if (value == null)
                {
                    continue;
                }

                this.values.Add(value.Where(x => x != null).ToList());
            }
        }

        #endregion

        #region Public Properties

        public IEnumerable<KeyMap> this[Int32 row]
        {
            get
            {
                return this.GetColumns(row);
            }
        }

        public KeyMap this[Int32 row, Int32 column]
        {
            get
            {
                return this.GetValue(row, column);
            }
        }

        public Boolean IsNumPad
        {
            get
            {
                // Virtual-Key Codes: https://docs.microsoft.com/de-de/windows/win32/inputdev/virtual-key-codes
                return this.values.All(x => x.Any(y => y.VirtualKey >= 0x60 && y.VirtualKey <= 0x6F));
            }
        }

        #endregion

        #region Public Methods

        public static KeyPad Create(IEnumerable<IEnumerable<KeyMap>> values)
        {
            return new KeyPad(values);
        }

        public Int32 GetRowCount()
        {
            return this.values.Count;
        }

        public Int32 GetColumnCount(Int32 row)
        {
            if (row >= 0 && row < this.values.Count)
            {
                return this.values[row].Count;
            }

            return 0;
        }

        public IEnumerable<IEnumerable<KeyMap>> GetRows()
        {
            return this.values;
        }

        public IEnumerable<KeyMap> GetColumns(Int32 row)
        {

            if (row < 0 || row >= this.values.Count)
            {
                // Consider of throwing an exception instead.
                return null;
            }

            return this.values[row];
        }

        public KeyMap GetValue(Int32 row, Int32 column)
        {
            if (row >= 0 && row < this.values.Count)
            {
                if (column >= 0 && column < this.values[row].Count)
                {
                    return this.values[row][column];
                }
            }

            // Do not throw an exception!
            return null;
        }

        public Char GetValue(KeyType type, Int32 row, Int32 column)
        {
            KeyMap affected = this.GetValue(row, column);

            if (affected == null)
            {
                return KeyMap.Invalid;
            }

            switch (type)
            {
                case KeyType.Lower:
                    return affected.LowerKey;
                case KeyType.Upper:
                    return affected.UpperKey;
                case KeyType.Third:
                    return affected.ThirdKey;
                default:
                    return KeyMap.Invalid;
            }
        }

        public Char[,] ToMatrix(KeyType type, out Int32 rows, out Int32 columns)
        {
            rows = this.GetRowCount();
            columns = 0;

            for (Int32 row = 0; row < rows; row++)
            {
                Int32 current = this.GetColumnCount(row);

                if (columns < current)
                {
                    columns = current;
                }
            }

            Char[,] result = new Char[rows, columns];

            for (Int32 row = 0; row < rows; row++)
            {
                for (Int32 column = 0; column < columns; column++)
                {
                    result[row, column] = this.GetValue(type, row, column);
                }
            }

            return result;
        }

        public override String ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append($"Rows: {this.values.Count}, ");

            for (Int32 index = 0; index < this.values.Count; index++)
            {
                List<KeyMap> value = this.values[index];

                builder.Append($"Column[{index}]: {this.values[index].Count}, ");
            }

            return builder.ToString().TrimEnd().TrimEnd(',');
        }

        #endregion
    }
}

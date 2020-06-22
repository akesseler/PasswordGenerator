/*
 * MIT License
 * 
 * Copyright (c) 2020 plexdata.de
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
using Plexdata.Utilities.Keyboard.Entities;
using Plexdata.Utilities.Keyboard.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Plexdata.Utilities.Keyboard.Builders
{
    public class QwertyBuilder : IQwertyBuilder
    {
        public QwertyBuilder()
            : base()
        {
        }

        public IEnumerable<String> Build(KeyPad source)
        {
            return Build(source, KeyType.Lower);
        }

        public IEnumerable<String> Build(KeyPad source, KeyType type)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            Char[,] matrix = source.ToMatrix(type, out Int32 rows, out Int32 cols);

            List<String> results = new List<String>();
            String current = String.Empty;

            // NOTE: Some of the resulting strings may contain duplicates in case of 
            //       processing the data of the NUM pad (e.g. double zeros). This is 
            //       actually not perfect but it doesn't really matter.

            current = this.GetHorizontalFirstToLast(matrix, rows, cols);

            results.Add(current);
            results.Add(this.Reverse(current));

            current = this.Clear(current);

            results.Add(current);
            results.Add(this.Reverse(current));

            current = this.GetHorizontalLastToFirst(matrix, rows, cols);

            results.Add(current);
            results.Add(this.Reverse(current));

            current = this.Clear(current);

            results.Add(current);
            results.Add(this.Reverse(current));

            current = this.GetOrthogonalLeftToRight(matrix, rows, cols);

            results.Add(current);
            results.Add(this.Reverse(current));

            current = this.Clear(current);

            results.Add(current);
            results.Add(this.Reverse(current));

            current = this.GetOrthogonalRightToLeft(matrix, rows, cols);

            results.Add(current);
            results.Add(this.Reverse(current));

            current = this.Clear(current);

            results.Add(current);
            results.Add(this.Reverse(current));

            if (!source.IsNumPad)
            {
                current = this.GetAlphabet(type);

                results.Add(current);
                results.Add(this.Reverse(current));
            }

            results = results.Where(x => !String.IsNullOrWhiteSpace(x)).Distinct().ToList();

            // TODO: this.DumpResults(results);

            return results;
        }

        private String GetHorizontalFirstToLast(Char[,] matrix, Int32 rows, Int32 cols)
        {
            StringBuilder result = new StringBuilder(rows * cols);

            for (Int32 row = 0; row < rows; row++)
            {
                for (Int32 col = 0; col < cols; col++)
                {
                    this.Assign(result, matrix[row, col]);
                }
            }

            return result.ToString();
        }

        private String GetHorizontalLastToFirst(Char[,] matrix, Int32 rows, Int32 cols)
        {
            StringBuilder result = new StringBuilder(rows * cols);

            for (Int32 row = rows - 1; row >= 0; row--)
            {
                for (Int32 col = 0; col < cols; col++)
                {
                    this.Assign(result, matrix[row, col]);
                }
            }

            return result.ToString();
        }

        private String GetOrthogonalLeftToRight(Char[,] matrix, Int32 rows, Int32 cols)
        {
            StringBuilder result = new StringBuilder(rows * cols);

            for (Int32 col = 0; col < cols; col++)
            {
                for (Int32 row = 0; row < rows; row++)
                {
                    this.Assign(result, matrix[row, col]);
                }
            }

            return result.ToString();
        }

        private String GetOrthogonalRightToLeft(Char[,] matrix, Int32 rows, Int32 cols)
        {
            StringBuilder result = new StringBuilder(rows * cols);

            for (Int32 col = cols - 1; col >= 0; col--)
            {
                for (Int32 row = 0; row < rows; row++)
                {
                    this.Assign(result, matrix[row, col]);
                }
            }

            return result.ToString();
        }

        private String Clear(String source)
        {
            StringBuilder result = new StringBuilder(source.Length);

            foreach (Char current in source)
            {
                if (Char.IsLetterOrDigit(current))
                {
                    result.Append(current);
                }
            }

            return result.ToString();
        }

        private String Reverse(String source)
        {
            Char[] array = source.ToCharArray();

            Array.Reverse(array);

            return new String(array);
        }

        private void Assign(StringBuilder builder, Char affected)
        {
            if (!Char.IsControl(affected))
            {
                builder.Append(affected);
            }
        }

        private String GetAlphabet(KeyType type)
        {
            const String alphabet = "abcdefghijklmnopqrstuvwxyz";

            if (type == KeyType.Lower)
            {
                return alphabet;
            }

            if (type == KeyType.Upper)
            {
                return alphabet.ToUpper();
            }

            return String.Empty;
        }

        [Conditional("DEBUG")]
        private void DumpResults(List<String> results)
        {
            foreach (String result in results)
            {
                Debug.WriteLine(result);
            }
        }
    }
}

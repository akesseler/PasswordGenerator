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

using Plexdata.Utilities.Keyboard.Entities;
using Plexdata.Utilities.Keyboard.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Plexdata.Utilities.Keyboard.Builders
{
    public class NumericBuilder : INumericBuilder
    {
        #region Construction

        public NumericBuilder()
            : base()
        {
        }

        #endregion

        #region Public Methods

        public KeyPad Build(IEnumerable<KeyMap> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            List<KeyMap> keys = source.Where(x => !this.IsExcluded(x)).ToList();

            List<List<KeyMap>> matrix = new List<List<KeyMap>>
            {
                new List<KeyMap>(),
                new List<KeyMap>(),
                new List<KeyMap>(),
                new List<KeyMap>(),
                new List<KeyMap>()
            };

            // Might be wrong on some keyboards, 
            // but most of them use that order:
            // N / * -
            // 7 8 9 +
            // 4 5 6 +
            // 1 2 3 E
            // 0 0 . E
            // Meaning of shown keys:
            // N => 0x90: VK_NUMLOCK
            // / => 0x6F: VK_DIVIDE
            // * => 0x6A: VK_MULTIPLY
            // - => 0x6D: VK_SUBTRACT
            // + => 0x6B: VK_ADD
            // . => 0x6E: VK_DECIMAL
            // E => 0x0D: VK_RETURN
            // 0 => 0x60: VK_NUMPAD0
            // 1 => 0x61: VK_NUMPAD1
            // 2 => 0x62: VK_NUMPAD2
            // 3 => 0x63: VK_NUMPAD3
            // 4 => 0x64: VK_NUMPAD4
            // 5 => 0x65: VK_NUMPAD5
            // 6 => 0x66: VK_NUMPAD6
            // 7 => 0x67: VK_NUMPAD7
            // 8 => 0x68: VK_NUMPAD8
            // 9 => 0x69: VK_NUMPAD9

            // Unfortunately, sorting the keys of the numeric pad does 
            // not bring them into a processible order. Therefore, this 
            // hard coded approach is used instead.

            matrix[0].Add(keys.First(x => x.VirtualKey == 0x6F));
            matrix[0].Add(keys.First(x => x.VirtualKey == 0x6A));
            matrix[0].Add(keys.First(x => x.VirtualKey == 0x6D));

            matrix[1].Add(keys.First(x => x.VirtualKey == 0x67));
            matrix[1].Add(keys.First(x => x.VirtualKey == 0x68));
            matrix[1].Add(keys.First(x => x.VirtualKey == 0x69));
            matrix[1].Add(keys.First(x => x.VirtualKey == 0x6B));

            matrix[2].Add(keys.First(x => x.VirtualKey == 0x64));
            matrix[2].Add(keys.First(x => x.VirtualKey == 0x65));
            matrix[2].Add(keys.First(x => x.VirtualKey == 0x66));
            matrix[2].Add(keys.First(x => x.VirtualKey == 0x6B));

            matrix[3].Add(keys.First(x => x.VirtualKey == 0x61));
            matrix[3].Add(keys.First(x => x.VirtualKey == 0x62));
            matrix[3].Add(keys.First(x => x.VirtualKey == 0x63));

            matrix[4].Add(keys.First(x => x.VirtualKey == 0x60));
            matrix[4].Add(keys.First(x => x.VirtualKey == 0x60));
            matrix[4].Add(keys.First(x => x.VirtualKey == 0x6E));

            KeyPad results = KeyPad.Create(matrix);

            // TODO: this.DumpResults(results);

            return results;
        }

        #endregion

        #region Private Methods

        private Boolean IsExcluded(KeyMap key)
        {
            // Virtual-Key Codes: https://docs.microsoft.com/de-de/windows/win32/inputdev/virtual-key-codes

            return
                key.IsVisible == false ||
                key.VirtualKey < 0x60 ||
                key.VirtualKey > 0x6F;
        }

        [Conditional("DEBUG")]
        private void DumpResults(KeyPad results)
        {
            for (Int32 outer = 0; outer < results.GetRowCount(); outer++)
            {
                Debug.Write($"{outer}: ");

                for (Int32 inner = 0; inner < results.GetColumnCount(outer); inner++)
                {
                    Debug.Write($"{results[outer, inner].LowerKey} ");
                }

                Debug.WriteLine(String.Empty);
            }
        }

        #endregion
    }
}

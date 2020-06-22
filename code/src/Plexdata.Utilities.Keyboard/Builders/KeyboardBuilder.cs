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
    public class KeyboardBuilder : IKeyboardBuilder
    {
        #region Construction

        public KeyboardBuilder()
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

            keys.Sort(KeyMap.CompareByScanCode);

            List<List<KeyMap>> matrix = new List<List<KeyMap>>
            {
                new List<KeyMap>(),
                new List<KeyMap>(),
                new List<KeyMap>(),
                new List<KeyMap>()
            };

            Int32 index = 0;

            foreach (KeyMap key in keys)
            {
                // As seen by examples, it seems to be that each keyboard 
                // uses 'q' and 'a' and ('y' or 'z') as first key in their 
                // related rows.

                if (key.LowerKey == 'q')
                {
                    index = 1;
                }
                else if (key.LowerKey == 'a')
                {
                    index = 2;
                }
                else if (index != 1 && (key.LowerKey == 'y' || key.LowerKey == 'z'))
                {
                    index = 3;
                }

                matrix[index].Add(key);
            }

            KeyPad results = KeyPad.Create(matrix);

            // TODO: this.DumpResults(results);

            return results;
        }

        #endregion

        #region Private Methods

        private Boolean IsExcluded(KeyMap key)
        {
            // NOTE: The VK_OEM_102=0xE2 (the "<" on German keyboard) is actually at a wrong position, because of 
            //       its scan code is "greater". The same applies to VK_OEM_5=0xDC (the "^" on German keyboard) and 
            //       to other keys as well. Thus, filter out those problematic keys. Furthermore, exclude all keys 
            //       that cannot be shown, the "Space" key and explicitly exclude all keys of the number pad.
            // Virtual-Key Codes: https://docs.microsoft.com/de-de/windows/win32/inputdev/virtual-key-codes

            return
                key.IsVisible == false ||
                key.VirtualKey == 0x20 ||
                key.VirtualKey == 0xDD ||
                key.VirtualKey == 0xDC ||
                key.VirtualKey == 0xE2 ||
                (key.VirtualKey >= 0x60 && key.VirtualKey <= 0x6F);
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

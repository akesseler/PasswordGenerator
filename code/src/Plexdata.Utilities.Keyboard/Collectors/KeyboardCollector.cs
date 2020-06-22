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

namespace Plexdata.Utilities.Keyboard.Collectors
{
    public class KeyboardCollector : IKeyboardCollector
    {
        #region Construction

        public KeyboardCollector()
            : base()
        {
        }

        #endregion

        #region Public Properties

        // Lowest possible virtual key.
        public UInt32 MinVKey
        {
            get
            {
                return 0x01;
            }
        }

        // Highest possible virtual key.
        public UInt32 MaxVKey
        {
            get
            {
                return 0xFE;
            }
        }

        #endregion

        #region Public Methods

        public IEnumerable<KeyMap> Collect()
        {
            return this.Collect(false);
        }

        public IEnumerable<KeyMap> Collect(Boolean complete)
        {
            return this.Collect(this.MinVKey, this.MaxVKey, complete);
        }

        public IEnumerable<KeyMap> Collect(Int32 lowerVKey, Int32 upperVKey)
        {
            return this.Collect(lowerVKey, upperVKey, false);
        }

        public IEnumerable<KeyMap> Collect(Int32 lowerVKey, Int32 upperVKey, Boolean complete)
        {
            return this.Collect(Convert.ToUInt32(lowerVKey), Convert.ToUInt32(upperVKey), complete);
        }

        public IEnumerable<KeyMap> Collect(UInt32 lowerVKey, UInt32 upperVKey)
        {
            return this.Collect(lowerVKey, upperVKey, false);
        }

        public IEnumerable<KeyMap> Collect(UInt32 lowerVKey, UInt32 upperVKey, Boolean complete)
        {
            if (lowerVKey < this.MinVKey)
            {
                lowerVKey = this.MinVKey;
            }

            if (upperVKey > this.MaxVKey)
            {
                upperVKey = this.MaxVKey;
            }

            List<KeyMap> results = new List<KeyMap>();

            for (UInt32 vKey = lowerVKey; vKey <= upperVKey; vKey++)
            {
                KeyMap current = new KeyMap(vKey);

                if (!complete && !current.IsVisible)
                {
                    continue;
                }

                results.Add(new KeyMap(vKey));
            }

            // TODO: this.DumpResults(results);

            return results;
        }

        #endregion

        #region  Private Methods

        [Conditional("DEBUG")]
        private void DumpResults(IEnumerable<KeyMap> results)
        {
            foreach (KeyMap current in results)
            {
                Debug.WriteLine(current);
            }
        }

        #endregion
    }
}

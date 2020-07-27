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

using System;
using System.Linq;

namespace Plexdata.PasswordGenerator.Extensions
{
    public static class StringExtension
    {
        public static String ClearLineEndings(this String source)
        {
            String result = source ?? String.Empty;

            foreach (String current in Environment.NewLine.ToCharArray().Select(x => x.ToString()))
            {
                result = result.Replace(current, String.Empty);
            }

            return result;
        }

        public static String Repeat(this String source, Int32 count, String separator = null)
        {
            if (source == null)
            {
                return String.Empty;
            }

            if (count < 0)
            {
                count = 0;
            }

            if (separator == null)
            {
                separator = String.Empty;
            }

            return String.Join(separator, Enumerable.Repeat(source, count));
        }
    }
}

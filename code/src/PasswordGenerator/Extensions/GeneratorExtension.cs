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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plexdata.PasswordGenerator.Extensions
{
    public static class GeneratorExtension
    {
        public static String Shuffle(this String source, Random random)
        {
            if (String.IsNullOrWhiteSpace(source))
            {
                return String.Empty;
            }

            if (random == null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            Char[] array = source.ToCharArray();

            Int32 next = array.Length;

            while (next > 1)
            {
                next--;

                Int32 swap = random.Next(next + 1);

                Char last = array[swap];

                array[swap] = array[next];
                array[next] = last;
            }

            return new String(array);
        }

        public static String Mingle(this String source, Random random, Int32 length)
        {
            if (String.IsNullOrWhiteSpace(source))
            {
                return String.Empty;
            }

            if (random == null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            if (length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            Char[] array = new Char[length];

            for (Int32 index = 0; index < length; index++)
            {
                array[index] = source[random.Next(source.Length)];
            }

            return new String(array);
        }

        public static String Raffle(this IEnumerable<String> sources, Random random)
        {
            if (sources == null || !sources.Any())
            {
                return String.Empty;
            }

            if (random == null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            StringBuilder builder = new StringBuilder(256);

            foreach (String source in sources)
            {
                builder.Append(source[random.Next(source.Length)]);
            }

            return builder.ToString();
        }
    }
}

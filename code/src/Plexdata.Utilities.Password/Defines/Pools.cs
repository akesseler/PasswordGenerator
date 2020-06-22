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
using System.ComponentModel;

namespace Plexdata.Utilities.Password.Defines
{
    // TODO: Finalize documentation.
    [Flags]
    public enum Pools
    {
        [Description("This pool do not contain anything.")]
        Nothing = 0x0000,

        [Description("This pool contains all lowercase letters.")]
        Lowers = 0x0001,

        [Description("This pool contains all capital letters.")]
        Uppers = 0x0002,

        [Description("This pool contains all numeric digits.")]
        Digits = 0x0004,

        [Description("This pool contains symbols and typical special characters.")]
        Extras = 0x0008,

        [Description("This pool contains other special Latin characters.")]
        Latins = 0x0010,

        [Description("This pool contains lower case vowel characters.")]
        Vowels = 0x0020,

        [Description("This pool contains lower case consonant characters.")]
        Consonants = 0x0040,

        [Description("This pool contains symbol characters, such as @, $, %, etc.")]
        Symbols = 0x0080,

        [Description("This pool contains mathematical operator characters.")]
        Operators = 0x0100,

        [Description("This pool contains punctuation characters.")]
        Punctuations = 0x0200,

        [Description("This pool contains other special characters.")]
        Specials = 0x0400,

        [Description("This pool contains bracket characters.")]
        Brackets = 0x0800,

        [Description("This pool contains the underscore character as space replacement.")]
        Spaces = 0x1000,

        [Description("This pool contains lowercase and capital letters as well as numeric digits.")]
        Common = Pools.Lowers | Pools.Uppers | Pools.Digits,

        [Description("This pool contains lowercase and capital letters, numeric digits as well as symbols and typical special characters.")]
        United = Pools.Common | Pools.Extras,

        [Description("This pool contains all supported characters.")]
        Entire = Pools.United | Pools.Latins,
    }
}

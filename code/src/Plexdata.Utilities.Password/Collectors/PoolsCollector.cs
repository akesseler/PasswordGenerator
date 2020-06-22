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

using Plexdata.Utilities.Password.Defines;
using Plexdata.Utilities.Password.Interfaces;
using System;
using System.Text;

namespace Plexdata.Utilities.Password.Collectors
{
    // TODO: Finalize documentation.
    public class PoolsCollector : IPoolsCollector
    {
        #region Construction

        public PoolsCollector()
        {
        }

        #endregion

        #region Public Properties

        public String Lowers
        {
            get
            {
                return "abcdefghijklmnopqrstuvwxyz";
            }
        }

        public String Uppers
        {
            get
            {
                return "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }
        }

        public String Digits
        {
            get
            {
                return "0123456789";
            }
        }

        public String Extras
        {
            get
            {
                return "@!\"$%&=?/<({[]})>\\*+~'#|;,:._-";
            }
        }

        public String Latins
        {
            get
            {
                return " ^°¡¿¢€£¥§µ´`º¹²³ª¼½¾«»¯ÀÁÂÃÄÅÆḂÇĊḊÐÈÉÊËḞĠÌÍÎÏṀÑÒÓÔÕÖŐØŒṖŠṠṪÙÚÛÜŰẀẂŴẄỲŶŸÝŽÞßàáâãäåæḃçċḋðèéêëḟġìíîïṁñòóôõöőøœṗšṡṫùúûüűẁẃŵẅỳŷÿýžþ";
            }
        }

        public String Vowels
        {
            get
            {
                return "aeiou";
            }
        }

        public String Consonants
        {
            get
            {
                return "bcdfghjklmnpqrstvwxyz";
            }
        }

        public String Symbols
        {
            get
            {
                return "@#$%&";
            }
        }

        public String Operators
        {
            get
            {
                return "+-*/=~";
            }
        }

        public String Punctuations
        {
            get
            {
                return ",.;:!?";
            }
        }

        public String Specials
        {
            get
            {
                return "^`|\"'\\";
            }
        }

        public String Brackets
        {
            get
            {
                return "<([{}])>";
            }
        }

        public String Spaces
        {
            get
            {
                return "_";
            }
        }

        #endregion

        #region Public Methods

        public String Collect()
        {
            return this.Collect(Pools.Entire);
        }

        public String Collect(Pools affected)
        {
            StringBuilder result = new StringBuilder(256);

            if (affected.HasFlag(Pools.Lowers)) { result.Append(this.Lowers); }

            if (affected.HasFlag(Pools.Uppers)) { result.Append(this.Uppers); }

            if (affected.HasFlag(Pools.Digits)) { result.Append(this.Digits); }

            if (affected.HasFlag(Pools.Extras)) { result.Append(this.Extras); }

            if (affected.HasFlag(Pools.Latins)) { result.Append(this.Latins); }

            if (affected.HasFlag(Pools.Vowels)) { result.Append(this.Vowels); }

            if (affected.HasFlag(Pools.Consonants)) { result.Append(this.Consonants); }

            if (affected.HasFlag(Pools.Symbols)) { result.Append(this.Symbols); }

            if (affected.HasFlag(Pools.Operators)) { result.Append(this.Operators); }

            if (affected.HasFlag(Pools.Punctuations)) { result.Append(this.Punctuations); }

            if (affected.HasFlag(Pools.Specials)) { result.Append(this.Specials); }

            if (affected.HasFlag(Pools.Brackets)) { result.Append(this.Brackets); }

            if (affected.HasFlag(Pools.Spaces)) { result.Append(this.Spaces); }

            return result.ToString();
        }

        #endregion
    }
}

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

namespace Plexdata.Utilities.Password.Defines
{
    /// <summary>
    /// An enumeration representing all supported stages of password 
    /// strength.
    /// </summary>
    /// <remarks>
    /// This enumeration represents all supported stages (five at the 
    /// moment) of password strength. The effective range values may 
    /// vary depending on currently selected mode.
    /// </remarks>
    public enum Strength
    {
        /// <summary>
        /// The entropy unknown yet.
        /// </summary>
        /// <remarks>
        /// The entropy range has not used set yet.
        /// </remarks>
        Unknown,

        /// <summary>
        /// Range indicator for a very weak password entropy.
        /// </summary>
        /// <remarks>
        /// This entropy range is very weak but it might keep out family 
        /// members.
        /// </remarks>
        VeryWeak,

        /// <summary>
        /// Range indicator for a weak password entropy.
        /// </summary>
        /// <remarks>
        /// This entropy range is weak but it should keep out most people, 
        /// often good for desktop login passwords.
        /// </remarks>
        Weak,

        /// <summary>
        /// Range indicator for a reasonable password entropy.
        /// </summary>
        /// <remarks>
        /// This entropy range is reasonable and it fairly secures passwords 
        /// for network and company passwords.
        /// </remarks>
        Reasonable,

        /// <summary>
        /// Range indicator for a strong password entropy.
        /// </summary>
        /// <remarks>
        /// This entropy range is strong and could be good for guarding 
        /// financial information.
        /// </remarks>
        Strong,

        /// <summary>
        /// Range indicator for a very strong password entropy.
        /// </summary>
        /// <remarks>
        /// This entropy range is very strong but it is often considered 
        /// as overkill.
        /// </remarks>
        VeryStrong
    }
}

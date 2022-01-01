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

using Plexdata.Utilities.Password.Calculators;
using Plexdata.Utilities.Password.Interfaces;
using System;

namespace Plexdata.Utilities.Password.Factories
{
    // TODO: Finalize documentation.
    public static class CalculatorFactory
    {
        #region Public Methods

        public static TCalculator Create<TCalculator>()
        {
            if (typeof(TCalculator) == typeof(IEntropyCalculator))
            {
                return (TCalculator)(IEntropyCalculator)new EntropyCalculator();
            }

            if (typeof(TCalculator) == typeof(IStrengthCalculator))
            {
                return (TCalculator)(IStrengthCalculator)new StrengthCalculator();
            }

            if (typeof(TCalculator) == typeof(ISecurityCalculator))
            {
                return (TCalculator)(ISecurityCalculator)new SecurityCalculator();
            }

            throw new NotSupportedException();
        }

        #endregion
    }
}

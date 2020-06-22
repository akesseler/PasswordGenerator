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

namespace Plexdata.Utilities.Password.Tests.Collectors
{

    public static class PoolsTestHelper
    {
        // Putting those strings in a separate class became necessary, 
        // because of otherwise affected tests will not run.
        public const String ExpectedLowers = "abcdefghijklmnopqrstuvwxyz";
        public const String ExpectedUppers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const String ExpectedDigits = "0123456789";
        public const String ExpectedExtras = "@!\"$%&=?/<({[]})>\\*+~'#|;,:._-";
        public const String ExpectedLatins = " ^°¡¿¢€£¥§µ´`º¹²³ª¼½¾«»¯ÀÁÂÃÄÅÆḂÇĊḊÐÈÉÊËḞĠÌÍÎÏṀÑÒÓÔÕÖŐØŒṖŠṠṪÙÚÛÜŰẀẂŴẄỲŶŸÝŽÞßàáâãäåæḃçċḋðèéêëḟġìíîïṁñòóôõöőøœṗšṡṫùúûüűẁẃŵẅỳŷÿýžþ";
        public const String ExpectedCommon = PoolsTestHelper.ExpectedLowers + PoolsTestHelper.ExpectedUppers + PoolsTestHelper.ExpectedDigits;
        public const String ExpectedUnited = PoolsTestHelper.ExpectedLowers + PoolsTestHelper.ExpectedUppers + PoolsTestHelper.ExpectedDigits + PoolsTestHelper.ExpectedExtras;
        public const String ExpectedEntire = PoolsTestHelper.ExpectedLowers + PoolsTestHelper.ExpectedUppers + PoolsTestHelper.ExpectedDigits + PoolsTestHelper.ExpectedExtras + PoolsTestHelper.ExpectedLatins;
    }
}

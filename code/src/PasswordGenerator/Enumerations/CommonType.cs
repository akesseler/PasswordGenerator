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

using Plexdata.PasswordGenerator.Attributes;

namespace Plexdata.PasswordGenerator.Enumerations
{
    public enum CommonType
    {
        [Annotation("Nothing", "Please choose one of the common password types.", CommonType.Nothing)]
        Nothing,

        [Annotation("Internet Password 1", "Internet password type 1 with 8 characters (upper and lower cases as well as digits).", CommonType.InternetPassword1)]
        InternetPassword1,

        [Annotation("Internet Password 2", "Internet passwords type 2 with 10 characters (upper and lower cases, digits as well as special characters).", CommonType.InternetPassword2)]
        InternetPassword2,

        [Annotation("Internet Password 3", "Internet passwords type 3 with 14 characters (upper and lower cases, digits as well as special characters).", CommonType.InternetPassword3)]
        InternetPassword3,

        [Annotation("Internet Password X", "Internet passwords with variable character length (upper and lower cases, digits as well as special characters).", CommonType.InternetPasswordX)]
        InternetPasswordX,

        [Annotation("Password Manager 1", "Password manager type 1 with 16 characters.", CommonType.PasswordManager1)]
        PasswordManager1,

        [Annotation("Password Manager 2", "Password manager type 2 with 32 characters.", CommonType.PasswordManager2)]
        PasswordManager2,

        [Annotation("Password Manager 3", "Password manager type 3 with 64 characters.", CommonType.PasswordManager3)]
        PasswordManager3,

        [Annotation("WEP-Key (64 bit)", "WEP-Key with 10 hexadecimal digits (based on a password phrase containing 5 characters).", CommonType.WepKey64Bit)]
        WepKey64Bit,

        [Annotation("WEP-Key (128 bit)", "WEP-Key with 26 hexadecimal digits (based on a password phrase containing 13 characters).", CommonType.WepKey128Bit)]
        WepKey128Bit,

        [Annotation("WEP-Key (152 bit)", "WEP-Key with 32 hexadecimal digits (based on a password phrase containing 16 characters).", CommonType.WepKey152Bit)]
        WepKey152Bit,

        [Annotation("WEP-Key (256 bit)", "WEP-Key with 58 hexadecimal digits (based on a password phrase containing 29 characters).", CommonType.WepKey256Bit)]
        WepKey256Bit,

        [Annotation("WEP-Key (Custom)", "WEP-Key with hexadecimal digits (based on a custom password phrase in a range of 1 up to 29 characters).", CommonType.WepKeyCustom)]
        WepKeyCustom,

        [Annotation("WPA-Key", "Not supported.", CommonType.WpaKey, false)]
        WpaKey, // No rules found

        [Annotation("WPA-2 Key", "Passwords with a length of 8 up to 63 characters.", CommonType.Wpa2Key)]
        Wpa2Key,
    }
}

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
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace Plexdata.PasswordGenerator.Settings
{
    public static class SettingsSerializer
    {
        public static Boolean Load<TInstance>(String filename, out TInstance instance) where TInstance : class, new()
        {
            instance = null;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TInstance));

                using (TextReader reader = new StreamReader(filename))
                {
                    instance = (TInstance)serializer.Deserialize(reader);

                    return true;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return false;
            }
        }

        public static Boolean Save<TInstance>(String filename, TInstance instance) where TInstance : class, new()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TInstance));

                using (TextWriter writer = new StreamWriter(filename))
                {
                    serializer.Serialize(writer, instance);
                }

                return true;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return false;
            }
        }
    }
}

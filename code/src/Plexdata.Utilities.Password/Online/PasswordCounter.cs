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

using Plexdata.Utilities.Password.Interfaces;
using System;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Plexdata.Utilities.Password.Online
{
    // TODO: Finalize documentation.
    public class PasswordCounter : IPasswordCounter
    {
        #region Construction

        public PasswordCounter()
            : base()
        {
        }

        #endregion

        #region Public Methods

        public async Task<Int64> GetPwnCountAsync(String password, CancellationToken token)
        {
            try
            {
                this.ValidateParameter(password, nameof(password));

                (String Prefix, String Suffix) source = this.CreateHash(password);

                String content = await this.ReadContent(source.Prefix, token);

                String affected = this.FindBySuffix(content, source.Suffix);

                if (String.IsNullOrEmpty(affected))
                {
                    return 0;
                }

                return this.ExtractCount(affected);
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
                throw;
            }
        }

        #endregion

        #region Private Methods

        private (String Prefix, String Suffix) CreateHash(String password)
        {
            String value = String.Empty;

            using (SHA1Managed algorithm = new SHA1Managed())
            {
                Byte[] items = algorithm.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder(2 * items.Length);

                foreach (Byte item in items)
                {
                    builder.Append(item.ToString("X2"));
                }

                value = builder.ToString();
            }

            (String Prefix, String Suffix) result;

            result.Prefix = value.Substring(0, 5);
            result.Suffix = value.Substring(5);

            return result;
        }

        private async Task<String> ReadContent(String prefix, CancellationToken token)
        {
            Uri uri = new Uri($"https://api.pwnedpasswords.com/range/{prefix}");

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(uri, token))
                {
                    response.EnsureSuccessStatusCode();

                    return await response.Content.ReadAsStringAsync();
                }
            }
        }

        private String FindBySuffix(String content, String suffix)
        {
            this.ValidateParameter(content, nameof(content));

            return content
                .Split(new String[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .FirstOrDefault(x => x.StartsWith(suffix));
        }

        private Int64 ExtractCount(String affected)
        {
            this.ValidateParameter(affected, nameof(affected));

            String[] items = affected.Split(new Char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            if (items.Length < 2)
            {
                throw new InvalidOperationException($"Unable to split value of \"{affected}\" by colon.");
            }

            return Int64.Parse(items[1]);
        }

        private void ValidateParameter(String value, String label)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"Value of \"{label}\" must not be null or empty.", label);
            }
        }

        #endregion
    }
}

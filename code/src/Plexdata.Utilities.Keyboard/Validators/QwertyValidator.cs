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

using Plexdata.Utilities.Keyboard.Defines;
using Plexdata.Utilities.Keyboard.Entities;
using Plexdata.Utilities.Keyboard.Exceptions;
using Plexdata.Utilities.Keyboard.Factories;
using Plexdata.Utilities.Keyboard.Interfaces;
using System;
using System.Collections.Generic;

namespace Plexdata.Utilities.Keyboard.Validators
{
    public class QwertyValidator : IQwertyValidator
    {
        #region Private Fields

        private readonly IKeyboardCollector keyboardCollector;
        private readonly IKeyboardBuilder keyboardBuilder;
        private readonly INumericBuilder numericBuilder;
        private readonly IQwertyBuilder qwertyBuilder;

        #endregion

        #region Construction

        public QwertyValidator()
            : base()
        {
            this.keyboardCollector = KeyboardFactory.Create<IKeyboardCollector>();
            this.keyboardBuilder = KeyboardFactory.Create<IKeyboardBuilder>();
            this.numericBuilder = KeyboardFactory.Create<INumericBuilder>();
            this.qwertyBuilder = KeyboardFactory.Create<IQwertyBuilder>();
        }

        #endregion

        #region Public Methods

        public Boolean IsLowerQwerty(String password)
        {
            return this.IsQwerty(password, KeyType.Lower);
        }

        public Boolean IsUpperQwerty(String password)
        {
            return this.IsQwerty(password, KeyType.Upper);
        }

        public Boolean IsThirdQwerty(String password)
        {
            return this.IsQwerty(password, KeyType.Third);
        }

        public Boolean IsQwerty(String password, KeyType type)
        {
            try
            {
                this.Validate(password, type);
                return false;
            }
            catch (QwertyException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
                return true;
            }
        }

        public void Validate(String password, KeyType type)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            if (type == KeyType.Empty)
            {
                throw new ArgumentOutOfRangeException(nameof(type));
            }

            IEnumerable<KeyMap> maps = this.GetKeyMaps();

            foreach (String qwerty in this.qwertyBuilder.Build(this.GetKeyPad(maps), type))
            {
                if (qwerty.Contains(password))
                {
                    throw new QwertyException(password, qwerty, type, false);
                }
            }

            foreach (String qwerty in this.qwertyBuilder.Build(this.GetNumPad(maps), type))
            {
                if (qwerty.Contains(password))
                {
                    throw new QwertyException(password, qwerty, type, true);
                }
            }
        }

        #endregion

        #region Private Methods

        private IEnumerable<KeyMap> GetKeyMaps()
        {
            return this.keyboardCollector.Collect();
        }

        private KeyPad GetKeyPad(IEnumerable<KeyMap> maps)
        {
            return this.keyboardBuilder.Build(maps);
        }

        private KeyPad GetNumPad(IEnumerable<KeyMap> maps)
        {
            return this.numericBuilder.Build(maps);
        }

        #endregion
    }
}

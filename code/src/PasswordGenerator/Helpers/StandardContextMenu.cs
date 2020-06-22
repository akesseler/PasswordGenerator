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
using System.Windows.Forms;

namespace Plexdata.PasswordGenerator.Helpers
{
    public class StandardContextMenu : ContextMenuStrip
    {
        #region Public Fields

        public const String MenuCopy = "Copy";
        public const String MenuCut = "Cut";
        public const String MenuPaste = "Paste";
        public const String MenuClear = "Clear";

        public static StandardContextMenu Empty;

        #endregion

        #region Construction

        static StandardContextMenu()
        {
            StandardContextMenu.Empty = new StandardContextMenu();
        }

        public StandardContextMenu()
            : base()
        {
        }

        public StandardContextMenu(IContainer container)
            : base(container)
        {
        }

        #endregion

        #region Public Properties

        public ToolStripItem Copy
        {
            get
            {
                return this.Items[StandardContextMenu.MenuCopy];
            }
        }

        public ToolStripItem Cut
        {
            get
            {
                return this.Items[StandardContextMenu.MenuCut];
            }
        }

        public ToolStripItem Paste
        {
            get
            {
                return this.Items[StandardContextMenu.MenuPaste];
            }
        }

        public ToolStripItem Clear
        {
            get
            {
                return this.Items[StandardContextMenu.MenuClear];
            }
        }

        #endregion

        #region Public Methods

        public static StandardContextMenu Create()
        {
            return StandardContextMenu.Create(null, null);
        }

        public static StandardContextMenu Create(EventHandler click)
        {
            return StandardContextMenu.Create(null, click);
        }

        public static StandardContextMenu Create(IContainer container)
        {
            return StandardContextMenu.Create(container, null);
        }

        public static StandardContextMenu Create(IContainer container, EventHandler click)
        {
            StandardContextMenu result = null;

            if (container == null)
            {
                result = new StandardContextMenu();
            }
            else
            {
                result = new StandardContextMenu(container);
            }


            ToolStripItem current = null;

            current = new ToolStripMenuItem(StandardContextMenu.MenuCopy);
            current.Name = current.Text;
            if (click != null) { current.Click += click; }
            result.Items.Add(current);

            current = new ToolStripMenuItem(StandardContextMenu.MenuCut);
            current.Name = current.Text;
            if (click != null) { current.Click += click; }
            result.Items.Add(current);

            current = new ToolStripMenuItem(StandardContextMenu.MenuPaste);
            current.Name = current.Text;
            if (click != null) { current.Click += click; }
            result.Items.Add(current);

            result.Items.Add(new ToolStripSeparator());

            current = new ToolStripMenuItem(StandardContextMenu.MenuClear);
            current.Name = current.Text;
            if (click != null) { current.Click += click; }
            result.Items.Add(current);



            return result;
        }

        public static StandardContextMenu MenuFromSender(Object sender, out Control control)
        {
            control = null;

            if (sender is StandardContextMenu result)
            {
                control = result.SourceControl;
                return result;
            }

            return null;
        }

        public static ToolStripItem ItemFromSender(Object sender, out StandardContextMenu parent)
        {
            parent = null;

            if (sender is ToolStripItem result)
            {
                ToolStrip helper = result.GetCurrentParent();

                if (helper is StandardContextMenu)
                {
                    parent = helper as StandardContextMenu;

                    return result;
                }
            }

            return null;
        }

        public void DisableAll()
        {
            foreach (ToolStripItem item in this.Items)
            {
                item.Enabled = false;
            }
        }

        public Boolean IsMenu(ToolStripItem source, String name)
        {
            return source != null && !String.IsNullOrWhiteSpace(name) &&
                   source.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase);
        }

        public Boolean IsCopy(ToolStripItem source)
        {
            return this.IsMenu(source, StandardContextMenu.MenuCopy);
        }

        public Boolean IsCut(ToolStripItem source)
        {
            return this.IsMenu(source, StandardContextMenu.MenuCut);
        }

        public Boolean IsPaste(ToolStripItem source)
        {
            return this.IsMenu(source, StandardContextMenu.MenuPaste);
        }

        public Boolean IsClear(ToolStripItem source)
        {
            return this.IsMenu(source, StandardContextMenu.MenuClear);
        }

        #endregion
    }
}

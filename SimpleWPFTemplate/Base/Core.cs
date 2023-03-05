/*
*MIT License
*
*Copyright (c) 2023 S Christison
*
*Permission is hereby granted, free of charge, to any person obtaining a copy
*of this software and associated documentation files (the "Software"), to deal
*in the Software without restriction, including without limitation the rights
*to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
*copies of the Software, and to permit persons to whom the Software is
*furnished to do so, subject to the following conditions:
*
*The above copyright notice and this permission notice shall be included in all
*copies or substantial portions of the Software.
*
*THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
*IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
*FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
*AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
*LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
*OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
*SOFTWARE.
*/

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Threading;

namespace WPFTemplate
{
    public class Core : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Trigger a PropertyChangedEvent for a Caller
        /// </summary>
        /// <param name="callerName"></param>
        protected void PropChanged([CallerMemberName] string callerName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
        }

        /// <summary>
        /// Execute an Action in the Appropriate UI Thread
        /// <para>Will Invoke the UI if you are not already in the Appropriate UI Thread</para>
        /// <para>Runs Synchronously</para>
        /// </summary>
        /// <param name="action"></param>
        public static void Invoke(Action action)
        {
            Application.Current.Dispatcher.Invoke(action, DispatcherPriority.Render);
        }

        /// <summary>
        /// Execute an Action in the Appropriate UI Thread using the Scheduler
        /// <para>Returns control to the UI Thread immediately</para>
        /// </summary>
        /// <param name="action"></param>
        public static void Begin(Action action)
        {
            Application.Current.Dispatcher.BeginInvoke((Action)delegate { action(); });
        }
    }
}

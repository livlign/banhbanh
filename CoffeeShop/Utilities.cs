using Subsonic2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace CoffeeShop
{
    public class Utilities
    {
        public static User CurrentUser { get; set; }

        public static OrderNote _note;
        public static OrderNote orderNote 
        { 
            get 
            {
                if (_note == null)
                {
                    _note = new OrderNoteCollection().Where(OrderNote.Columns.Type,2).Load().FirstOrDefault();
                }
                return _note;
            }
            set
            {
                _note = value;
            }
        }

        public static OrderNote _mainnote;
        public static OrderNote mainNote
        {
            get
            {
                if (_mainnote == null)
                {
                    _mainnote = new OrderNoteCollection().Where(OrderNote.Columns.Type, 1).Load().FirstOrDefault();
                }
                return _mainnote;
            }
            set
            {
                _mainnote = value;
            }
        }

        public static void FormatMoney(object sender)
        {
            try
            {
                TextBox textBox = sender as TextBox;
                if (!string.IsNullOrEmpty(textBox.Text))
                {
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                    int valueBefore = Int32.Parse(textBox.Text, System.Globalization.NumberStyles.AllowThousands);
                    textBox.Text = String.Format(culture, "{0:N0}", valueBefore);
                    textBox.Select(textBox.Text.Length, 0);
                }
            }
            catch { }
        }
        /// <summary>
        /// Handler event when wrong integer input
        /// </summary>
        /// <param name="e"></param>
        public static bool HandlerIntTextbox(KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                return false;
            }
            return true;
        }

        public static void WriteLogError(string error)
        {
            var path = @"C:\CoffeeShop\Error\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var filepath = path + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
            var datetime = " - " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + ": ";

            using (FileStream fs = new FileStream(filepath, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(datetime + error);
            }
        }

        public static void InHtml(string html){
            var task = MessageLoopWorker.Run(DoWorkAsync, html, html);
            task.Wait();
        }

        // navigate WebBrowser to the list of urls in a loop
        public static async Task<object> DoWorkAsync(object[] args)
        {
            Console.WriteLine("Start working.");

            var wb = new WebBrowser();
            wb.ScriptErrorsSuppressed = true;

            if (wb.Document == null && wb.ActiveXInstance == null)
                throw new ApplicationException("Unable to initialize the underlying WebBrowserActiveX");

            // get the underlying WebBrowser ActiveX object;
            // this code depends on SHDocVw.dll COM interop assembly,
            // generate SHDocVw.dll: "tlbimp.exe ieframe.dll",
            // and add as a reference to the project
            var wbax = (SHDocVw.WebBrowser)wb.ActiveXInstance;

            TaskCompletionSource<bool> loadedTcs = null;
            WebBrowserDocumentCompletedEventHandler documentCompletedHandler = (s, e) =>
                loadedTcs.TrySetResult(true); // turn event into awaitable task

            TaskCompletionSource<bool> printedTcs = null;
            SHDocVw.DWebBrowserEvents2_PrintTemplateTeardownEventHandler printTemplateTeardownHandler = (p) =>
                printedTcs.TrySetResult(true); // turn event into awaitable task

            // navigate to each URL in the list
            foreach (var url in args)
            {
                loadedTcs = new TaskCompletionSource<bool>();
                wb.DocumentCompleted += documentCompletedHandler;
                try
                {
                    wb.Navigate(url.ToString());
                    // await for DocumentCompleted
                    await loadedTcs.Task;
                }
                finally
                {
                    wb.DocumentCompleted -= documentCompletedHandler;
                }

                // the DOM is ready, 
                Console.WriteLine(url.ToString());
                Console.WriteLine(wb.Document.Body.OuterHtml);

                // print the document
                printedTcs = new TaskCompletionSource<bool>();
                wbax.PrintTemplateTeardown += printTemplateTeardownHandler;
                try
                {
                    wb.Print();
                    // await for PrintTemplateTeardown - the end of printing
                    await printedTcs.Task;
                }
                finally
                {
                    wbax.PrintTemplateTeardown -= printTemplateTeardownHandler;
                }
                Console.WriteLine(url.ToString() + " printed.");
            }

            wb.Dispose();
            Console.WriteLine("End working.");
            return null;
        }

        public static class MessageLoopWorker
        {
            public static async Task<object> Run(Func<object[], Task<object>> worker, params object[] args)
            {
                var tcs = new TaskCompletionSource<object>();

                var thread = new Thread(() =>
                {
                    EventHandler idleHandler = null;

                    idleHandler = async (s, e) =>
                    {
                        // handle Application.Idle just once
                        Application.Idle -= idleHandler;

                        // return to the message loop
                        await Task.Yield();

                        // and continue asynchronously
                        // propogate the result or exception
                        try
                        {
                            var result = await worker(args);
                            tcs.SetResult(result);
                        }
                        catch (Exception ex)
                        {
                            tcs.SetException(ex);
                        }

                        // signal to exit the message loop
                        // Application.Run will exit at this point
                        Application.ExitThread();
                    };

                    // handle Application.Idle just once
                    // to make sure we're inside the message loop
                    // and SynchronizationContext has been correctly installed
                    Application.Idle += idleHandler;
                    Application.Run();
                });

                // set STA model for the new thread
                thread.SetApartmentState(ApartmentState.STA);

                // start the thread and await for the task
                thread.Start();
                try
                {
                    return await tcs.Task;
                }
                finally
                {
                    thread.Join();
                }
            }
        }

    }
}

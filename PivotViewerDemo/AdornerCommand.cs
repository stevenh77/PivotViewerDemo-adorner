using System;
using System.Windows;
using System.Windows.Controls.Pivot;

namespace PivotViewerDemo
{
    public class AdornerCommand : IPivotViewerUICommand
    {
        private readonly Price price;

        public AdornerCommand(Price price)
        {
            this.price = price;
        }

        #region IPivotViewerUICommand

        public string DisplayName
        {
            get { return "Book price"; }
        }

        public Uri Icon
        {
            get { return null; }
        }

        public object ToolTip
        {
            get { return "Click this to book the price"; }
        }

        #endregion

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            //MessageBox.Show(string.Format("Boom!{0}{0}{1}", Environment.NewLine, price.ToString()));
            
            // 1.  Redirect to bbc.co.uk
            //System.Windows.Browser.HtmlPage.Window.Navigate(new Uri("http://bbc.co.uk", UriKind.Absolute));

            // or
            // 2.  Use the price underlying as part of the URL 
            var uriString = string.Format("http://www.google.com/finance?q=NASDAQ:{0}", price.Underlying);
            var uri = new Uri(uriString, UriKind.Absolute);
            System.Windows.Browser.HtmlPage.Window.Navigate(uri);

            // or
            // 3.  Open a new tab (popup)
            //System.Windows.Browser.HtmlPage.Window.Navigate(uri, "_blank");
        }
    }
}

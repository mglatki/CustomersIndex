using CustomersIndex.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CustomersIndex.TemplateSelectors
{
    public class ClientsListTemplateSelector : DataTemplateSelector
    {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {        
            FrameworkElement element = container as FrameworkElement;
            IClient client = item as IClient;
            if(client.IsBusinessClient)
            {
                return element.FindResource("BusinessClientDataTemplate") as DataTemplate;
            }
            else
            {
                return element.FindResource("IndividualClientDataTemplate") as DataTemplate;
            }
        }
    }

    public class ClickedTabsTemplateSelector : DataTemplateSelector
    {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            IClient client = item as IClient;
            if (client.IsBusinessClient)
            {
                return element.FindResource("BusinessClientDataTemplate") as DataTemplate;
            }
            else
            {
                return element.FindResource("IndividualClientDataTemplate") as DataTemplate;
            }
        }
    }
}

using StudyBuddyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace StudyBuddyApp.DataTemplates
{
    public class ConversationDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate LeftTemplate { get; set; }
        public DataTemplate RightTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((MessageModel)item).RightSide ? RightTemplate : LeftTemplate;
        }
    }
}

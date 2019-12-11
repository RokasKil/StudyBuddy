using StudyBuddyApp.Models;
using StudyBuddyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace StudyBuddyApp.DataTemplates
{
    class HelpRequestDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate HelpRequestTemplate { get; set; }
        public DataTemplate CommentTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return (item is HelpRequestCommentsModel) ? HelpRequestTemplate : CommentTemplate;
        }
    }
}

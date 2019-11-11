using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace StudyBuddyApp.Models
{
    public class MessageModel
    {
        public LayoutOptions HorizontalOptions {
            get
            {
                if (RightSide)
                {
                    return LayoutOptions.End;
                }
                else
                {
                    return LayoutOptions.Start;
                }
            }
        }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Message { get; set; }
        public bool RightSide { get; set; }

        public GridLength FirstWidth
        {
            get
            {
                if (RightSide)
                {
                    return thirtyWidth;
                }
                else
                {
                    return zeroWidth;
                }
            }
        }

        public GridLength ThirdWidth
        {
            get {
                if (RightSide)
                {
                    return zeroWidth;
                }
                else
                {
                    return thirtyWidth;
                }
            }
        }

        public TextAlignment TextAlignment
        {
            get
            {
                if (RightSide)
                {
                    return TextAlignment.End;
                }
                else
                {
                    return TextAlignment.Start;
                }
            }
        }

        public Color Color
        {
            get
            {
                if (RightSide)
                {
                    return rightColor;
                }
                else
                {
                    return leftColor;
                }
            }
        }
        private static readonly GridLength zeroWidth = new GridLength(0, GridUnitType.Star);
        private static readonly GridLength thirtyWidth = new GridLength(30, GridUnitType.Star);

        private static readonly Color leftColor = Color.Teal;
        private static readonly Color rightColor = Color.Gray;

    }
}

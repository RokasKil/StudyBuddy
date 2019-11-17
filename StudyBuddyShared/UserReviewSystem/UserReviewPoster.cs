using StudyBuddyShared.Entity;
using StudyBuddyShared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.UserReviewSystem
{
    public class UserReviewPoster : UserReviewManagerBase, IUserReviewPoster
    {
        public UserReviewPoster(LocalUser user) : this(user.PrivateKey)
        {
        }

        public UserReviewPoster(string privateKey) : base(privateKey)
        {
            manager.PostUserReviewResult = (status, userReview) =>
            {
                Result?.Invoke(EnumConverter.Convert<UserReviewManageStatus>(status), userReview);
            };
        }

        public UserReviewManageDelegate Result { get; set; }

        public void Post(UserReview userReview)
        {
            manager.postReview(userReview);
        }
    }
}

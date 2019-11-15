using StudyBuddyShared.Entity;
using StudyBuddyShared.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.UserReviewSystem
{
    class UserReviewRemover : UserReviewManagerBase, IUserReviewRemover
    {
        public UserReviewRemover(LocalUser user) : this(user.PrivateKey)
        {
        }

        public UserReviewRemover(string privateKey) : base(privateKey)
        {
            manager.RemoveUserReviewResult = (status, userReview) =>
            {
                Result?.Invoke(EnumConverter.Convert<UserReviewManageStatus>(status), userReview);
            };
        }

        public UserReviewManageDelegate Result { get; set; }

        public void Remove(UserReview userReview)
        {
            manager.removeUserReview(userReview);
        }
    }
}

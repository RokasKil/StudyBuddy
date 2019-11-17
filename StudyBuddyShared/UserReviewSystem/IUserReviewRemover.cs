using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.UserReviewSystem
{
    public interface IUserReviewRemover : IPrivateKey
    {
        UserReviewManageDelegate Result { get; set; } // Result delegate

        void Remove(UserReview userReview); // Remove review

    }
}

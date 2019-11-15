using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.UserReviewSystem
{
    public enum UserReviewManageStatus
    {
        InvalidPrivateKey,
        Success,
        JsonReadException,
        FailedToConnect,
        UnknownError,
        FailedToFindUser,
        UsernameEmpty,
        MessageEmpty,
        FieldsMissing,
        MessageTooLong,
        NoSelfReview
    }

    public delegate void UserReviewManageDelegate(UserReviewManageStatus status, UserReview userReview);

    public interface IUserReviewPoster : IPrivateKey
    {
        UserReviewManageDelegate Result { get; set; } // Result delegate

        void Post(UserReview userReview); // post review

    }
}

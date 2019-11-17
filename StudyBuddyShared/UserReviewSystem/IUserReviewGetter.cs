using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddyShared.UserReviewSystem
{
    public enum UserReviewsGetStatus
    {
        InvalidPrivateKey,
        Success,
        JsonReadException,
        FailedToConnect,
        UnknownError,
        FieldsMissing
    }

    public delegate void GetUserReviewsDelegate(UserReviewsGetStatus status, List<UserReview> userReviews, Dictionary<string, User> users);

    public interface IUserReviewGetter : IPrivateKey
    {
        GetUserReviewsDelegate Result { get; set; } // Result delegate

        void Get(string username, bool getUsers = true); // Get reviews for user, and if it should include user profiles who wrote them
    }
}

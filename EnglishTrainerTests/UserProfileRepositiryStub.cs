using Newtonsoft.Json;
using TrainerEnglish;
using TrainerEnglish.Users;
using System.Linq;
using System;

namespace EnglishTrainerTests
{
    class UserProfileRepositiryStub : IUserProfileRepository
    {
        private readonly string _jsonDatabase;

        public UserProfileRepositiryStub(string json)
        {
            _jsonDatabase = json;
        }

        public IUserProfile[] GetAllUserProfiles()
        {
            var userProfiles = JsonConvert.DeserializeObject<UserProfile[]>(_jsonDatabase);
            return userProfiles;
        }

        public IUserProfile GetUserProfile(int userId)
        {
            var userProfiles = GetAllUserProfiles();
            return userProfiles.FirstOrDefault(user => user.Id == userId);
        }

        public void SaveUserProfile(IUserProfile userProfile)
        {
        }
    }
}
